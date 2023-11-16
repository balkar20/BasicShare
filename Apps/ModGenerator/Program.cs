﻿// See https://aka.ms/new-console-template for more information

using System.Diagnostics;   

var echoVar =         Environment.CurrentDirectory;
var f = 
    AppDomain.CurrentDomain.BaseDirectory;
var path = echoVar.Substring(0, echoVar.IndexOf($"\\Apps\\ModGenerator\\bin\\Debug\\net{Environment.Version.Major}.{Environment.Version.Minor}"));

var mod = args[0];
var p1 = Process.Start("create-new.cmd", path);
p1.WaitForExit();
var p2 = Process.Start("generate.cmd", $"{path} {mod}");
p2.WaitForExit();
Console.ReadLine();

var coreBasePath = $"{path}\\Core\\Core.Base\\";
var coreConfigInterfacesFolder = $"{coreBasePath}ConfigurationInterfaces";

// Raname(mod, coreConfigInterfacesFolder, "IProductApiConfiguration.cs");
// Raname(mod, coreConfigInterfacesFolder);


static void Raname(string mod, string coreConfigFolder, string fileName )
{
    
    var coreConfigInterfacesProductInterface = $"{coreConfigFolder}\\IProductApiConfiguration.cs";
    var coreConfigInterfacesNewInterface = coreConfigInterfacesProductInterface.Replace("Product", mod);


    var  coreConfigInterfacesProductInterfaceText = File.ReadAllText(coreConfigInterfacesProductInterface);
    var newText = coreConfigInterfacesProductInterfaceText.Replace("Product", mod);

    File.WriteAllText(coreConfigInterfacesNewInterface, newText);
}
