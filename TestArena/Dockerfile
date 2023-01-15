FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TestArena/TestArena.csproj", "TestArena/"]
RUN dotnet restore "TestArena/TestArena.csproj"
COPY . .
WORKDIR "/src/TestArena"
RUN dotnet build "TestArena.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestArena.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestArena.dll"]
