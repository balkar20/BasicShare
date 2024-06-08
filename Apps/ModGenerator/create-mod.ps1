$createTemplatesScript = ".\psFunctions.ps1"
 
# Dot sourcing the child script
. $createTemplatesScript

$currentPath = $PSScriptRoot
$path = Split-Path -Path (Split-Path -Path $currentPath -Parent) -Parent
$SettingsObject = Get-Content -Path .\pssettings.json | ConvertFrom-Json


# cd "%1\Mods"
# cd $path\Mods

# Write-Host The value of path  is: $path
# $newModeName = $SettingsObject.NewModeName
# $fromModeName = $SettingsObject.FromModeName
# Write-Host The value of path  is: $path
# $lowerFromName = LowerFirstLetter($SettingsObject.FromModeName)
# Write-Host The value of lowerFromName  is: $lowerFromName
# $capName = UpperFirstLetter($SettingsObject.NewModeName)
# Write-Host The value of capName  is: $capName
# $currentmodpathvar = "$path\Mods\$capName"
# Write-Host The value of currentmodpathvar  is: $currentmodpathvar
# md $capName

# cd $capName

# $script:libs = $SettingsObject.ModModifications.Default
# Write-Host The value of libs is: $libs
# Write-Host The value of chosen  is: $SettingsObject.ChosenModification
# $chosen = $SettingsObject.ChosenModification
# $ModModifications = $SettingsObject.ModModifications

# if($chosen -ne "Default"){
#     $ModModificationsArray = $ModModifications.$chosen
#     $libs = $libs + $ModModificationsArray
# }

# Foreach ($lib in $libs)
# {
#     Write-Host The value of lib is: $lib
#     cd $currentmodpathvar
#     $modLibName = UpperFirstLetter($lib)
#     dotnet new mod$lowerFromName$lib -o Mod.$capName.$modLibName -c $capName
#     cd $path
#     dotnet sln add Mods/$capName/Mod.$capName.$modLibName/Mod.$capName.$modLibName.csproj
# }

# cd $currentPath

