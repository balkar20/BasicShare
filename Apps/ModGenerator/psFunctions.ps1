Function UpperFirstLetter([string]$modName)
{
    $upperFirst = $modName.Substring(0,1).ToUpper() + $modName.Substring(1)
     return $upperFirst
}

Function LowerFirstLetter([string]$modName)
{
    $lowerFirst = $modName.Substring(0,1).ToLower() + $modName.Substring(1)
     return $lowerFirst
}

Function RenameConfig([string]$oldMod, [string]$newMod, [string]$coreConfigFolder, [string]$fileName) {
    $coreConfigProductCsFile = "$($coreConfigFolder)\$($fileName)"
    Write-Host Start Rename-Config
    Write-Host The value of coreConfigProductCsFile  is: $coreConfigProductCsFile
    $coreConfigInterfacesNewCsFile = $coreConfigProductCsFile -replace $oldMod, $newMod
    Write-Host The value of coreConfigInterfacesNewCsFile  is: $coreConfigInterfacesNewCsFile
    $existingText = Get-Content -Path $coreConfigProductCsFile
    $newText = $existingText -replace $oldMod, $newMod
    Set-Content -Path $coreConfigInterfacesNewCsFile -Value $newText
}

Function AppendDbSet([string]$oldMod, [string]$newMod, [string]$appContextFile) {
$newMod = "public DbSet<${newMod}Entity> ${newMod}s { get; set; }"
    
    $content = Get-Content $appContextFile
    $updatedContent = @()
    
    $foundDbSets = $false
    foreach ($line in $content) {
        $updatedContent += $line
        if ($line -match "public DbSet<.*>.*{ get; set; }") {
            $foundDbSets = $true
        } elseif ($foundDbSets) {
            $updatedContent += $newMod
            $foundDbSets = $false
        }
    }
    
    if ($foundDbSets) {
        $updatedContent += $newRow
    }
    
    $updatedContent | Set-Content $AppContextFile
}

