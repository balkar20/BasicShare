cd "%1/Mods/Product"

cd "./Mod.Product.Models"
dotnet new install .\ --force
cd "../Mod.Product.Interfaces"
dotnet new install .\ --force
cd "../Mod.Product.Services"
dotnet new install .\ --force
cd "../Mod.Product.Root"
dotnet new install .\ --force
cd "../Mod.Product.Base"
dotnet new install .\ --force
