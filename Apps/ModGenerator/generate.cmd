cd "%1\Mods"

md %2

cd ./%2
set count=0

for %%a in (%*) do (
    set /a count =  count +1
    if !count! geq 3 (
        dotnet new mod%3%%a -o "Mod.%2.%%a" -c %2
        
        cd %1
        dotnet sln add "Mods/%2/Mod.%2.Base/Mod.%2.Base.csproj"
        echo Parameter: %%a
    )
)

for %%i in (%*) do (
    REM Skip the first two parameters
    if not "%%~i"=="%~1" if not "%%~i"=="%~2" (
        dotnet new mod%3%%i -o "Mod.%2.%%i" -c %2
        cd %1
        dotnet sln add "Mods/%2/Mod.%2.Base/Mod.%2.Base.csproj"
        echo Parameter: %%i
    )
)


set modspathvar = "%1\Mods"
@REM set currentmodspathvar = %cd%
set currentmodpathvar = "%1\Mods\%2"

dotnet new mod%3base -o "Mod.%2.Base" -c %2
cd %1
dotnet sln add "Mods/%2/Mod.%2.Base/Mod.%2.Base.csproj"

cd %currentmodpathvar %
dotnet new mod%3root -o "Mod.%2.Root" -c %2
cd %1
dotnet sln add "Mods/%2/Mod.%2.Root/Mod.%2.Root.csproj"

cd %currentmodpathvar %
dotnet new mod%3interfaces -o "Mod.%2.Interfaces" -c %2
cd %1
dotnet sln add "Mods/%2/Mod.%2.Interfaces/Mod.%2.Interfaces.csproj"

cd %currentmodpathvar %
dotnet new mod%3models -o "Mod.%2.Models" -c %2
cd %1
dotnet sln add "Mods/%2/Mod.%2.Models/Mod.%2.Models.csproj"

cd %currentmodpathvar %
dotnet new mod%3services -o "Mod.%2.Services" -c %2
cd %1
dotnet sln add "Mods/%2/Mod.%2.Services/Mod.%2.Services.csproj"