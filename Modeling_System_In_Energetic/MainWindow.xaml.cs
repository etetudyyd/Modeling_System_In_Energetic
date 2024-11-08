using OxyPlot;
using OxyPlot.Series;
using System;
using System.Windows;
using OxyPlot.Axes;

namespace Modeling_System_In_Energetic
{
    public partial class MainWindow : Window
    {
        public PlotModel[] ZenithPlotModels { get; set; }
        public PlotModel[] AzimuthPlotModels { get; set; }
        public PlotModel[] IrradiancePlotModels { get; set; }

        private double latitude = 50.0;
        private int[] daysOfYear = { 23, 112, 204, 295 }; 

        public MainWindow()
        {
            InitializeComponent();

            // Ініціалізація масивів моделей
            ZenithPlotModels = new PlotModel[4];
            AzimuthPlotModels = new PlotModel[4];
            IrradiancePlotModels = new PlotModel[4];

            // Створення графіків для кожного місяця
            for (int i = 0; i < daysOfYear.Length; i++)
            {
                ZenithPlotModels[i] = CreateZenithPlot(daysOfYear[i]);
                AzimuthPlotModels[i] = CreateAzimuthPlot(daysOfYear[i]);
                IrradiancePlotModels[i] = CreateIrradiancePlot(daysOfYear[i]);
            }

            // Прив'язка моделей до DataContext для XAML
            this.DataContext = this;
        }

        private PlotModel CreateZenithPlot(int dayOfYear)
        {
            var model = new PlotModel { Title = "Зенітний кут - День " + dayOfYear };

            var series = new LineSeries
            {
                Title = "Зенітний кут",
                Color = OxyColors.Orange
            };

            for (int hour = 0; hour < 24; hour++)
            {
                double zenithAngle = CalculateZenithAngle(hour, dayOfYear);
                series.Points.Add(new DataPoint(hour, zenithAngle));
            }

            model.Series.Add(series);
            model.Axes.Add(new LinearAxis
                { Position = AxisPosition.Bottom, Minimum = 0, Maximum = 24, Title = "Час (година)" });
            model.Axes.Add(new LinearAxis
                { Position = AxisPosition.Left, Minimum = 0, Maximum = 90, Title = "Кут (градуси)" });

            return model;
        }

        private PlotModel CreateAzimuthPlot(int dayOfYear)
        {
            var model = new PlotModel { Title = "Азимутальний кут - День " + dayOfYear };

            var series = new LineSeries
            {
                Title = "Азимутальний кут",
                Color = OxyColors.Blue
            };

            for (int hour = 0; hour < 24; hour++)
            {
                double azimuthAngle = CalculateAzimuthAngle(hour, dayOfYear);
                series.Points.Add(new DataPoint(hour, azimuthAngle));
            }

            model.Series.Add(series);
            model.Axes.Add(new LinearAxis
                { Position = AxisPosition.Bottom, Minimum = 0, Maximum = 24, Title = "Час (година)" });
            model.Axes.Add(new LinearAxis
                { Position = AxisPosition.Left, Minimum = 0, Maximum = 360, Title = "Азимут (градуси)" });

            return model;
        }

        private PlotModel CreateIrradiancePlot(int dayOfYear)
        {
            var model = new PlotModel { Title = "Глобальне випромінювання - День " + dayOfYear };

            var series = new LineSeries
            {
                Title = "Глобальне випромінювання",
                Color = OxyColors.Green
            };

            for (int hour = 0; hour < 24; hour++)
            {
                double irradiance = CalculateIrradiance(hour, dayOfYear);
                series.Points.Add(new DataPoint(hour, irradiance));
            }

            model.Series.Add(series);
            model.Axes.Add(new LinearAxis
                { Position = AxisPosition.Bottom, Minimum = 0, Maximum = 24, Title = "Час (година)" });
            model.Axes.Add(new LinearAxis
                { Position = AxisPosition.Left, Minimum = 0, Maximum = 1000, Title = "Випромінювання (Вт/м²)" });

            return model;
        }

        private double CalculateZenithAngle(int hour, int dayOfYear)
        {
            double declination = 23.45 * Math.Sin((360.0 / 365.0) * (dayOfYear - 81) * Math.PI / 180);
            double hourAngle = (hour - 12) * 15;
            double zenithCos = Math.Sin(latitude * Math.PI / 180) * Math.Sin(declination * Math.PI / 180) +
                               Math.Cos(latitude * Math.PI / 180) * Math.Cos(declination * Math.PI / 180) *
                               Math.Cos(hourAngle * Math.PI / 180);
            double zenithAngle = Math.Acos(zenithCos) * 180 / Math.PI;

            return zenithAngle;
        }

        private double CalculateAzimuthAngle(int hour, int dayOfYear)
        {
            double declination = 23.45 * Math.Sin((360.0 / 365.0) * (dayOfYear - 81) * Math.PI / 180);
            double hourAngle = (hour - 12) * 15;
            double zenithAngle = CalculateZenithAngle(hour, dayOfYear);

            double sinAzimuth = Math.Cos(declination * Math.PI / 180) * Math.Sin(hourAngle * Math.PI / 180) /
                                Math.Sin(zenithAngle * Math.PI / 180);
            double azimuthAngle = Math.Asin(sinAzimuth) * 180 / Math.PI;

            if (hour > 12)
                azimuthAngle = 180 - azimuthAngle;

            return azimuthAngle;
        }

        private double CalculateIrradiance(int hour, int dayOfYear)
        {
            double zenithAngle = CalculateZenithAngle(hour, dayOfYear);
            double maxIrradiance = 1000;

            return maxIrradiance * Math.Max(0, Math.Cos(zenithAngle * Math.PI / 180));
        }
    }
}