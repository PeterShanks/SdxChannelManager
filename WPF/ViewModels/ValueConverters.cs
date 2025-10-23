using System;
using System.Globalization;
using System.Windows.Data;

namespace SdxChannelManager.ViewModels
{
    public class TypeToEmojiConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string type)
            {
                return type == "TV" ? "📺" : "🔊";
            }
            return "📺";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

