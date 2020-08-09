using System;
using System.Globalization;
using Foundation;
using MvvmCross.Converters;

// ReSharper disable once CheckNamespace
namespace SByteDev.MvvmCross.Plugins.DateTimeConverter
{
    [Preserve(AllMembers = true)]
    public sealed class NullableDateTimeToShortDateTimeStringValueConverter : MvxValueConverter<DateTime?, string>
    {
        private readonly DateTimeToShortDateTimeStringValueConverter _converter;

        public NullableDateTimeToShortDateTimeStringValueConverter()
        {
            _converter = new DateTimeToShortDateTimeStringValueConverter();
        }

        protected override string Convert(DateTime? value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.HasValue ? (string) _converter.Convert(value.Value, targetType, parameter, culture) : null;
        }
    }
}