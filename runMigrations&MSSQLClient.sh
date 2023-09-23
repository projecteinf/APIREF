sudo -S sh -c /home/projecteinf/Projectes/EF/Course/dockerRun.bash
rm -r Migrations
dotnet ef migrations add InitialCreate
dotnet ef database update
/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "Passw0rd!"