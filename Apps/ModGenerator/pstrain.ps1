
$currentPath = $PSScriptRoot
$parentPath = Split-Path -Path (Split-Path -Path $currentPath -Parent) -Parent

Write-Host The value of parentPath is: $parentPath

# $SettingsObject = Get-Content -Path .\pssettings.json | ConvertFrom-Json



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

# }



