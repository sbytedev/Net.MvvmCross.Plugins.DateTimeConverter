using System;
using System.Globalization;
using Foundation;
using MvvmCross.Converters;

// ReSharper disable once CheckNamespace
namespace SByteDev.MvvmCross.Plugins.DateTimeConverter
{
    [Preserve(AllMembers = true)]
    public sealed class NullableDateTimeToRelativeDateTimeStringValueConverter : MvxValueConverter<DateTime?, string>
    {
        public static NSRelativeDateTimeFormatterStyle DefaultDateTimeStyle { get; set; } =
            NSRelativeDateTimeFormatterStyle.Named;

        public static NSRelativeDateTimeFormatterUnitsStyle DefaultUnitsStyle { get; set; } =
            NSRelativeDateTimeFormatterUnitsStyle.Full;

        private readonly DateTimeToRelativeDateTimeStringValueConverter _converter;

        public NullableDateTimeToRelativeDateTimeStringValueConverter()
        {
            _converter = new DateTimeToRelativeDateTimeStringValueConverter(DefaultDateTimeStyle, DefaultUnitsStyle);
        }

        public NullableDateTimeToRelativeDateTimeStringValueConverter(
            NSRelativeDateTimeFormatterStyle dateTimeStyle,
            NSRelativeDateTimeFormatterUnitsStyle unitsStyle
        )
        {
            _converter = new DateTimeToRelativeDateTimeStringValueConverter(dateTimeStyle, unitsStyle);
        }

        protected override string Convert(DateTime? value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.HasValue ? (string) _converter.Convert(value.Value, targetType, parameter, culture) : null;
        }
    }
}