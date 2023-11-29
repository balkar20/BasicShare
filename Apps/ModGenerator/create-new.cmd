cd "%1/Mods/%2"

for /d %F in (*) do (
    cd %F
    dotnet new install .\ --force
    cd ../
)
