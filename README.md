# GoBHHC
## BHHC Demo App

Application intended to show some basic techniques for writing .Net Core applications in 2019

## Guidelines for the Project
- Write an application that displays three or more reasons that you would like to work for BHHC.  Persist the list of reasons and use any means to display them.
- Show off your in-depth knowledge of a particular subject area or tools.
- We are interested in seeing your use of patterns and best practices in the design and coding techniques.
- We want to see the interaction between logical layers: Presentation, Services, & Persistence
- Feel free to reference specific tools and/or libraries (JQuery, Bootstrap, Kendo UI, AutoMapper, Entity Framework, Dapper, Swagger etc.)
- Comment the code to assist us in understanding it.
- Provide sample automated test cases where appropriate.
- Make sure it is your original work and not the intellectual property of someone else.
- Avoid reposting the sample code from a book, blog, question answer site, or training site.

## Tools
- Visual Studio 2019 Enterprise
- VS Code
- Postman

## Assemblies

### GoBHHC.exe (.Net Core 3.0) - WPF Gui
- Uses MVVM Pattern
- Uses RelayCommand implementation from MS Best Practices

### GoBHHC.Repository.dll (.Net Core 3.0)
- Uses the Repository Pattern
- Uses a Factory to return the Repository
- Uses a SQLite database to maintain data
- Contains a data folder to house the database.  Not something we'd do in production, but adequete for this purpose.
- Contains methods to build the database schema and insert sample data
- Contains basic CRUD operations for List Mgr data 
- Uses Dapper ORM

### GoBHHC.Shared (.Net Standard 2.03)
- Contains global POCO models and interfaces
- Contains Custom Exceptions
- Shared with both views and services applications

### GoBHHC.Tests
- Contains Repository CRUD tests
- Created a list of scripts that can be called from PostMan

### GoBHHC.WebAPI
- WebAPI REST service project
- Uses CORS and allows all origins -- would be bad in production.

### go-bhhc
- Angular project.  Connects to WebAPI project.

<span style="color:red">

## __***************** NOTE *****************__

#### __THIS PROJECT BORROWS LIBERALLY FROM THE angular.io 'TOUR OF HEROES' PROJECT__

</span>

- NOTE: If using Firefox, be sure to disable ad-blockers

## Other Stories / Epics that would be worth doing
- As myself, I would like to optionally use the API for communication from the WPF application so that I can demonstrate N-Tier functionality
- As myself, I would like to implement NLog throughout the application so that I can demonstrate logging patterns
- As myself, I would like to implement better try/catch/finally exception handling throughout the application so that I can gracefully handle, log, and report exceptions to the User
- As myself, I would like to use the new GitHub CI-CD features so that I can execute tests and build on GitHub

- As a User, I would like to refine the test data generated by the repository so the entries are not dumb.
- As a User, I would like to be prompted for a Description when adding a new Item so that every new item isn't initally defined as "New Item"
- As a User, I would like to remove the border from the WPF application and add a custom control box so that it presents better
- As a User, I'd like Swagger documentation so that I have clean, standardized details about the project
- As a User, I'd like the front-end apps to use SignalR or something similar to push changes to the datamodel when changes are made from other interfaces so that each interface is displaying the most up-to-date information.
- As a User, I want to sort columns on the Items grid (WPF) so that I can more easily navigate the data
- As a User, I want to sort columns on the Items grid (Angular) so that I can more easily navigate the data
- As a User, I want to filter columns on the Items grid (WPF) so that I can more easily navigate the data
- As a User, I want to filter columns on the Items grid (Angular) so that I can more easily navigate the data

- As a tester, I want the "Rebuild Database" command exposed through the API so I can wrap that functionality in a test
- As a tester, I would like to enhance the postman script so that it can be run as a suite where each step interacts with one another and I can demonstrate a full unit of work
- As a tester, I would like to improve test coverage to > 80% overall so that I can better ensure quality
- As a Tester, I want to build Protractor or other Javascript tests so that I can ensure quality of the Angular application

- DONE - As myself, I would like an Angular Application that will demonstrate a web appliction that exposes the same interface as the Wpf application and communicates through the API so that I can demonstrate javascript patterns 
- DONE As a User, I want a refresh button on the Wpf app so that I can retrieve the latest information

- BUG - Fix "Search" box on Angular Dashboard