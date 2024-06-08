$childScriptPath = ".\psFunctions.ps1"

# Dot sourcing the child script
. $childScriptPath

$currentPath = $PSScriptRoot


$path = Split-Path -Path (Split-Path -Path $currentPath -Parent) -Parent
$SettingsObject = Get-Content -Path .\pssettings.json | ConvertFrom-Json

# cd "%1\Mods"
cd $path\Mods

Write-Host The value of path  is: $path
$newModName = $SettingsObject.newModName
$fromModName = $SettingsObject.FromModName
Write-Host The value of path  is: $path
$lowerFromName = LowerFirstLetter($SettingsObject.FromModName)
Write-Host The value of lowerFromName  is: $lowerFromName
$capName = UpperFirstLetter($SettingsObject.NewModName)
Write-Host The value of capName  is: $capName
$currentmodpathvar = "$path\Mods\$capName"
$coreBasePath = "$path\Core\Core.Base\"
$coreConfigInterfacesFolder = $coreBasePath + "ConfigurationInterfaces"
$coreConfigClassesFolder = $coreBasePath + "Configuration"
$coreEntityClassesFolder = $coreBasePath + "DataBase\Entities"
$appStorageContextFolder = $path + "\Storage\AppStorage"
Write-Host The value of currentmodpathvar  is: $currentmodpathvar
Write-Host The value of coreConfigClassesFolder  is: $coreConfigClassesFolder
Write-Host The value of coreConfigInterfacesFolder  is: $coreConfigInterfacesFolder


RenameConfig $fromModName $newModName $coreConfigInterfacesFolder "I${fromModName}ApiConfiguration.cs"
RenameConfig $fromModName $newModName $coreConfigClassesFolder "${fromModName}ApiConfiguration.cs"

RenameConfig $fromModName $newModName $coreEntityClassesFolder "${fromModName}Entity.cs"
AppendDbSet $fromModName $newModName "$appStorageContextFolder\ApiDbContext.cs"

md $capName

cd $capName

$script:libs = $SettingsObject.ModModifications.Default
Write-Host The value of libs is: $libs
Write-Host The value of chosen  is: $SettingsObject.ChosenModification
$chosen = $SettingsObject.ChosenModification
$ModModifications = $SettingsObject.ModModifications

if($chosen -ne "Default"){
    $ModModificationsArray = $ModModifications.$chosen
    $libs = $libs + $ModModificationsArray
}

Foreach ($lib in $libs)
{
    Write-Host The value of lib is: $lib
    cd $currentmodpathvar
    $modLibName = UpperFirstLetter($lib)
    dotnet new mod$lowerFromName$lib -o Mod.$capName.$modLibName -c $capName
    cd $path
    dotnet sln add Mods/$capName/Mod.$capName.$modLibName/Mod.$capName.$modLibName.csproj
}

$webApiName = "WebApi"
$appsPath = $path + "\Apps"
$webApiFullName = $capName + $webApiName
$webApiFullNameCsproj = $webApiFullName + ".csproj"
cd $appsPath
dotnet new productwebapi -o $webApiFullName -c $capName
cd $path
dotnet sln add Apps/$webApiFullName/$webApiFullNameCsproj

cd $currentPath

