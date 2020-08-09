using System;
using System.Globalization;
using Foundation;
using MvvmCross.Converters;

// ReSharper disable once CheckNamespace
namespace SByteDev.MvvmCross.Plugins.DateTimeConverter
{
    [Preserve(AllMembers = true)]
    public sealed class NullableDateTimeOffsetToLongDateTimeStringValueConverter : MvxValueConverter<DateTimeOffset?, string>
    {
        private readonly DateTimeOffsetToLongDateTimeStringValueConverter _converter;

        public NullableDateTimeOffsetToLongDateTimeStringValueConverter()
        {
            _converter = new DateTimeOffsetToLongDateTimeStringValueConverter();
        }

        protected override string Convert(DateTimeOffset? value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.HasValue ? (string) _converter.Convert(value.Value, targetType, parameter, culture) : null;
        }
    }
}