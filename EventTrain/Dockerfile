FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EventTrain/EventTrain.csproj", "EventTrain/"]
RUN dotnet restore "EventTrain/EventTrain.csproj"
COPY . .
WORKDIR "/src/EventTrain"
RUN dotnet build "EventTrain.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EventTrain.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EventTrain.dll"]
