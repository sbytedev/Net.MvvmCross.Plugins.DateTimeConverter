using System;
using System.Globalization;
using Android.Runtime;
using MvvmCross.Converters;

// ReSharper disable once CheckNamespace
namespace SByteDev.MvvmCross.Plugins.DateTimeConverter
{
    [Preserve(AllMembers = true)]
    public sealed class NullableDateTimeOffsetToDateTimeStringValueConverter : MvxValueConverter<DateTimeOffset?, string>
    {
        private readonly DateTimeOffsetToDateTimeStringValueConverter _converter;

        public NullableDateTimeOffsetToDateTimeStringValueConverter()
        {
            _converter = new DateTimeOffsetToDateTimeStringValueConverter();
        }

        protected override string Convert(DateTimeOffset? value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.HasValue ? (string) _converter.Convert(value.Value, targetType, parameter, culture) : null;
        }
    }
}