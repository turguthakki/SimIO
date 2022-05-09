/* ----------------------------------------------------------------------- *

    * ProjectManager.cs

    ----------------------------------------------------------------------

    Copyright (C) 2022, Turgut Hakki Ozdemir
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
global using System;
global using System.IO;

global using System.Linq;
global using System.Collections;
global using System.Collections.Generic;
global using System.Threading;
global using System.Drawing;
global using System.Windows.Forms;
global using System.Diagnostics;

global using Microsoft.AspNetCore.Components;
global using Microsoft.AspNetCore.Components.Web;
global using Microsoft.AspNetCore.Components.WebView.WindowsForms;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Win32;

global using Newtonsoft.Json;

global using th.SimIO;
global using th.SimIO.Selectors;

using static th.SimIO.ProjectManager.ProjectManager;

namespace th.SimIO.ProjectManager {

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
static class ProjectManager
{
  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  public class Settings : th.SimIO.ProjectManager.GlobalSettings
  {
    // -----------------------------------------------------------------------
    [JsonProperty("projectsPath")]
    string _projectsPath = null;

    // -----------------------------------------------------------------------
    [JsonIgnore]
    public string projectsPath
    {
      get => _projectsPath ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SimIOProjects");
      set => _projectsPath = value;
    }
  }

  // -------------------------------------------------------------------------
  public static Window window {get; private set;} = new Window();
  public static Settings settings {get; private set;} = new Settings();
  public static bool initialized {get; private set;} = false;
  public static event Action onStateChanged = delegate {};

  // -------------------------------------------------------------------------
  public static void update()
  {
    onStateChanged();
  }

  // -------------------------------------------------------------------------
  public static void installSimIO()
  {
    ProcessUtils.runCommandInBackground("dotnet", "new -i SimIO");
  }

  // -------------------------------------------------------------------------
  public static void initialize()
  {
    new Thread(() => {
      settings.load();
      installSimIO();
      Project.refreshProjectList();
      initialized = true;
      update();
    }).Start();
  }

  // -------------------------------------------------------------------------
  [STAThread]
  static void Main(string[] args)
  {
    Application.SetHighDpiMode(HighDpiMode.SystemAware);
    Application.SetCompatibleTextRenderingDefault(false);

    initialize();

    Application.Run(window);
    settings.save();
  }
}

} // End of namespace th.SimIO

