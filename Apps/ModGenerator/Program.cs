// See https://aka.ms/new-console-template for more information

using System.Diagnostics;   

var echoVar =         Environment.CurrentDirectory;
var f = AppDomain.CurrentDomain.BaseDirectory;
var path = echoVar.Substring(0, echoVar.IndexOf($"\\Apps\\ModGenerator\\bin\\Debug\\net{Environment.Version.Major}.{Environment.Version.Minor}"));

var mod = args[0];

var coreBasePath = $"{path}\\Core\\Core.Base\\";
var coreConfigInterfacesFolder = $"{coreBasePath}ConfigurationInterfaces";
var coreConfigClassesFolder = $"{coreBasePath}Configuration";

try
{
    await Raname("Product", mod, coreConfigInterfacesFolder, "IProductApiConfiguration.cs");
    await Raname("Product", mod, coreConfigClassesFolder, "ProductApiConfiguration.cs");
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}


var p1 = Process.Start("create-new.cmd", path);
p1.WaitForExit();
var p2 = Process.Start("generate.cmd", $"{path} {mod}");
p2.WaitForExit();
Console.ReadLine();



static async Task Raname(string oldMod, string newMod, string coreConfigFolder, string fileName )
{
    var coreConfigProductCsFile = $"{coreConfigFolder}\\{fileName}";
    var coreConfigInterfacesNewCsFile = coreConfigProductCsFile.Replace(oldMod, newMod);


    var  existingText = await File.ReadAllTextAsync(coreConfigProductCsFile);
    var newText = existingText.Replace(oldMod, newMod);

    await File.WriteAllTextAsync(coreConfigInterfacesNewCsFile, newText);
}
