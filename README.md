# PERSON API

This API allows you to add, search and get by id your employees.
It is build in dotnet core 3.1 and uses Entity Framework.
The tests are using xUnit.
Follow this readme to setup the project and run it from your machine.
Note: this was only tested on a Windows machine, but it should work the same way on Mac.

## PREREQUISITE

- [ASP.NET Core Runtime 3.1.x](https://dotnet.microsoft.com/download/dotnet-core/3.1)
- [Docker](https://www.docker.com/products/docker-desktop) or [SSMS](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)

## DB SETUP

The DB can be setup in 3 different ways:

- via docker,
- using your own SQL server and running the migrations
- importing the included sql script into your own SQL server

### Via Docker

As an example password I am using "TestP@ssW0rd", don't forget to replace it with your desired strong password. You will also have to update it in appsettings.json

- Pull the SQL server image
  `docker pull mcr.microsoft.com/mssql/server:2019-CU3-ubuntu-18.04`

- Make sure to stop any container running in port 1433 as it would conflict with the following command
  `docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=TestP@ssW0rd" -p 1433:1433 --name test-db -d mcr.microsoft.com/mssql/server:2019-CU3-ubuntu-18.04`

- Connect to the container
  `docker exec -it test-db "bash"`

- Connect locally to the DB
  `/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "TestP@ssW0rd"`

- Create the DB
  `CREATE DATABASE People GO`

- Close the terminal

- Open a terminal from <path to repository>/src/person-api
  `dotnet ef database update`

### Using your own DB and migrations

If you do not want to use docker, you can run the migrations against your own database to create the tables

- In your favorite SQL management tool, create a new DB
  `CREATE DATABASE People GO`

- Change the connection string from appsettings.json to point to your SqlServer with your credentials

- Open a terminal from <path to repository>/src/person-api
  `dotnet ef database update`

### Using SQL script file

If you do not want to use migrations, you can follow those steps to setup the DB using the provided SQL script.
Note: You will need the latest version of SSMS installed to run the SQL script.

- Import "PersonApiDb.sql" into your SqlServer
- Change the connection string from appsettings.json to point to your SqlServer with your credentials

## RUN THE PROJECT

- Open a terminal from <path to repository>/src/person-api
  `dotnet run`
  The API will be accessible in the following address: http://localhost:5000
  To test that the API is able to access the DB correctly, navigate to http://localhost:5000/status/health you should see "Healthy"
