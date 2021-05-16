using System;
using System.Globalization;
using Foundation;
using MvvmCross.Converters;

// ReSharper disable once CheckNamespace
namespace SByteDev.MvvmCross.Plugins.DateTimeConverter
{
    [Preserve(AllMembers = true)]
    public sealed class DateTimeToRelativeDateTimeStringValueConverter : MvxValueConverter<DateTime, string>
    {
        public static NSRelativeDateTimeFormatterStyle DefaultDateTimeStyle { get; set; } =
            NSRelativeDateTimeFormatterStyle.Named;

        public static NSRelativeDateTimeFormatterUnitsStyle DefaultUnitsStyle { get; set; } =
            NSRelativeDateTimeFormatterUnitsStyle.Full;

        private readonly NSRelativeDateTimeFormatterStyle _dateTimeStyle;
        private readonly NSRelativeDateTimeFormatterUnitsStyle _unitsStyle;

        public DateTimeToRelativeDateTimeStringValueConverter()
        {
            _dateTimeStyle = DefaultDateTimeStyle;
            _unitsStyle = DefaultUnitsStyle;
        }

        public DateTimeToRelativeDateTimeStringValueConverter(
            NSRelativeDateTimeFormatterStyle dateTimeStyle,
            NSRelativeDateTimeFormatterUnitsStyle unitsStyle
        )
        {
            _dateTimeStyle = dateTimeStyle;
            _unitsStyle = unitsStyle;
        }

        protected override string Convert(DateTime value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToRelativeString(culture, _dateTimeStyle, _unitsStyle);
        }
    }
}