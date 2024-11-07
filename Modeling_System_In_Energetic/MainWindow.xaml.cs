using OxyPlot;
using OxyPlot.Series;
using System;
using System.Windows;
using OxyPlot.Axes;

namespace Modeling_System_In_Energetic
{
    public partial class MainWindow : Window
    {
        public PlotModel ZenithPlotModel { get; set; }
        public PlotModel AzimuthPlotModel { get; set; }
        public PlotModel IrradiancePlotModel { get; set; }

        private double latitude = 50.0; // Географічна широта (наприклад, 50° для України)
        private int dayOfYear = 172; // День року (наприклад, 172 для 21 червня - день літнього сонцестояння)

        public MainWindow()
        {
            InitializeComponent();

            // Створення графіків
            ZenithPlotModel = CreateZenithPlot();
            AzimuthPlotModel = CreateAzimuthPlot();
            IrradiancePlotModel = CreateIrradiancePlot();

            // Прив'язка графіків до моделей у XAML
            this.DataContext = this;
        }

        private PlotModel CreateZenithPlot()
        {
            var model = new PlotModel { Title = "Зенітний кут" };

            var series = new LineSeries
            {
                Title = "Зенітний кут",
                Color = OxyColors.Orange
            };

            for (int hour = 0; hour < 24; hour++)
            {
                double zenithAngle = CalculateZenithAngle(hour);
                series.Points.Add(new DataPoint(hour, zenithAngle));
            }

            model.Series.Add(series);

            model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Minimum = 0, Maximum = 24, Title = "Час (година)" });
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Minimum = 0, Maximum = 90, Title = "Кут (градуси)" });

            return model;
        }

        private double CalculateZenithAngle(int hour)
        {
            double declination = 23.45 * Math.Sin((360.0 / 365.0) * (dayOfYear - 81) * Math.PI / 180); // Деклінація
            double hourAngle = (hour - 12) * 15; // Годинний кут в градусах

            // Формула для обчислення зенітного кута
            double zenithCos = Math.Sin(latitude * Math.PI / 180) * Math.Sin(declination * Math.PI / 180) +
                               Math.Cos(latitude * Math.PI / 180) * Math.Cos(declination * Math.PI / 180) * Math.Cos(hourAngle * Math.PI / 180);
            double zenithAngle = Math.Acos(zenithCos) * 180 / Math.PI;

            return zenithAngle;
        }

        private PlotModel CreateAzimuthPlot()
        {
            var model = new PlotModel { Title = "Азимутальний кут" };

            var series = new LineSeries
            {
                Title = "Азимутальний кут",
                Color = OxyColors.Blue
            };

            for (int hour = 0; hour < 24; hour++)
            {
                double azimuthAngle = CalculateAzimuthAngle(hour);
                series.Points.Add(new DataPoint(hour, azimuthAngle));
            }

            model.Series.Add(series);

            model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Minimum = 0, Maximum = 24, Title = "Час (година)" });
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Minimum = 0, Maximum = 360, Title = "Азимут (градуси)" });

            return model;
        }

        private double CalculateAzimuthAngle(int hour)
        {
            double declination = 23.45 * Math.Sin((360.0 / 365.0) * (dayOfYear - 81) * Math.PI / 180);
            double hourAngle = (hour - 12) * 15;
            double zenithAngle = CalculateZenithAngle(hour);

            // Формула для азимутального кута
            double sinAzimuth = Math.Cos(declination * Math.PI / 180) * Math.Sin(hourAngle * Math.PI / 180) / Math.Sin(zenithAngle * Math.PI / 180);
            double azimuthAngle = Math.Asin(sinAzimuth) * 180 / Math.PI;

            if (hour > 12)
                azimuthAngle = 180 - azimuthAngle;

            return azimuthAngle;
        }

        private PlotModel CreateIrradiancePlot()
        {
            var model = new PlotModel { Title = "Глобальне випромінювання" };

            var series = new LineSeries
            {
                Title = "Глобальне випромінювання",
                Color = OxyColors.Green
            };

            for (int hour = 0; hour < 24; hour++)
            {
                double irradiance = CalculateIrradiance(hour);
                series.Points.Add(new DataPoint(hour, irradiance));
            }

            model.Series.Add(series);

            model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Minimum = 0, Maximum = 24, Title = "Час (година)" });
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Minimum = 0, Maximum = 1000, Title = "Випромінювання (Вт/м²)" });

            return model;
        }

        private double CalculateIrradiance(int hour)
        {
            double zenithAngle = CalculateZenithAngle(hour);
            double maxIrradiance = 1000; // Максимальне випромінювання на квадратний метр

            // Випромінювання залежить від зенітного кута
            return maxIrradiance * Math.Max(0, Math.Cos(zenithAngle * Math.PI / 180));
        }
    }
}
