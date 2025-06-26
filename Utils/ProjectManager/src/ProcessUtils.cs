/* ----------------------------------------------------------------------- *

    * ProcessUtils.cs

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
public class ProcessUtils
{

  // -------------------------------------------------------------------------
  public static System.Diagnostics.Process runCommandInBackground(string executable, string arguments = "", string workingDirectory = "", Dictionary<string, string> environmentVariables = null, bool createWindow = false, Action onExit = null)
  {
    System.Diagnostics.Process process = new System.Diagnostics.Process();

    process.StartInfo.FileName = executable;
    process.StartInfo.Arguments = arguments;
    process.StartInfo.UseShellExecute = false;
    process.StartInfo.RedirectStandardOutput = true;
    process.StartInfo.RedirectStandardError = true;
    process.StartInfo.CreateNoWindow = !createWindow;
    process.StartInfo.WorkingDirectory = workingDirectory;

    if (environmentVariables != null)
      foreach(KeyValuePair<string, string> variable in environmentVariables)
        process.StartInfo.EnvironmentVariables[variable.Key] = variable.Value;

    process.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(delegate(object sender, System.Diagnostics.DataReceivedEventArgs ev) {
      if (ev.Data != null) {
        Log.info(ev.Data);
        ProjectManager.update();
      }
    });
    process.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler(delegate(object sender, System.Diagnostics.DataReceivedEventArgs ev) {
      if (ev.Data != null)
        Log.error(ev.Data);
        ProjectManager.update();
    });

    process.Exited += (s, e) => {
      if (onExit != null) {
        onExit();
      }
      ProjectManager.update();
    };
    process.EnableRaisingEvents = true;
    process.Start();
    process.BeginOutputReadLine();
    process.BeginErrorReadLine();

    return process;
  }

  // -------------------------------------------------------------------------
  public static int runCommand(string executable, string arguments = "", string workingDirectory = "", Dictionary<string, string> environmentVariables = null, bool createWindow = false)
  {
    System.Diagnostics.Process process = runCommandInBackground(executable, arguments, workingDirectory, environmentVariables, createWindow);
    process.WaitForExit();
    ProjectManager.update();
    return process.ExitCode;
  }

  // -------------------------------------------------------------------------
  public static string runCommandWithOutput(string executable, string arguments = "", string workingDirectory = "", Dictionary<string, string> environmentVariables = null, bool createWindow = false)
  {
    System.Diagnostics.Process process = new System.Diagnostics.Process();

    process.StartInfo.FileName = executable;
    process.StartInfo.Arguments = arguments;
    process.StartInfo.UseShellExecute = false;
    process.StartInfo.RedirectStandardOutput = true;
    process.StartInfo.RedirectStandardError = true;
    process.StartInfo.CreateNoWindow = !createWindow;
    process.StartInfo.WorkingDirectory = workingDirectory;

    if (environmentVariables != null)
      foreach(KeyValuePair<string, string> variable in environmentVariables)
        process.StartInfo.EnvironmentVariables[variable.Key] = variable.Value;

    process.Start();
    string rv = process.StandardOutput.ReadToEnd();
    process.WaitForExit();

    return rv;
  }
}

} // End of namespace th.SimIO.ProjectManager
