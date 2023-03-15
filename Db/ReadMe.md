dotnet ef migrations add Initial  --startup-project ../ProductWebAPI/ProductWebAPI.csproj

docker run --name some-postgres -e POSTGRES_PASSWORD=postgres -e POSTGRES_USER=postgres -d -p 5432:5432 postgres

dotnet ef database update --startup-project ../ProductWebAPI/ProductWebAPI.csproj