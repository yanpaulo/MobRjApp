# MOBRJ App
Implementation for the app as described at http://ysft.me/mobrj-pdf

## Installation instructions
### Android
The Android version can be installed directly from the Play Store using the following link:
https://play.google.com/apps/internaltest/4698280741030926505

Alternatively, you can download and install the .apk package from the following link:
http://ysft.me/mobrj-apk


### UWP
The UWP version can be installed directly from the Microsoft Store using the following link:
https://www.microsoft.com/store/r/9N8T6KNCTKX4

### iOS
There isn't a precompiled iOS version available at this moment.

## Implementation details
### Libraries
The app was implemented using Xamarin.Forms 3.4 and the following third-party libraries:

[sqlite-net-pcl](https://www.nuget.org/packages/sqlite-net-pcl/) for local database access

[RestHttpClient](https://www.nuget.org/packages/RestHttpClient/) for easy REST API access

### Architecture
Hybrid MVVM/MVP architecture without 3rd party MVVM frameworks or libraries.
ObservableObject implements INotifyPropertyChanged and exposes methods that facilitate the implementation of the MVVM pattern.

BusyObject inherits from ObservableObject and enables the internal IBusy pattern.

The IBusy pattern enables a clean way to notify the UI about running tasks. If used in conjunction with the BusyIndicator control, an ActivityIndicator will be displayed to the user whenever there is some task running.

Usage example. The following snippet will display the BusyIndicator control for 2 seconds:

`C#`
```cs
public async Task LoadAsync()
{
    //
    using (BusyState()) //BusyIndicator is displayed
    {
        States = await Task.Delay(2000);
    } //BusyIndicator is hidden
}
```
`XAML`
```xml
<c:BusyIndicator></c:BusyIndicator>
```
