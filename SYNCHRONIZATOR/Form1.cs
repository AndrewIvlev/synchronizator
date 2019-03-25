using System;
using System.Windows.Forms;

using Extreme.Mathematics;
using Extreme.Mathematics.Calculus.OrdinaryDifferentialEquations;

using OxyPlot;
using OxyPlot.Series;

namespace SYNCHRONIZATOR
{
    public partial class Form1 : Form
    {
        RungeKuttaFehlbergIntegrator rkf45;
        public static double w1, w2, d, delta;

        public Form1()
        {
            InitializeComponent();

            rkf45 = new RungeKuttaFehlbergIntegrator();

            var myModel = new PlotModel { Title = "synchronization" };
            myModel.Series.Add(new FunctionSeries(Math.Cos, 0, 150, 0.1, "cos(x)"));
            this.plotView1.Model = myModel;
        }

        private void trySync_Click(object sender, EventArgs e)
        {
            if (double.TryParse(w1TextBox.Text, out w1)) return;
            if (double.TryParse(dTextBox.Text, out d)) return;
            delta = 
            rkf45.InitialTime = 0.0;
            rkf45.InitialValue = Vector.Create(1.0, 0.0);
            rkf45.DifferentialFunction = TwoDifEqSystem;
            rkf45.AbsoluteTolerance = 1e-8;

            Console.WriteLine("Classic 4/5th order Runge-Kutta-Fehlberg");
            for (int i = 0; i <= 100; i++)
            {
                double t = i;
                var y = rkf45.Integrate(t);
                Console.WriteLine("{0:F2}: {1,20:F14} ({2} steps)", t, y, rkf45.IterationsNeeded);
            }
        }

        private static Vector<double> TwoDifEqSystem(double t, Vector<double> fi, Vector<double> dfi)
        {
            if (dfi == null)
                dfi = Vector.Create<double>(3);

            double sigma = 10.0;
            double beta = 8.0 / 3.0;
            double rho = 28.0;

            dfi[0] = w1 + d * Math.Sin(fi[1] - fi[0]);
            dfi[1] = w2 + d * Math.Sin(fi[0] - fi[1]);

            return dfi;
        }
    }
}
