using System;
using System.Globalization;
using Foundation;
using MvvmCross.Converters;

// ReSharper disable once CheckNamespace
namespace SByteDev.MvvmCross.Plugins.DateTimeConverter
{
    [Preserve(AllMembers = true)]
    public sealed class NullableDateTimeToMediumDateTimeStringValueConverter : MvxValueConverter<DateTime?, string>
    {
        private readonly DateTimeToMediumDateTimeStringValueConverter _converter;

        public NullableDateTimeToMediumDateTimeStringValueConverter()
        {
            _converter = new DateTimeToMediumDateTimeStringValueConverter();
        }

        protected override string Convert(DateTime? value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.HasValue ? (string) _converter.Convert(value.Value, targetType, parameter, culture) : null;
        }
    }
}