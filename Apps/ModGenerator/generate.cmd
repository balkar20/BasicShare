cd "%1\Mods"

md %2

cd ./%2

set modspathvar = "%1\Mods"
@REM set currentmodspathvar = %cd%
set currentmodpathvar = "%1\Mods\%2"

dotnet new modproductbase -o "Mod.%2.Base" -c %2
cd %1
dotnet sln add "Mods/%2/Mod.%2.Base/Mod.%2.Base.csproj"

cd %currentmodpathvar %
dotnet new modproductroot -o "Mod.%2.Root" -c %2
cd %1
dotnet sln add "Mods/%2/Mod.%2.Root/Mod.%2.Root.csproj"

cd %currentmodpathvar %
dotnet new modproductinterfaces -o "Mod.%2.Interfaces" -c %2
cd %1
dotnet sln add "Mods/%2/Mod.%2.Interfaces/Mod.%2.Interfaces.csproj"

cd %currentmodpathvar %
dotnet new modproductmodels -o "Mod.%2.Models" -c %2
cd %1
dotnet sln add "Mods/%2/Mod.%2.Models/Mod.%2.Models.csproj"

cd %currentmodpathvar %
dotnet new modproductservices -o "Mod.%2.Services" -c %2
cd %1
dotnet sln add "Mods/%2/Mod.%2.Services/Mod.%2.Services.csproj"