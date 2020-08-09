using System;
using System.Globalization;
using Android.Runtime;
using MvvmCross.Converters;

// ReSharper disable once CheckNamespace
namespace SByteDev.MvvmCross.Plugins.DateTimeConverter
{
    [Preserve(AllMembers = true)]
    public sealed class NullableDateTimeOffsetToTimeStringValueConverter : MvxValueConverter<DateTimeOffset?, string>
    {
        private readonly DateTimeOffsetToTimeStringValueConverter _converter;

        public NullableDateTimeOffsetToTimeStringValueConverter()
        {
            _converter = new DateTimeOffsetToTimeStringValueConverter();
        }

        protected override string Convert(DateTimeOffset? value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.HasValue ? (string) _converter.Convert(value.Value, targetType, parameter, culture) : null;
        }
    }
}