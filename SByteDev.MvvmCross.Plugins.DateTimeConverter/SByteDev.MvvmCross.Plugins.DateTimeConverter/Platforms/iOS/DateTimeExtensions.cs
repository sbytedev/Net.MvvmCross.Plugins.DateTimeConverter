using System;
using System.Globalization;
using Foundation;
using MvvmCross.Platforms.Ios;

// ReSharper disable once CheckNamespace
namespace SByteDev.MvvmCross.Plugins.DateTimeConverter
{
    [Preserve(AllMembers = true)]
    public static class DateTimeExtensions
    {
        public static string ToString(
            this DateTime dateTime,
            CultureInfo cultureInfo,
            NSDateFormatterStyle dateStyle,
            NSDateFormatterStyle timeStyle
        )
        {
            if (cultureInfo == null)
            {
                throw new ArgumentNullException(nameof(cultureInfo));
            }

            var dateFormatter = new NSDateFormatter
            {
                DateStyle = dateStyle,
                TimeStyle = timeStyle,
                FormattingContext = NSFormattingContext.Standalone,
                Locale = cultureInfo.ToLocale()
            };

            return dateFormatter.StringFor(dateTime.ToNSDate());
        }

        public static string ToRelativeString(
            this DateTime dateTime,
            CultureInfo cultureInfo,
            NSRelativeDateTimeFormatterStyle dateTimeStyle,
            NSRelativeDateTimeFormatterUnitsStyle unitsStyle
        )
        {
            if (cultureInfo == null)
            {
                throw new ArgumentNullException(nameof(cultureInfo));
            }

            var relativeDateTimeFormatter = new NSRelativeDateTimeFormatter
            {
                DateTimeStyle = dateTimeStyle,
                UnitsStyle = unitsStyle,
                FormattingContext = NSFormattingContext.Standalone,
                Locale = cultureInfo.ToLocale()
            };

            return relativeDateTimeFormatter.GetLocalizedString(dateTime.ToNSDate(), NSDate.Now);
        }
    }
}