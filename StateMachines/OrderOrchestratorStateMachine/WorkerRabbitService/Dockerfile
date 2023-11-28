FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WorkerRabbitService.csproj", "WorkerRabbitService/"]
RUN dotnet restore "WorkerRabbitService/WorkerRabbitService.csproj"

COPY . WorkerRabbitService/.
RUN dotnet publish -c Release -o /app WorkerRabbitService/WorkerRabbitService.csproj 

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS publish
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "WorkerRabbitService.dll"]