using System;
using Android.App;
using Android.Runtime;
using Android.Text.Format;
using Java.Lang;

// ReSharper disable once CheckNamespace
namespace SByteDev.MvvmCross.Plugins.DateTimeConverter
{
    [Preserve(AllMembers = true)]
    public static class DateTimeExtensions
    {
        public static long ToUnixEpochMilliseconds(this DateTime dateTime)
        {
            return (long) dateTime.ToUniversalTime().Subtract(DateTime.UnixEpoch).TotalMilliseconds;
        }

        public static string ToString(this DateTime dateTime, FormatStyleFlags formatStyleFlags)
        {
            return DateUtils.FormatDateTime(
                Application.Context,
                dateTime.ToUnixEpochMilliseconds(),
                formatStyleFlags
            );
        }

        public static string ToRelativeString(this DateTime dateTime, TimeSpan minimumResolution)
        {
            return DateUtils.GetRelativeTimeSpanString(
                dateTime.ToUnixEpochMilliseconds(),
                JavaSystem.CurrentTimeMillis(),
                (long) minimumResolution.TotalMilliseconds
            );
        }
    }
}