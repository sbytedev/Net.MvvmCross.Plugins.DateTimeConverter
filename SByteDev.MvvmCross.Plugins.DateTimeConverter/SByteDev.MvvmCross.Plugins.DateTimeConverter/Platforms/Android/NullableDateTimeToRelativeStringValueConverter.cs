using System;
using System.Globalization;
using Android.Runtime;
using MvvmCross.Converters;

// ReSharper disable once CheckNamespace
namespace SByteDev.MvvmCross.Plugins.DateTimeConverter
{
    [Preserve(AllMembers = true)]
    public sealed class NullableDateTimeToRelativeStringValueConverter : MvxValueConverter<DateTime?, string>
    {
        private readonly DateTimeToRelativeStringValueConverter _converter;

        public NullableDateTimeToRelativeStringValueConverter()
        {
            _converter = new DateTimeToRelativeStringValueConverter();
        }

        protected override string Convert(DateTime? value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.HasValue ? (string) _converter.Convert(value.Value, targetType, parameter, culture) : null;
        }
    }
}