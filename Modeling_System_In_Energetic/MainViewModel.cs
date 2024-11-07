/*using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace Modeling_System_In_Energetic
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ISeries[] ZenithSeries { get; set; }
        public ISeries[] AzimuthSeries { get; set; }
        public ISeries[] IrradianceSeries { get; set; }

        public MainViewModel()
        {
            // Форматування міток для кожної осі
            ZenithSeries = new ISeries[] { new LineSeries<double> { Values = GenerateZenithData() } };
            AzimuthSeries = new ISeries[] { new LineSeries<double> { Values = GenerateAzimuthData() } };
            IrradianceSeries = new ISeries[] { new LineSeries<double> { Values = GenerateIrradianceData() } };
        }

        private List<double> GenerateZenithData()
        {
            var data = new List<double>();
            for (double hour = 0; hour <= 24; hour += 0.5)
            {
                double zenith = 90 - 20 * System.Math.Cos((hour - 12) * System.Math.PI / 12);
                data.Add(zenith);
            }
            return data;
        }

        private List<double> GenerateAzimuthData()
        {
            var data = new List<double>();
            for (double hour = 0; hour <= 24; hour += 0.5)
            {
                double azimuth = 180 + 80 * System.Math.Sin((hour - 6) * System.Math.PI / 12);
                data.Add(azimuth);
            }
            return data;
        }

        private List<double> GenerateIrradianceData()
        {
            var data = new List<double>();
            for (double hour = 0; hour <= 24; hour += 0.5)
            {
                double irradiance = 800 * System.Math.Exp(-((hour - 12) * (hour - 12)) / 20);
                data.Add(irradiance);
            }
            return data;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
*/