using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Vistas
{
    public class ConversorDeEstados: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return Brushes.Transparent;
            }
            string minutos2 = (string) value;
            int minutos = int.Parse(minutos2);
            Brush color;

            if (minutos == 0)
            {
                return new SolidColorBrush(Colors.Green);
            }
            else if (minutos > 0 && minutos <= 30)
            {
                return new SolidColorBrush(Color.FromRgb(255, 230, 230));
            }
            else if (minutos > 30 && minutos <= 60)
            {
                return new SolidColorBrush(Color.FromRgb(255, 153, 153));
            }
            else // minutos > 60
            {
                return new SolidColorBrush(Color.FromRgb(204, 0, 0));
            }
            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
