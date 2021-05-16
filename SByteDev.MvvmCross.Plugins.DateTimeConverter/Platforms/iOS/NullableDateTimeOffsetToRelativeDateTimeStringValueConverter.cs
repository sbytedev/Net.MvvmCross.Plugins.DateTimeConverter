using System;
using System.Globalization;
using Foundation;
using MvvmCross.Converters;

// ReSharper disable once CheckNamespace
namespace SByteDev.MvvmCross.Plugins.DateTimeConverter
{
    [Preserve(AllMembers = true)]
    public sealed class NullableDateTimeOffsetToRelativeDateTimeStringValueConverter : MvxValueConverter<DateTimeOffset?, string>
    {
        public static NSRelativeDateTimeFormatterStyle DefaultDateTimeStyle { get; set; } =
            NSRelativeDateTimeFormatterStyle.Named;

        public static NSRelativeDateTimeFormatterUnitsStyle DefaultUnitsStyle { get; set; } =
            NSRelativeDateTimeFormatterUnitsStyle.Full;

        private readonly DateTimeOffsetToRelativeDateTimeStringValueConverter _converter;

        public NullableDateTimeOffsetToRelativeDateTimeStringValueConverter()
        {
            _converter = new DateTimeOffsetToRelativeDateTimeStringValueConverter(DefaultDateTimeStyle, DefaultUnitsStyle);
        }

        public NullableDateTimeOffsetToRelativeDateTimeStringValueConverter(
            NSRelativeDateTimeFormatterStyle dateTimeStyle,
            NSRelativeDateTimeFormatterUnitsStyle unitsStyle
        )
        {
            _converter = new DateTimeOffsetToRelativeDateTimeStringValueConverter(dateTimeStyle, unitsStyle);
        }

        protected override string Convert(DateTimeOffset? value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.HasValue ? (string) _converter.Convert(value.Value, targetType, parameter, culture) : null;
        }
    }
}