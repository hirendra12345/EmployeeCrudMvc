# Employee CRUD MVC

ASP.NET Core MVC employee-management application using SQL Server and Entity Framework Core.

## Database

The configured database is `EmployeeCrudMvcDb` on `DESKTOP-ST2US9B`. On the first successful application start, `Database.EnsureCreated()` creates the database and `Employees` table automatically.

The connection string is in `appsettings.json`. It uses Windows Authentication (`Integrated Security=True`), so run the app as a Windows user that has permission to create databases on that SQL Server instance.

## Run

```powershell
dotnet restore
dotnet run
```

Open the HTTPS URL printed in the terminal, then visit `/Employees`.

## Run with Docker

Docker Compose runs both the MVC application and a separate SQL Server 2022 container. This does not modify the SQL Server database used by the local Windows run.

```powershell
Copy-Item .env.example .env
# Edit .env and set a strong MSSQL_SA_PASSWORD before starting.
docker compose up --build
```

Open `http://localhost:8080/Employees`. The `EmployeeCrudMvcDb` database is created automatically inside the SQL Server container. Stop the stack with `docker compose down`. Its database data remains in the `sqlserver-data` Docker volume.

To inspect the Docker database through SSMS, connect to `localhost,14333` with SQL Server Authentication, login `sa`, and the password in `.env`.

## Features

- Create, list, view, edit, and delete employees
- Server-side and browser-side validation
- SQL Server database connection
