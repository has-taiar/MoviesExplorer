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


**Dependency Injection**

All dependencies are wired in Setup.cs and App.cs and injected into all entities and viewmodels using Mvvmcross built in IoC Container. 


**Memory Warnings**

The device captures memory warnings on all screens and sends them to Azure Ai for better analysis later. 


**Caching Movies Images**

Movies images are cached locally using MvvmCross DownloadCache plugin. 


**Async Data Loading**

All data and resource intensive processing is done on separate threads using Ms Task Parallel Library to give the user a good experience without blocking the UI thread. 


**Custom Fonts**

The application makes use of some puplically available fonts and adds them to the Application resources. These fonts are used for the Page Title as can be seen on the Home Screen and the Favroites list. 


**Handling Exceptions with Retrials**

The application handles common exceptions when dealing with data (ie: fetching data from the api) and attempts to self heal by retrying any operation for a maximum number of 3 attempts. This could be very useful when fetching remote resources as the connectivity is not guranteed and resource availability could change in real-time. 


**Universal and Unified Api**

The application is built to be a Universal app meaning that it can run on iPhones and iPads and it uses the Unified Api to run on 32 and 64 bits processor acrchitecture. 


**Modern Http Client**

The application makes use of the native Http message handlers to speed up the processing of Http messages. This has a proven effect of making processing http requests drastically faster.


**Use of AutoMapper**

The application uses AutoMapper to map Dto objects from the api to our application models. This makes it extremely easy to maintain the code that maps these entities. 


**Implementation of IDatabase**

IDatabase is an abstraction of a local database. This is used to hide the specific implementation from our PCL code. The application makes use of SQLite.Net-PCL for handling the platform-specific impelementation and provides a generic Database class that is injected into all repositories to make it very easy to do any CURD operations on the database in an ORM fashion. 



## Limitations

**Adaptive Layout**

Some aspects of the screens need a little more work to make them adapt properly to the different screensizes (ie iPads and Landscape mode).


**Testing**

Although the application has a good number of tests, the test coverage can be improved by adding more unit, integration and UI tests. 


## List of Used OpenSource Libraries

* [MvvmCross](http://www.mvvmcross.com/).
* [MvvmCross Messenger](https://www.nuget.org/packages/MvvmCross.Plugin.Messenger/).
* [MvvmCross DownloadCache](https://www.nuget.org/packages/MvvmCross.ITSparta.Plugin.DownloadCache/).
* [MvvmCross UserInteraction](https://www.nuget.org/packages/Chance.MvvmCross.Plugins.UserInteraction/).
* [SQLite.Net-PCL](https://www.nuget.org/packages/SQLite.Net-PCL/).
* [DeviceInfo](https://www.nuget.org/packages/Xam.Plugin.DeviceInfo/).
* [AutoMapper](https://www.nuget.org/packages/AutoMapper/).
* [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/).
* [NUnit](https://www.nuget.org/packages/NUnit/).
* [Moq](https://www.nuget.org/packages/Moq/).
* [ModernHttpClient](https://www.nuget.org/packages/modernhttpclient/).
* [PDReview](https://components.xamarin.com/view/pdreview/).
* [Azure App Insights Bindings](https://github.com/Microsoft/ApplicationInsights-Xamarin).



### Licensing

This project and all my contributions here are made publically available under [MIT License](https://opensource.org/licenses/MIT). This does not extend to projects and libraries that I have used and I respect their owners IP and Licenses. 


### Comments and Questions

All comments and/or questions are welcome. Head of to my personal blog [HasAlTaiar.com.au](https://HasAlTaiar.com.au) for more info, or tag me in your tweet on @hasaltaiar 
