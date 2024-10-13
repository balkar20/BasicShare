#!/bin/bash

# Paths
childScriptPath="./psFunctions.sh"
currentPath=$(dirname "$0")

# Source the child script
source $childScriptPath

path=$(dirname "$(dirname "$currentPath")")
settingsFile="./pssettings.json"
SettingsObject=$(cat $settingsFile | jq .)

# Navigate to the Mods directory
cd "$path/Mods"

# Retrieve settings from JSON
newModName=$(echo $SettingsObject | jq -r .newModName)
fromModName=$(echo $SettingsObject | jq -r .FromModName)
lowerFromName=$(echo $fromModName | awk '{print tolower(substr($0,1,1)) substr($0,2)}')
capName=$(echo $newModName | awk '{print toupper(substr($0,1,1)) substr($0,2)}')

currentModPathVar="$path/Mods/$capName"
coreBasePath="$path/Core/Core.Base"
coreConfigInterfacesFolder="$coreBasePath/ConfigurationInterfaces"
coreConfigClassesFolder="$coreBasePath/Configuration"
coreEntityClassesFolder="$coreBasePath/DataBase/Entities"
appStorageContextFolder="$path/Storage/AppStorage"

echo "The value of currentModPathVar is: $currentModPathVar"
echo "The value of coreConfigClassesFolder is: $coreConfigClassesFolder"
echo "The value of coreConfigInterfacesFolder is: $coreConfigInterfacesFolder"

# Call the rename config functions (assuming they are in psFunctions.sh)
RenameConfig "$fromModName" "$newModName" "$coreConfigInterfacesFolder" "I${fromModName}ApiConfiguration.cs"
RenameConfig "$fromModName" "$newModName" "$coreConfigClassesFolder" "${fromModName}ApiConfiguration.cs"
RenameConfig "$fromModName" "$newModName" "$coreEntityClassesFolder" "${fromModName}Entity.cs"
AppendDbSet "$fromModName" "$newModName" "$appStorageContextFolder/ApiDbContext.cs"

# Create the new mod folder
mkdir -p "$capName"

cd "$capName"

# Retrieve default modifications and chosen modification
libs=$(echo $SettingsObject | jq -r .ModModifications.Default[])
chosen=$(echo $SettingsObject | jq -r .ChosenModification)
ModModifications=$(echo $SettingsObject | jq .ModModifications)

if [ "$chosen" != "Default" ]; then
    ModModificationsArray=$(echo $ModModifications | jq -r ".$chosen[]")
    libs="$libs $ModModificationsArray"
fi

# Loop through each library and create mods
for lib in $libs; do
    echo "The value of lib is: $lib"
    cd "$currentModPathVar"
    modLibName=$(echo $lib | awk '{print toupper(substr($0,1,1)) substr($0,2)}')
    dotnet new "mod$lowerFromName$lib" -o "Mod.$capName.$modLibName" -c "$capName"
    cd "$path"
    dotnet sln add "Mods/$capName/Mod.$capName.$modLibName/Mod.$capName.$modLibName.csproj"
done

# Web API setup
webApiName="WebApi"
appsPath="$path/Apps"
webApiFullName="$capName$webApiName"
webApiFullNameCsproj="$webApiFullName.csproj"
cd "$appsPath"
dotnet new productwebapi -o "$webApiFullName" -c "$capName"
cd "$path"
dotnet sln add "Apps/$webApiFullName/$webApiFullNameCsproj"

# Return to the original directory
cd "$currentPath"
