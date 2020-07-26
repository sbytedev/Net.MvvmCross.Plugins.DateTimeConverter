# MvvmCross DateTimeConverter Plugin
![GitHub](https://img.shields.io/github/license/SByteDev/Net.MvvmCross.Plugins.DateTimeConverter.svg)
![Nuget](https://img.shields.io/nuget/v/SByteDev.MvvmCross.Plugins.DateTimeConverter.svg)
[![Build Status](https://img.shields.io/bitrise/b62b309e79a29ee2/develop?label=development&token=7oM1s14zyBM50y3dIqO15Q&branch)](https://app.bitrise.io/app/b62b309e79a29ee2)
[![Build Status](https://img.shields.io/bitrise/b62b309e79a29ee2/master?label=production&token=7oM1s14zyBM50y3dIqO15Q&branch)](https://app.bitrise.io/app/b62b309e79a29ee2)
[![CodeFactor](https://www.codefactor.io/repository/github/sbytedev/net.mvvmcross.plugins.datetimeconverter/badge)](https://www.codefactor.io/repository/github/sbytedev/net.mvvmcross.plugins.datetimeconverter)

Provides a set of native converters to convert DateTime into the user-friendly string.

## Installation

Use [NuGet](https://www.nuget.org) package manager to install this library.

```bash
Install-Package SByteDev.MvvmCross.Plugins.DateTimeConverter
```

## Usage
```cs
using SByteDev.MvvmCross.Plugins.DateTimeConverter;
```

### iOS
|Converter|Output|
|---------|------|
|DateTimeToLongDateString|Feb 3, 2020|
|DateTimeToLongDateTimeString|Feb 3, 2020 at 6:30:10 PM GMT+3|
|DateTimeToLongTimeString|6:30:10 PM GMT+3|
|DateTimeToMediumDateString|Feb 3, 2020|
|DateTimeToMediumDateTimeString|Feb 3, 2020 at 6:30:10 PM|
|DateTimeToMediumTimeString|6:30:10 PM|
|DateTimeToShortDateString|2/3/20|
|DateTimeToShortDateTimeString|2/3/20, 6:30 PM|
|DateTimeToShortTimeString|6:30 PM|
|DateTimeToRelativeDateTimeString|now,last week, etc.|

### Android
|Converter|Output|
|---------|------|
|DateTimeToDateString|February 3|
|DateTimeToDateTimeString|February 3, 6:30 PM|
|DateTimeToTimeString|6:30 PM|
|DateTimeToRelativeString|May 11, 2020|

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
