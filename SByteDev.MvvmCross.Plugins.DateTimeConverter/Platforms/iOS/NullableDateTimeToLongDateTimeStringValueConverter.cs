using System;
using System.Globalization;
using Foundation;
using MvvmCross.Converters;

// ReSharper disable once CheckNamespace
namespace SByteDev.MvvmCross.Plugins.DateTimeConverter
{
    [Preserve(AllMembers = true)]
    public sealed class NullableDateTimeToLongDateTimeStringValueConverter : MvxValueConverter<DateTime?, string>
    {
        private readonly DateTimeToLongDateTimeStringValueConverter _converter;

        public NullableDateTimeToLongDateTimeStringValueConverter()
        {
            _converter = new DateTimeToLongDateTimeStringValueConverter();
        }

        protected override string Convert(DateTime? value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.HasValue ? (string) _converter.Convert(value.Value, targetType, parameter, culture) : null;
        }
    }
}