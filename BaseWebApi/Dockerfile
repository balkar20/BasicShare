FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 7031

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BaseWebApi/BaseWebApi.csproj", "BaseWebApi/"]
COPY ["Mod.Order.Base/Mod.Order.Base.csproj", "Mod.Order.Base/"]
COPY ["Core.Base/Core.Base.csproj", "Core.Base/"]
COPY ["Mod.Order.Interfaces/Mod.Order.Interfaces.csproj", "Mod.Order.Interfaces/"]
COPY ["Db/Db.csproj", "Db/"]
COPY ["Interfaces/Interfaces.csproj", "Interfaces/"]
COPY ["Mod.Order.Models/Mod.Order.Models.csproj", "Mod.Order.Models/"]
COPY ["Mod.Order.Services/Mod.Order.Services.csproj", "Mod.Order.Services/"]
COPY ["Services/Services.csproj", "Services/"]
COPY ["Mod.Product.Base/Mod.Product.Base.csproj", "Mod.Product.Base/"]
COPY ["Mod.Product.Interfaces/Mod.Product.Interfaces.csproj", "Mod.Product.Interfaces/"]
COPY ["ModProduct.Models/ModProduct.Models.csproj", "ModProduct.Models/"]
COPY ["Mod.Pricing.Models/Mod.Pricing.Models.csproj", "Mod.Pricing.Models/"]
COPY ["Mod.Product.Services/Mod.Product.Services.csproj", "Mod.Product.Services/"]
RUN dotnet restore "BaseWebApi/BaseWebApi.csproj"
COPY . .
WORKDIR "/src/BaseWebApi"
RUN dotnet build "BaseWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BaseWebApi.csproj" -c Release -o /app/publish

ENV ASPNETCORE_URLS=http://+:7031;
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BaseWebApi.dll"]
