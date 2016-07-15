# FrameworkEssentials
a nuget package with some utlities &amp; services I use in my projects

This packages contains utilities which I use in my projects.
The package may be changed radically at any time. Even some API's may be altered (although unlikely), be careful with updating.

Attributes: 
 - DescriptionAttribute

DebugTools:
 - StoppWatch
 
Logging:
 - Logging implementation
 
Services:
 - HttpService for basic http request
 - ProgressService for progress reporting and for binding in the view as it implements IPropertyChanged
 - RestService for REST http request
 - Interfaces for all services for IoC
 
Helpers
 - ReflectionHelper
 - BaseHelper
 
Singleton
 - a pattern to guarantee only one instance of class exists application wide. 