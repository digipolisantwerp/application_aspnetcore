# ApplicationServices Library

Application services for ASP.NET Core applications.

## Table of Contents

<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->


- [Installation](#installation)
- [Startup](#startup)
- [IApplicationContext](#iapplicationcontext)
  - [Instance](#instance)
- [Application API](#application-api)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->


## Installation

This package is hosted on Myget on the following feed : [https://www.myget.org/F/digipolisantwerp/api/v3/index.json](https://www.myget.org/F/digipolisantwerp/api/v3/index.json).  
To add it to a project, you add the package to the project.json :

``` json 
"dependencies": {
    "Digipolis.ApplicationServices":  "1.0.0"
 }
``` 

In Visual Studio you can also use the NuGet Package Manager to do this.

## Startup

To use the library's services, you add them in the **Configure** method of the Startup class :

```csharp
services.AddApplicationServices(options => {
    options.ApplicationId = "a0eab541-0f09-4540-abbf-88cc1fe02a90";
    options.ApplicationName = "MyApplication";
});
```  

## IApplicationContext

You can inject the IApplicationContext in your objects to have access to the application's identification. The context provides the following properties :

- ApplicationId : the application's unique id (given in the startup options).
- ApplicationName : the application's (friendly) name (given in the startup options).
- InstanceId : the unique id of the application's running instance (is generated at startup).
- InstanceName : the name of the application's running instance (is generated at startup).
- ApplicationVersion : the application's version.
- InternalApplicationName : the application's internal name (the name of the .NET Core project).


### Instance

In a load-balanced, scalable environment, you will run several instances of the same application. The instance properties can be used to identify each 
instance of this application (e.g. in logs).

## Application API

__coming soon__.