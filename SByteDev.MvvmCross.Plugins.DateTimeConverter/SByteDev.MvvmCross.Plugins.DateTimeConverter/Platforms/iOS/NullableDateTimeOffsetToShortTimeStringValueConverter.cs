using System;
using System.Globalization;
using Foundation;
using MvvmCross.Converters;

// ReSharper disable once CheckNamespace
namespace SByteDev.MvvmCross.Plugins.DateTimeConverter
{
    [Preserve(AllMembers = true)]
    public sealed class NullableDateTimeOffsetToShortTimeStringValueConverter : MvxValueConverter<DateTimeOffset?, string>
    {
        private readonly DateTimeOffsetToShortTimeStringValueConverter _converter;

        public NullableDateTimeOffsetToShortTimeStringValueConverter()
        {
            _converter = new DateTimeOffsetToShortTimeStringValueConverter();
        }

        protected override string Convert(DateTimeOffset? value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.HasValue ? (string) _converter.Convert(value.Value, targetType, parameter, culture) : null;
        }
    }
}