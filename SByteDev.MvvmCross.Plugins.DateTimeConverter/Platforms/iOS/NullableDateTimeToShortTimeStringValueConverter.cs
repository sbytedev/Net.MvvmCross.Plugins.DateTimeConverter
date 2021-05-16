using System;
using System.Globalization;
using Foundation;
using MvvmCross.Converters;

// ReSharper disable once CheckNamespace
namespace SByteDev.MvvmCross.Plugins.DateTimeConverter
{
    [Preserve(AllMembers = true)]
    public sealed class NullableDateTimeToShortTimeStringValueConverter : MvxValueConverter<DateTime?, string>
    {
        private readonly DateTimeToShortTimeStringValueConverter _converter;

        public NullableDateTimeToShortTimeStringValueConverter()
        {
            _converter = new DateTimeToShortTimeStringValueConverter();
        }

        protected override string Convert(DateTime? value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.HasValue ? (string) _converter.Convert(value.Value, targetType, parameter, culture) : null;
        }
    }
}