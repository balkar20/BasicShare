
# delete dotnet new Templates
# $deleteTemplatesScript = ".\delete-new-template.ps1"
# . $deleteTemplatesScript
# # Create dotnet new Templates
# # Create dotnet new Templates
# $createTemplatesScript = ".\create-new-template.ps1"
# . $createTemplatesScript
# # Create dotnet new Templates

$SettingsObject = Get-Content -Path .\pssettings.json | ConvertFrom-Json
$currentPath = $PSScriptRoot
$path = Split-Path -Path (Split-Path -Path $currentPath -Parent) -Parent

$deleteTemplatesScript = ".\delete-new-template.ps1"
. $deleteTemplatesScript $path $SettingsObject.FromModeName


$upperName = UpperFirstLetter($SettingsObject.FromModeName)
Write-Host The value of upperName is: $upperName
$modpath = "$path\Mods\$upperName"
$SubFolders = Get-ChildItem -Path $modpath -Directory
Foreach($SubFolder in $SubFolders)
{ 
    $libPath = "$($SubFolder.FullName)\"
    cd $libPath
    dotnet new install .\ --force
}

cd $currentPath