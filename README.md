## Movies Explorer (Demo App)

This is a simple app for iOS (iPhones/iPads) to showcase some of the goodness of Xamarin.iOS, MvvmCross, and few more open source projects.  


## Main Features

**Clean, Reusable, Cross-Platform Code**

The application was built on top of MvvmCross framework. This made it possible to code all logic in the PCL project and share across multiple platforms. 
Only binding and UI-related code is placed in the viewControllers themselves. This makes it very easy to port this app to Android, Windows Phone etc.

**Azure App Insights for Logging & Tracking**

The app uses ILogger which is an abstract representation of a logging service and it has an implementation of AzureAiLogger, which sends all logging data along with page tracking data to Azure App Insights. Make sure to update Azure Ai Key (in Conig.cs) to your Azure Ai instrumentationKey to get all this data.

**Pull To Refresh / Shake To Refresh**

The app implements the native pull-to-refresh on both tables and collections views. It also listens to device shake and uses that for refresh :) (just for fun)

**Dependency Injection

All dependencies are wired in Setup.cs and App.cs and injected into all entities and viewmodels using Mvvmcross built in IoC Container. 

**Memory Warnings

The device captures memory warnings on all screens and sends them to Azure Ai for better analysis later. 

**Caching Movies Images

Movies images are cached locally using MvvmCross DownloadCache plugin. 

**Async Data Loading

All data and resource intensive processing is done on separate threads using Ms Task Parallel Library to give the user a good experience without blocking the UI thread. 

**Custom Fonts

The application makes use of some puplically available fonts and adds them to the Application resources. These fonts are used for the Page Title as can be seen on the Home Screen and the Favroites list. 

**Handling Exceptions with Retrials

The application handles common exceptions when dealing with data (ie: fetching data from the api) and attempts to self heal by retrying any operation for a maximum number of 3 attempts. This could be very useful when fetching remote resources as the connectivity is not guranteed and resource availability could change in real-time. 

**Universal and Unified Api

The application is built to be a Universal app meaning that it can run on iPhones and iPads and it uses the Unified Api to run on 32 and 64 bits processor acrchitecture. 

**Modern Http Client

The application makes use of the native Http message handlers to speed up the processing of Http messages. This has a proven effect of making processing http requests drastically faster.




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
