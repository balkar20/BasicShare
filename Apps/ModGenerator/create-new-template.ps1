$childScriptPath = ".\psFunctions.ps1"
 
# Dot sourcing the child script
. $childScriptPath

$SettingsObject = Get-Content -Path .\pssettings.json | ConvertFrom-Json
$currentPath = $PSScriptRoot
$path = Split-Path -Path (Split-Path -Path $currentPath -Parent) -Parent


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