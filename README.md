# AreaGeode

Area code geolocation library and service.

An AreaGeode provides geolocation data based on a telephone area code.  Support is provided for
US and Canada area codes. 

This is handy for things such as:

* Given a phone number, get a rough idea of where it is located
* Given a phone number, get the state or province where it is located
* Given a state or province, get a list of the area codes
* Given a city, get a list of the area codes

The database comes from the https://github.com/ravisorg/Area-Code-Geolocation-Database
github repository.


## AreaGeode.Library

A .NET Core library that implements the AreaGeode functionality and can be incorporated directly
into a project.

## AreaGeode.API

A .NET Core WebAPI that can be used as a service for performing AreaGeode lookups that just
puts an API front end on the library.

The API requires an appsettings.json with a functional connection string. The file 
sample.appsettings.json is provided as a template.

## Data Access Layer

The data access layer is implemented using Dapper to SQL Server. The DAL is read-only, which
fulfills the needs of the API.

## Swagger

Swagger is integrated using Swashbuckle and accessible at /swagger

## Other Notes

This is a simple .NET Core WebAPI and class library developed with the purpose of getting familiar
with the differences between .NET Core and traditional .NET Framework development of web services.  As such,
some of the design decisions (ex. using SQL Server for the database) don't make a lot of sense, but serve
my purposes.

Developed in Visual Studio 2017 but also currently works in Visual Studio Code on Windows 10 and macOS.