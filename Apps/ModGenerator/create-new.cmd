cd "%1/Mods/Product"

cd "./Mod.%2.Models"
dotnet new install .\ --force
cd "../Mod.%2.Interfaces"
dotnet new install .\ --force
cd "../Mod.%2.Services"
dotnet new install .\ --force
cd "../Mod.%2.Root"
dotnet new install .\ --force
cd "../Mod.%2.Base"
dotnet new install .\ --force
