# Overview
Schoola is a dynamic and user-friendly platform designed to enhance the educational experience for both teachers and students. Built using ASP.NET Core MVC, Entity Framework Core (EF Core), and SQL Server. Schoola offers a robust and secure environment for managing educational content and interactions.

# Getting Started
1. Clone the Repository [https://github.com/raaphat99/Schoola]
2. Install Dependencies: Make sure you have the necessary NuGet packages installed. You can do this by running: dotnet restore
3. Configure the Database: Update the connection string in the appsettings.json file to match your database server settings.
4. Run Migrations: open package manager (ALT + T + N + O) and apply the following commands to migrate the database
  * add-migration "init"
  * update-database
5. Build and Run the Application through "dotnet build" and "dotnet run" commands.

# Features
* Implementing CRUD operations for Student and Course modules.
* Enroll in and view enrolled courses.
* Create new courses with comprehensive descriptions.
* Ensuring secure user login with claims and cookie-based authentication.
* Implementing role-based access control.
* Utilizing Dependency Injection for a loosely-coupled architecture.
* Applying the Repository Pattern.
* Managing user authentication and authorization.
* Implementing server-side validation using EF Core data annotations and custom validators.

# Technologies
* ASP.NET Core MVC
* Entity Framework Core
* LINQ
* SQL Server
* Bootstrap







