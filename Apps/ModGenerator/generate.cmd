cd %1

md %2
cd ./%2
echo "EchoVbar: %3"
dotnet new modproductbase -o "Mod.%2.Base" -c %2
dotnet new modproductroot -o "Mod.%2.Root" -c %2
dotnet new modproductinterfaces -o "Mod.%2.Interfaces" -c %2