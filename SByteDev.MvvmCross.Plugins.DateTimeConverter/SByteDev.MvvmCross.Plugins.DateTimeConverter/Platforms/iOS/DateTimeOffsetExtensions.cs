using System;
using System.Globalization;
using Foundation;

// ReSharper disable once CheckNamespace
namespace SByteDev.MvvmCross.Plugins.DateTimeConverter
{
    [Preserve(AllMembers = true)]
    public static class DateTimeOffsetExtensions
    {
        private static readonly DateTimeOffset ReferenceNsDateTime =
            new DateTimeOffset(2001, 1, 1, 0, 0, 0, TimeSpan.Zero);

        public static NSDate ToNsDate(this DateTimeOffset dateTimeOffset)
        {
            return NSDate.FromTimeIntervalSinceReferenceDate((dateTimeOffset - ReferenceNsDateTime).TotalSeconds);
        }

        public static string ToString(
            this DateTimeOffset dateTimeOffset,
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

            return dateFormatter.StringFor(dateTimeOffset.ToNsDate());
        }

        public static string ToRelativeString(
            this DateTimeOffset dateTimeOffset,
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

            return relativeDateTimeFormatter.GetLocalizedString(dateTimeOffset.ToNsDate(), NSDate.Now);
        }
    }
}