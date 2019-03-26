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
        LineSeries fi1LineSeries;
        LineSeries fi2LineSeries;

        public static double w1, w2, d, delta, time;

        public Form1()
        {
            InitializeComponent();

            fi1LineSeries = new LineSeries { Color = OxyColors.Blue, Title = "φ₁" };
            fi2LineSeries = new LineSeries { Color = OxyColors.Red, Title = "φ₂" };

            myModel = new PlotModel { Title = "synchronization" };
            myModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "t"});
            myModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "φ₁,φ₂" });
        }

        private void trySync_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(tTextBox.Text, out time)) return;
            if (!double.TryParse(w1TextBox.Text, out w1)) return;
            if (!double.TryParse(dTextBox.Text, out d)) return;

            delta = 0.09;
            w2 = w1 + delta;
            label4.Text = $"ω₂={w2.ToString()}";

            RungeKuttaFehlbergIntegrator rkf45 = new RungeKuttaFehlbergIntegrator();

            rkf45.InitialTime = 0.0;
            rkf45.InitialValue = Vector.Create(1.0, 0.0);
            rkf45.DifferentialFunction = TwoDifEqSystem;
            rkf45.AbsoluteTolerance = 1e-8;

            fi1LineSeries.Points.Clear();
            fi2LineSeries.Points.Clear();

            Console.WriteLine("Classic 4/5th order Runge-Kutta-Fehlberg");
            for (int t = 0; t <= time; t++)
            {
                var y = rkf45.Integrate(t);
                Console.WriteLine("{0:F2}: {1,20:F14} ({2} steps)", t, y, rkf45.IterationsNeeded);

                fi1LineSeries.Points.Add(new DataPoint(t, y[0]));
                fi2LineSeries.Points.Add(new DataPoint(t, y[1]));
            }

            myModel.Series.Clear();
            myModel.Series.Add(fi1LineSeries);
            myModel.Series.Add(fi2LineSeries);

            this.plotView1.Model = myModel;
            this.plotView1.Refresh();
            this.plotView1.Show();
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
