using System;
using System.Globalization;
using Foundation;
using MvvmCross.Converters;

// ReSharper disable once CheckNamespace
namespace SByteDev.MvvmCross.Plugins.DateTimeConverter
{
    [Preserve(AllMembers = true)]
    public sealed class NullableDateTimeOffsetToMediumDateStringValueConverter : MvxValueConverter<DateTimeOffset?, string>
    {
        private readonly DateTimeOffsetToMediumDateStringValueConverter _converter;

        public NullableDateTimeOffsetToMediumDateStringValueConverter()
        {
            _converter = new DateTimeOffsetToMediumDateStringValueConverter();
        }

        protected override string Convert(DateTimeOffset? value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.HasValue ? (string) _converter.Convert(value.Value, targetType, parameter, culture) : null;
        }
    }
}