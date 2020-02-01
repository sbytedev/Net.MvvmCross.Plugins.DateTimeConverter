using System;
using System.Globalization;
using Android.Runtime;
using MvvmCross.Converters;

// ReSharper disable once CheckNamespace
namespace SByteDev.MvvmCross.Plugins.DateTimeConverter
{
    [Preserve(AllMembers = true)]
    public sealed class DateTimeToRelativeStringValueConverter : MvxValueConverter<DateTime, string>
    {
        protected override string Convert(DateTime value, Type targetType, object parameter, CultureInfo culture)
        {
            var duration = (DateTime.UtcNow - value.ToUniversalTime()).Duration();
            
            return value.ToRelativeString(duration);

            if (duration < TimeSpan.FromMinutes(1))
            {
                return value.ToRelativeString(TimeSpan.FromSeconds(1));
            }
            
            if (duration < TimeSpan.FromHours(1))
            {
                return value.ToRelativeString(TimeSpan.FromMinutes(1));
            }
            
            if (duration < TimeSpan.FromDays(1))
            {
                return value.ToRelativeString(TimeSpan.FromHours(1));
            }
            
            if (duration < TimeSpan.FromDays(7))
            {
                return value.ToRelativeString(TimeSpan.FromDays(1));
            }

            return value.ToRelativeString(TimeSpan.FromDays(7));
        }
    }
}