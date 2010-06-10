using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using WM2010.Common;

namespace WM2010.Converter
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var imageData = value as Byte[];
                return Helper.GetImagePath(imageData);
            }
            catch
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
