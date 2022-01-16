using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF6
{
    class WeatherControl: DependencyObject
    {
       

        public static readonly DependencyProperty TempProperty = DependencyProperty.Register(
           nameof(Temp),
           typeof(int),
           typeof(WeatherControl),
           new FrameworkPropertyMetadata(
               0,
               FrameworkPropertyMetadataOptions.AffectsMeasure |
               FrameworkPropertyMetadataOptions.AffectsRender,
               null,
               new CoerceValueCallback(CoerceTemp)),
           new ValidateValueCallback(ValidateTemp));

        public string windDirection;
        public int windSpeed;

        private static bool ValidateTemp(object value)
        {
            int v = (int)value;
            if (v >= -50 && v <= 50)
                return true;
            else
                return false;
        }

        private static object CoerceTemp(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v >= -50 && v <= 50)
                return v;
            else
                return 0;
        }

        public int Temp
        {
            get => (int)GetValue(TempProperty);
            set => SetValue(TempProperty, value);
        }
        
        public enum Osadki
        {
            солнечно = 0,
            облачно = 1,
            дождь = 2,
            снег = 4
        }
    }
}
