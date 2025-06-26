/* ----------------------------------------------------------------------- *

    * ProjectManagerProjects.cs

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
public partial class ProjectManager
{
  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  public class NewProjectArgs
  {
    public string fileName;
    public string template;
  }

  // -------------------------------------------------------------------------
  static List<Project> _projects = new List<Project>();
  static FileSystemWatcher projectsDirWatcher = null;

  // -------------------------------------------------------------------------
  public static IEnumerable<Project> projects => _projects;
  public static event Action onProjectsChanged = delegate{};

  // -------------------------------------------------------------------------
  public static void createProject(NewProjectArgs args)
  {
    string projectFile = args.fileName;
    string projectFolder = Path.GetDirectoryName(projectFile);
    string name = Path.GetFileNameWithoutExtension(projectFile);

    if (File.Exists(projectFile)) {
      Log.error("Project already exist");
      return;
    }

    if (!Directory.Exists(projectFolder))
      Directory.CreateDirectory(projectFolder);
    ProjectManager.installSimIO().Exited += (s, e) => {
      ProcessUtils.runCommandInBackground("dotnet", "new " + args.template, projectFolder).Exited += (s, e) => {
        refreshProjectList();
      };
    };
  }

  // -------------------------------------------------------------------------
  public static void refreshProjectList()
  {
    if (settings?.projectsPath == null)
      return;
    if (!Directory.Exists(settings.projectsPath)) {
      Directory.CreateDirectory(settings.projectsPath);
    }
    _projects.Clear();
    foreach(string dir in Directory.GetDirectories(ProjectManager.settings.projectsPath)) {
      string projectFile = dir + "\\" + Path.GetFileName(dir) + ".csproj";
      if (File.Exists(projectFile)) {
        _projects.Add(new Project(projectFile));
      }
    }
    onProjectsChanged();
  }

  // -------------------------------------------------------------------------
  static void startProjectsWatcher()
  {
    if (projectsDirWatcher != null) {
      projectsDirWatcher.EnableRaisingEvents = false;
    }

    projectsDirWatcher = new FileSystemWatcher(settings.projectsPath);
    projectsDirWatcher.NotifyFilter = NotifyFilters.Attributes | NotifyFilters.CreationTime | NotifyFilters.DirectoryName | NotifyFilters.FileName | NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.Security | NotifyFilters.Size;

    FileSystemEventHandler eventHandler = (o, e) => {
      refreshProjectList();
    };

    projectsDirWatcher.Changed += eventHandler;
    projectsDirWatcher.Created += eventHandler;
    projectsDirWatcher.Deleted += eventHandler;
    projectsDirWatcher.Renamed += (o, e) => refreshProjectList();

    projectsDirWatcher.Filter = "*";
    projectsDirWatcher.IncludeSubdirectories = false;
    projectsDirWatcher.EnableRaisingEvents = true;
  }

  // -------------------------------------------------------------------------
  static void stopProjectsWatcher()
  {
    if (projectsDirWatcher == null)
      return;
    projectsDirWatcher.EnableRaisingEvents = false;
    projectsDirWatcher.Dispose();
    projectsDirWatcher = null;
  }
}

} // End of namespace th.SimIO.ProjectManager
