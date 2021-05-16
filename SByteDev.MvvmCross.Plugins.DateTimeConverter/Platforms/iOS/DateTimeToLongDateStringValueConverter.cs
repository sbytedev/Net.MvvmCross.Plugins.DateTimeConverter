using System;
using System.Globalization;
using Foundation;
using MvvmCross.Converters;

// ReSharper disable once CheckNamespace
namespace SByteDev.MvvmCross.Plugins.DateTimeConverter
{
    [Preserve(AllMembers = true)]
    public sealed class DateTimeToLongDateStringValueConverter : MvxValueConverter<DateTime, string>
    {
        protected override string Convert(DateTime value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString(culture, NSDateFormatterStyle.Long, NSDateFormatterStyle.None);
        }
    }
}