using System;
using Android.App;
using Android.Runtime;
using Android.Text.Format;
using Java.Lang;

// ReSharper disable once CheckNamespace
namespace SByteDev.MvvmCross.Plugins.DateTimeConverter
{
    [Preserve(AllMembers = true)]
    public static class DateTimeOffsetExtensions
    {
        public static long ToUnixEpochMilliseconds(this DateTimeOffset dateTimeOffset)
        {
            return (long) dateTimeOffset.ToUniversalTime().Subtract(DateTimeOffset.UnixEpoch).TotalMilliseconds;
        }

        public static string ToString(this DateTimeOffset dateTimeOffset, FormatStyleFlags formatStyleFlags)
        {
            return DateUtils.FormatDateTime(
                Application.Context,
                dateTimeOffset.ToUnixEpochMilliseconds(),
                formatStyleFlags
            );
        }

        public static string ToRelativeString(this DateTimeOffset dateTimeOffset, TimeSpan minimumResolution)
        {
            return DateUtils.GetRelativeTimeSpanString(
                dateTimeOffset.ToUnixEpochMilliseconds(),
                JavaSystem.CurrentTimeMillis(),
                (long) minimumResolution.TotalMilliseconds
            );
        }
    }
}