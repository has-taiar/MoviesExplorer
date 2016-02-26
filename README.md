## Movies Explorer (Demo App)

This is a simple app for iOS (iPhones/iPads) to showcase some of the goodness of Xamarin.iOS, MvvmCross, and few more open source projects.  


## Main Features

**Clean, Reusable, Cross-Platform Code**
The application was built on top of MvvmCross framework. This made it possible to code all logic in the PCL project and share across multiple platforms. 
Only binding and UI-related code is placed in the viewControllers themselves. This makes it very easy to port this app to Android, Windows Phone etc.

**Azure App Insights for Logging & Tracking**
The app uses ILogger which is an abstract representation of a logging service and it has an implementation of AzureAiLogger, which sends all logging data along with page tracking data to Azure App Insights. Make sure to update Azure Ai Key (in Conig.cs) to your Azure Ai instrumentationKey to get all this data.

**Adaptive Layout**
Some aspects of the screens need a little more work to make them adapt properly to the different screensizes (ie iPads and Landscape mode).



## Limitations

**Adaptive Layout**
Some aspects of the screens need a little more work to make them adapt properly to the different screensizes (ie iPads and Landscape mode).
**Testing**
Although the application has a good number of tests, the test coverage can be improved by adding more unit, integration and UI tests. 


## List of Used Libraries

* [MvvmCross](http://www.mvvmcross.com/).
* [MvvmCross](http://www.mvvmcross.com/).
* [MvvmCross](http://www.mvvmcross.com/).
* [MvvmCross](http://www.mvvmcross.com/).
* [MvvmCross](http://www.mvvmcross.com/).
* [MvvmCross](http://www.mvvmcross.com/).
