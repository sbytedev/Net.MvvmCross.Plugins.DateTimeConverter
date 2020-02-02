# MvvmCross DateTimeConverter Plugin
![GitHub](https://img.shields.io/github/license/SByteDev/Net.MvvmCross.Plugins.DateTimeConverter.svg)
![Nuget](https://img.shields.io/nuget/v/SByteDev.MvvmCross.Plugins.DateTimeConverter.svg)
![Build](https://github.com/SByteDev/Net.MvvmCross.Plugins.DateTimeConverter/workflows/Build/badge.svg)
[![CodeFactor](https://www.codefactor.io/repository/github/sbytedev/net.mvvmcross.plugins.datetimeconverter/badge)](https://www.codefactor.io/repository/github/sbytedev/net.mvvmcross.plugins.datetimeconverter)

Provides a set of native converters to convert DateTime into the user-friendly string.

## Installation

Use [NuGet](https://www.nuget.org) package manager to install this library.

```bash
Install-Package SByteDev.MvvmCross.Plugins.DateTimeConverter
```

## Usage

### iOS
```cs
using SByteDev.MvvmCross.Plugins.DateTimeConverter;

var set = this.CreateBindingSet<View, ViewModel>();
set.Bind(label).To(vm => vm.DateTime).WithConversion<DateTimeToLongDateStringValueConverter>();
set.Bind(label).To(vm => vm.DateTime).WithConversion<DateTimeToLongDateTimeStringValueConverter>();
set.Bind(label).To(vm => vm.DateTime).WithConversion<DateTimeToLongTimeStringValueConverter>();
set.Bind(label).To(vm => vm.DateTime).WithConversion<DateTimeToMediumDateStringValueConverter>();
set.Bind(label).To(vm => vm.DateTime).WithConversion<DateTimeToMediumDateTimeStringValueConverter>();
set.Bind(label).To(vm => vm.DateTime).WithConversion<DateTimeToMediumTimeStringValueConverter>();
set.Bind(label).To(vm => vm.DateTime).WithConversion<DateTimeToShortDateStringValueConverter>();
set.Bind(label).To(vm => vm.DateTime).WithConversion<DateTimeToShortDateTimeStringValueConverter>();
set.Bind(label).To(vm => vm.DateTime).WithConversion<DateTimeToShortTimeStringValueConverter>();
set.Bind(label).To(vm => vm.DateTime).WithConversion<DateTimeToRelativeDateTimeStringValueConverter>();
set.Apply();
```

### Android
```cs
using SByteDev.MvvmCross.Plugins.DateTimeConverter;

var set = this.CreateBindingSet<View, ViewModel>();
set.Bind(textView).To(vm => vm.DateTime).WithConversion<DateTimeToDateStringValueConverter>();
set.Bind(textView).To(vm => vm.DateTime).WithConversion<DateTimeToDateTimeStringValueConverter>();
set.Bind(textView).To(vm => vm.DateTime).WithConversion<DateTimeToTimeStringValueConverter>();
set.Bind(textView).To(vm => vm.DateTime).WithConversion<DateTimeToRelativeStringValueConverter>();
set.Apply();
```

## Implementation

### iOS

Uses [NSDateFormatter](https://developer.apple.com/documentation/foundation/nsdateformatter) and [NSRelativeDateTimeFormatter](https://developer.apple.com/documentation/foundation/nsrelativedatetimeformatter).

### Android

Uses [DateUtils](https://developer.android.com/reference/android/text/format/DateUtils).

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update the tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)
