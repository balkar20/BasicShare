
To run postgres in docker you can type in console :
docker run --name some-postgres -e POSTGRES_PASSWORD=postgres -e POSTGRES_USER=postgres -d -p 5432:5432 postgres

1)You can check connectionString in appSettings.Json
2)Type in console : 
dotnet ef migrations add Initial
3)To Update database Type in console:  
dotnet ef database update
