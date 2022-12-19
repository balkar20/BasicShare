#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BaseWebApi/BaseWebApi.csproj", "BaseWebApi/"]
COPY ["Mod.Shipment.Base/Mod.Shipment.Base.csproj", "Mod.Shipment.Base/"]
COPY ["Core.Base/Core.Base.csproj", "Core.Base/"]
COPY ["Mod.Shipment.Interfaces/Mod.Shipment.Interfaces.csproj", "Mod.Shipment.Interfaces/"]
COPY ["Interfaces/Interfaces.csproj", "Interfaces/"]
COPY ["Mod.Shipment.Models/Mod.Shipment.Models.csproj", "Mod.Shipment.Models/"]
COPY ["Mod.Shipment.Services/Mod.Shipment.Services.csproj", "Mod.Shipment.Services/"]
COPY ["Services/Services.csproj", "Services/"]
COPY ["Db/Db.csproj", "Db/"]
RUN dotnet restore "BaseWebApi/BaseWebApi.csproj"
COPY . .
WORKDIR "/src/BaseWebApi"
RUN dotnet build "BaseWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BaseWebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BaseWebApi.dll"]