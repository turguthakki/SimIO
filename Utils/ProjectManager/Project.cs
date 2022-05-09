/* ----------------------------------------------------------------------- *

    * Project.cs

    ----------------------------------------------------------------------

    Copyright (C) 2021, Turgut Hakki Ozdemir
    All Rights Reserved.

    THIS SOFTWARE IS PROVIDED 'AS-IS', WITHOUT ANY EXPRESS
    OR IMPLIED WARRANTY. IN NO EVENT WILL THE AUTHOR(S) BE HELD LIABLE FOR
    ANY DAMAGES ARISING FROM THE USE OR DISTRIBITION OF THIS SOFTWARE

    Permission is granted to anyone to use this software for any purpose,
    including commercial applications, and to alter it and redistribute it
    freely, subject to the following restrictions:

    1. The origin of this software must not be misrepresented; you must not
       claim that you wrote the original software.
    2. Altered source versions must be plainly marked as such, and must not be
       misrepresented as being the original software.
    4. Distributions in binary form must reproduce the above copyright notice
       and an acknowledgment of use of this software either in documentation
       or binary form itself.
    3. This notice may not be removed or altered from any source distribution.

    Turgut Hakkı Özdemir <turgut.hakki@gmail.com>

* ------------------------------------------------------------------------ */

namespace th.SimIO.ProjectManager {

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
public class Project
{
  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  public class Settings : th.SimIO.ProjectManager.Settings
  {
    public string buildArguments;
    public string runArguments;
    public Project project {get; private set;}

    // -----------------------------------------------------------------------
    public override string path => project.projectFolder + "\\.simio\\project.settings";

    // -----------------------------------------------------------------------
    public Settings(Project project)
    {
      this.project = project;
    }
  }

  // -------------------------------------------------------------------------
  static List<Project> _projects = new List<Project>();

  // -------------------------------------------------------------------------
  public static IEnumerable<Project> projects => _projects;
  public static event Action onProjectsChanged = delegate{};

  // -------------------------------------------------------------------------
  public string name {get; private set;}
  public string projectFile {get; set;}
  public string projectFolder => Path.GetDirectoryName(projectFile);
  public Settings settings {get; private set;} = null;
  public System.Diagnostics.Process dotnetProcess {get; private set;}
  public event Action onStateChanged = delegate{};

  // -------------------------------------------------------------------------
  public Project(string projectFile, string templateName = "")
  {
    settings = new Settings(this);
    this.projectFile = projectFile;
    name = Path.GetFileNameWithoutExtension(projectFile);
    if (File.Exists(projectFile)) {
      settings.load();
    }
    else {
      if (!Directory.Exists(projectFolder))
        Directory.CreateDirectory(projectFolder);
      ProjectManager.installSimIO();
      ProcessUtils.runCommandInBackground("dotnet", "new " + templateName, projectFolder);
    }
    Path.GetFileNameWithoutExtension(projectFile);
  }

  // -------------------------------------------------------------------------
  public void build()
  {
    dotnetProcess = ProcessUtils.runCommandInBackground("dotnet", "build " + settings.buildArguments, projectFolder);
    dotnetProcess.Exited += (s,e) => onStateChanged();
  }

  // -------------------------------------------------------------------------
  public void run()
  {
    dotnetProcess = ProcessUtils.runCommandInBackground("dotnet", "run " + settings.runArguments, projectFolder);
    dotnetProcess.Exited += (s,e) => onStateChanged();
  }

  // -------------------------------------------------------------------------
  public void kill()
  {
    if (!dotnetProcess.HasExited) {
      dotnetProcess.Kill(true);
    }
  }

  // -------------------------------------------------------------------------
  public static void refreshProjectList()
  {
    foreach(string dir in Directory.GetDirectories(ProjectManager.settings.projectsPath)) {
      string projectFile = dir + "\\" + Path.GetFileName(dir) + ".csproj";
      if (File.Exists(projectFile)) {
        if (!_projects.Any(p => p.projectFile != projectFile))
          _projects.Add(new Project(projectFile));
      }
    }
    onProjectsChanged();
  }
}

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
public static class ProjectHelpers
{
  // -------------------------------------------------------------------------
  public static string toProjectFile(this string name) => Path.Combine(ProjectManager.settings.projectsPath, name + "\\" + name + ".csproj");
}

} // End of namespace th.SimIO.ProjectManager
