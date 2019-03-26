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
        PlotModel myModel;
        LineSeries phi1LineSeries;
        LineSeries phi2LineSeries;

        public static double w1, w2, d, delta, time;

        public Form1()
        {
            InitializeComponent();

            myModel = new PlotModel { Title = "synchronization" };
            myModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "t"});
            myModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "φ₁,φ₂" });

            phi1LineSeries = new LineSeries { Color = OxyColors.Blue, Title = "φ₁" };
            phi2LineSeries = new LineSeries { Color = OxyColors.Red, Title = "φ₂" };
        }

        private void trySync_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(tTextBox.Text, out time)) return;
            if (!double.TryParse(w1TextBox.Text, out w1)) return;
            if (!double.TryParse(dTextBox.Text, out d)) return;

            double E = 0.001;
            delta = 2 * d - E;
            w2 = w1 + delta;
            label4.Text = $"ω₂={w2.ToString()}";

            RungeKuttaFehlbergIntegrator rkf45 = new RungeKuttaFehlbergIntegrator();

            rkf45.InitialTime = 0.0;
            rkf45.InitialValue = Vector.Create(0.0, 0.0);
            rkf45.DifferentialFunction = TwoDifEqSystem;
            rkf45.AbsoluteTolerance = 1e-8;

            phi1LineSeries.Points.Clear();
            phi2LineSeries.Points.Clear();

            Console.WriteLine("Classic 4/5th order Runge-Kutta-Fehlberg");
            for (int t = 0; t <= time; t++)
            {
                var y = rkf45.Integrate(t);
                Console.WriteLine("{0:F2}: {1,20:F14} ({2} steps)", t, y, rkf45.IterationsNeeded);

                phi1LineSeries.Points.Add(new DataPoint(t, y[0]));
                phi2LineSeries.Points.Add(new DataPoint(t, y[1]));
            }

            myModel.Series.Clear();
            myModel.Series.Add(phi1LineSeries);
            myModel.Series.Add(phi2LineSeries);

            this.plotView1.Model = myModel;
            this.plotView1.Refresh();
            this.plotView1.Show();
        }

        private static Vector<double> TwoDifEqSystem(double t, Vector<double> phi, Vector<double> dphi)
        {
            if (dphi == null)
                dphi = Vector.Create<double>(2);

            dphi[0] = w1 + d * Math.Sin(phi[1] - phi[0]);
            dphi[1] = w2 + d * Math.Sin(phi[0] - phi[1]);

            return dphi;
        }

        private static Vector<double> OneDifur(double t, Vector<double> psi, Vector<double> dpsi)
        {
            if (dpsi == null)
                dpsi = Vector.Create<double>(1);

            dpsi[0] = delta - d * Math.Sin(psi[0])/* + A * Math.Cos(omega * t)*/;

            return dpsi;
        }
    }
}
