using System;
using System.Globalization;
using Foundation;

// ReSharper disable once CheckNamespace
namespace SByteDev.MvvmCross.Plugins.DateTimeConverter
{
    public static class CultureInfoExtensions
    {
        public static NSLocale ToLocale(this CultureInfo cultureInfo)
        {
            if (cultureInfo == null)
            {
                throw new ArgumentNullException(nameof(cultureInfo));
            }

            return new NSLocale(cultureInfo.Name.Replace("-", "_"));
        }
    }
}