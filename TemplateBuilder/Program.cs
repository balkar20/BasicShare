using System;
using System.IO;
using System.Xml;
using Microsoft.Build.Construction;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Host;
using Microsoft.CodeAnalysis.MSBuild;

class Program
{
    static async Task<int> Main(string[] args)
    {
        if (args.Length < 4)
        {
            Console.WriteLine("Usage: TemplateBuilder.exe <projectPath> <slnPath> <oldString> <newString>");
            return 0;
        }

        var projectPath = args[0];
        var slnPath = args[1];
        var oldString = args[2];
        var newString = args[3];

        var newSlnPath = slnPath.Replace(".sln", "New.sln");

        // Read the existing project file
        var projectXml = File.ReadAllText(projectPath);
        var project = ProjectRootElement.Create(XmlReader.Create(new StringReader(projectXml)));

        // Replace the old string with the new string in the project file
        foreach (var element in project.AllChildren)
        {
            if (element is ProjectItemElement item)
            {
                foreach (var metadata in item.Metadata)
                {
                    metadata.Value = metadata.Value.Replace(oldString, newString);
                }
            }
            else if (element is ProjectPropertyElement property)
            {
                property.Value = property.Value.Replace(oldString, newString);
            }
        }

        // Save the modified project file
        var newProjectPath = projectPath.Replace(oldString, newString);
        project.Save(newProjectPath);

        // Create a new solution with a single project
        var newSolutionPath = slnPath.Replace(oldString, newString);
        var newProjectName = Path.GetFileName(newProjectPath).Replace(".csproj", "");
        var projectInfo = ProjectInfo.Create(
            ProjectId.CreateNewId(),
            VersionStamp.Create(),
            newProjectName,
            newProjectName,
            LanguageNames.CSharp,
            newProjectPath
        );
        var newSolutionInfo = SolutionInfo.Create(
            SolutionId.CreateNewId(),
            VersionStamp.Create(),
            newSlnPath,
            new[] { projectInfo}
        );
        
        var workspace = MSBuildWorkspace.Create();
        var cursln = workspace.CurrentSolution;
        var sln = await workspace.OpenSolutionAsync(slnPath);
        // Create a new MyWorkspace object
        // var myWorkspace = MyWorkSpace
        // var newSolution = myWorkspace.GetNewSolution(newSolutionInfo);
        // Replace the old string with the new string in the project name
        var newProject = sln.GetProject(sln.ProjectIds[0]);
        newProject = newProject.WithAssemblyName(newProjectName);

        // Save the modified solution file
        // newSolution.Workspace.TryApplyChanges(newSolution);

        Console.WriteLine("New project created successfully.");

        return 1;
    }
}

class MyWorkSpace: Workspace 
{
    public Workspace Workspace { get; set; }
    
    public MyWorkSpace(HostServices host, string? workspaceKind) : base(host, workspaceKind)
    {
    }

    public Solution GetNewSolution(SolutionInfo solutionInfo)
    {
        return base.CreateSolution(solutionInfo);
    }

    // public Project GetNewProject(ProjectInfo project)
    // {
    //     
    // }

    protected override void ApplyProjectAdded(ProjectInfo project)
    {
        base.ApplyProjectAdded(project);
    }
    
}

