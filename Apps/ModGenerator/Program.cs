// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Management.Automation;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;


var builder = new ConfigurationBuilder();
builder.AddJsonFile("appsettings.json", optional: false);
    // .(Directory.GetCurrentDirectory())
    // .AddJsonFile("config.json", optional: false);

IConfiguration config = builder.Build();

var defaultModificationArray = config.GetSection("ModModifications:Default").GetChildren().Select(c => c.Value);

var chosenModification = config.GetSection("ChosenModification").Value;
var modModificationTemplates = defaultModificationArray.Concat(config.GetSection($"ModModifications:{chosenModification}").GetChildren().Select(c => c.Value));
var echoVar =         Environment.CurrentDirectory;
var f = AppDomain.CurrentDomain.BaseDirectory;
var path = echoVar.Substring(0, echoVar.IndexOf($"\\Apps\\ModGenerator\\bin\\Debug\\net{Environment.Version.Major}.{Environment.Version.Minor}"));

var fromMod = args[1];
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


var p1 = Process.Start("create-new.cmd", $"{path} {fromMod}");
p1.WaitForExit();

var startInfo = new ProcessStartInfo()
{
    FileName = "powershell.exe",
    Arguments = $"-NoProfile -ExecutionPolicy ByPass -File generate.cmd",
    UseShellExecute = false
};
var p2 = Process.Start("generate.cmd", $"{path} {mod} {fromMod.ToLower()}");
// PowerShell.Create().AddScript("").AddParameters()
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
