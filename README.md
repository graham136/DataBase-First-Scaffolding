# DataBase-First-Scaffolding

1. Create a database in Microsoft SQL Server
	Right Click on new Query

	Create Database TestDB
	Go

2. Create a new table in TestDB
	CREATE TABLE [dbo].[Suspension](
    	[id] [int] IDENTITY(1,1) Primary Key,
    	[name] [varchar](1000) NULL
	) ON [PRIMARY]

3. Create a new project asp.net core web project with visual studio 2019
4. Connect to your database in the server object explorer
5. select menu Tools -> NuGet Package Manger -> Package Manger Console and run the following commands

	Install-Package Microsoft.EntityFrameworkCore.Tools 
	Install-Package Microsoft.EntityFrameworkCore.SqlServer 

	Scaffold-DbContext "Server=DESKTOP-7D5S0MF;Database=TestDB;Trusted_Connection=True;" 	Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
6. Make sure you edit your models and specify the [Key] attribute above the Primary key.
7. Right Click on controllers folder
8. Click add new scaffolded item
9. Click MVC Controller with views, using Entity Framework
10. Select your model class and DBcontext. Name your controller.
11. Add this line to your _Layout.shtml in the shard folder to access the constroller
	<li class="nav-item">
        	<a class="nav-link text-dark" asp-area="" asp-controller="Suspensions" asp-action="">Suspensions</a>
        </li>
12. Register your DBContext in your startup.cs as a service
	services.AddDbContext<TestDBContext>(opts => opts.UseSqlServer(Configuration["ConnectionStrings:TestDB"]));
13. Add your database connection string to
	 "ConnectionStrings": { "TestDB": "Server=DESKTOP-7D5S0MF;Database=TestDB;Trusted_Connection=True;" }
