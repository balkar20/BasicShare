// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

var echoVar =         Environment.CurrentDirectory;
var f = 
    AppDomain.CurrentDomain.BaseDirectory;
;

var path = args[0];
var mod = args[1];
// var name = args[2];
Process.Start("test.cmd", $"{echoVar}");
// Process.Start("generate.cmdvar ", $"{path} {mod}");