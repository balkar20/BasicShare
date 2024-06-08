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
var envCurrentDir = Environment.CurrentDirectory;
var path = envCurrentDir.Substring(0, envCurrentDir.IndexOf($"\\Apps\\ModGenerator\\bin\\Debug\\net{Environment.Version.Major}.{Environment.Version.Minor}"));

var fromModName = config.GetSection("FromModName").Value;
var newModName = config.GetSection("NewModName").Value;

var coreBasePath = $"{path}\\Core\\Core.Base\\";
var coreConfigInterfacesFolder = $"{coreBasePath}ConfigurationInterfaces";
var coreConfigClassesFolder = $"{coreBasePath}Configuration";

try
{
    await Raname(fromModName, newModName, coreConfigInterfacesFolder, $"I{fromModName}ApiConfiguration.cs");
    await Raname(fromModName, newModName, coreConfigClassesFolder, $"{fromModName}ApiConfiguration.cs");
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}


var createNewStartInfo = new ProcessStartInfo()
{
    FileName = "powershell.exe",
    Arguments = $"-NoProfile -ExecutionPolicy ByPass -File create-new-template.ps1 -path {path} -name {fromModName}",
    UseShellExecute = false
};

var p1 = Process.Start(createNewStartInfo);
// var p1 = Process.Start("create-new.cmd", $"{path} {fromMod}");
p1.WaitForExit();

var startInfo = new ProcessStartInfo()
{
    FileName = "powershell.exe",
    Arguments = $"-NoProfile -ExecutionPolicy ByPass -File generate.cmd",
    UseShellExecute = false
};

var p2 = Process.Start(startInfo);
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
