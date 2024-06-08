param (

    [Parameter(Mandatory)]
    [string]
    $path,
    
    [Parameter(Mandatory)]
    [string]
    $name
)

$currentPath = $PSScriptRoot

Function UpperFirstLetter([string]$modName)
{
    $upperFirst = $modName.Substring(0,1).ToUpper() + $modName.Substring(1)
     return $upperFirst
}
Write-Host The value of name is: $name
Write-Host The value of path is: $path
$upperName = UpperFirstLetter($name)
Write-Host The value of upperName is: $upperName
$modpath = "$path\Mods\$upperName"
$SubFolders = Get-ChildItem -Path $modpath -Directory
Foreach($SubFolder in $SubFolders)
{ 
    $libPath = "$($SubFolder.FullName)\"
    cd $libPath
    Write-Host The libPath is: $libPath
    
    dotnet new uninstall .
}



cd $currentPath
