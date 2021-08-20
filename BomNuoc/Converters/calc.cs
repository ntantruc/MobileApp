using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BomNuoc.Converters
{
    public class CalcConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Resource.Size.calc(double.Parse(parameter as string));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class MarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var values = ((string)parameter).Split(',').Select(x => Resource.Size.calc(double.Parse(x.Trim()))).ToArray();
            if (values.Length == 1) return new Thickness(values[0]);
            if (values.Length == 2) return new Thickness(values[0], values[1]);
            if (values.Length == 4) return new Thickness(values[0], values[1], values[2], values[3]);
            return new Thickness(0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class ScaleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                return Resource.Size.calc(double.Parse(parameter as string)) * 1.02;
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                return Resource.Size.calc(double.Parse(parameter as string) * 100.0) / 100.0;
            }
            else
            {
                return Resource.Size.ViewScale * (double.Parse(parameter as string));
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public static class FromCode
    {
        private static CalcConverter calcConverter = new CalcConverter();
        private static MarginConverter marginConverter = new MarginConverter();
        private static ScaleConverter scaleConverter = new ScaleConverter();
        public static Binding CalcBinding(int Size)
        {
            if (Size <= 64)
            {
                return new Binding("c" + Size.ToString(), BindingMode.Default, null, null, null, ViewModels.calc.i);
            }
            else
            {
                return new Binding("conv", BindingMode.Default, calcConverter, Size.ToString(), null, ViewModels.calc.i);
            }
        }
        public static Binding MarginBinding(double left, double top, double right, double bottom)
        {
            return new Binding("conv", BindingMode.Default, marginConverter, $"{left},{top},{right},{bottom}", null, ViewModels.calc.i);
        }
        public static Binding ScaleBinding(double BaseScale)
        {
            return new Binding("conv", BindingMode.Default, scaleConverter, BaseScale.ToString(), null, ViewModels.calc.i);
        }
    }
}
