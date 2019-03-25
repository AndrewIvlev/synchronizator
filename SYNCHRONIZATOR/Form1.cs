using System;
using System.Windows.Forms;

using Extreme.Mathematics;
using Extreme.Mathematics.Calculus.OrdinaryDifferentialEquations;

using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace SYNCHRONIZATOR
{
    public partial class Form1 : Form
    {

        RungeKuttaFehlbergIntegrator rkf45;

        PlotModel myModel;
        LineSeries fi1LineSeries;
        LineSeries fi2LineSeries;

        public static double w1, w2, d, delta;

        public Form1()
        {
            InitializeComponent();

            rkf45 = new RungeKuttaFehlbergIntegrator();

            fi1LineSeries = new LineSeries { Color = OxyColors.Blue };
            fi2LineSeries = new LineSeries { Color = OxyColors.Red };

            myModel = new PlotModel { Title = "synchronization" };
        }

        private void trySync_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(w1TextBox.Text, out w1)) return;
            if (!double.TryParse(dTextBox.Text, out d)) return;

            delta = 0.5;
            w2 = w1 + delta;

            rkf45.InitialTime = 0.0;
            rkf45.InitialValue = Vector.Create(1.0, 0.0);
            rkf45.DifferentialFunction = TwoDifEqSystem;
            rkf45.AbsoluteTolerance = 1e-8;

            Console.WriteLine("Classic 4/5th order Runge-Kutta-Fehlberg");
            for (int i = 0; i <= 33; i++)
            {
                double t = i;
                var y = rkf45.Integrate(t);
                Console.WriteLine("{0:F2}: {1,20:F14} ({2} steps)", t, y, rkf45.IterationsNeeded);

                fi1LineSeries.Points.Add(new DataPoint(t, y[0]));
                fi2LineSeries.Points.Add(new DataPoint(t, y[1]));
            }
            myModel.Series.Add(fi1LineSeries);
            myModel.Series.Add(fi2LineSeries);
            this.plotView1.Model = myModel;
        }

        private static Vector<double> TwoDifEqSystem(double t, Vector<double> fi, Vector<double> dfi)
        {
            if (dfi == null)
                dfi = Vector.Create<double>(2);

            dfi[0] = w1 + d * Math.Sin(fi[1] - fi[0]);
            dfi[1] = w2 + d * Math.Sin(fi[0] - fi[1]);

            return dfi;
        }
    }
}
