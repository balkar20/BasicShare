dotnet ef migrations add Initial  --startup-project ../IdentityProvider/Server/IdentityProvider.Server.csproj

docker run --name some-postgres -e POSTGRES_PASSWORD=postgres -e POSTGRES_USER=postgres -d -p 5432:5432 postgres

dotnet ef database update --startup-project ../IdentityProvider/Server/IdentityProvider.Server.csproj
dotnet ef database update --connection "Host=localhost;Database=sadb;Port=5432;User Id=postgres;Password=postgres" --startup-project ../IdentityProvider/Server/IdentityProvider.Server.csproj
