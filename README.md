# DB SETUP

The DB can be setup via docker, but you if you prefer there is also a sql script with the full db structure and data

## Via Docker

As an example password I am using "TestP@ssW0rd", don't forget to replace it with your desired strong password. You will also have to update it in appsettings.json

- Pull the SQL server image
  `docker pull mcr.microsoft.com/mssql/server:2019-CU3-ubuntu-18.04`

- Make sure to stop any container running in port 1433 as it would conflict with the following command
  `docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=TestP@ssW0rd" -p 1433:1433 --name test-db -d mcr.microsoft.com/mssql/server:2019-CU3-ubuntu-18.04`

- Connect to the container
  docker exec -it test-db "bash"

- Connect locally to the DB
  /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "TestP@ssW0rd"
- Create the DB
  `CREATE DATABASE People GO`

- Close the terminal

- Open a terminal from <path to repository>/src/person-api
  `dotnet ef database update`

## Manually

If you do not want to use docker, you can follow those steps to setup the DB manually

- Import "PersonApiDb.sql" into your SqlServer
- Change the connection string from appsettings.json to point to your SqlServer with your credentials
