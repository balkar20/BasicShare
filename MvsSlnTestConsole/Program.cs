// See https://aka.ms/new-console-template for more information

using net.r_eg.MvsSln;
using net.r_eg.MvsSln.Extensions;

if (args.Length < 4)
{
    Console.WriteLine("Usage: TemplateBuilder.exe <projectPath> <slnPath> <oldString> <newString>");
    throw new Exception("Usage: TemplateBuilder.exe <projectPath> <slnPath> <oldString> <newString>");
}

var projectPath = args[0];
var slnPath = args[1];
var oldString = args[2];
var newString = args[3];

using var sln = new Sln(slnPath, SlnItems.Env);

var proj = sln.Result.Env.LoadProjects(sln.Result.ProjectItemsConfigs.Where(p => p.project.IsCs()));
foreach (var xProject in proj)
{
    Console.WriteLine(xProject.ProjectName);
}
// sln.Result.Env
//     .LoadProjects(sln.Result.ProjectItemsConfigs.Where(p => p.project.IsCs()))
//     .ForEach(xp =>
//     {
//         xp.AddItem("Compile", @"financial\Invoice.cs");
//     });