/* ----------------------------------------------------------------------- *

    * DeviceBrowser.cs

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
using System.Threading;

using System.Windows.Forms;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;

using th.SimIO;
using th.SimIO.Selectors;
using DeviceBrowser;

namespace th.SimIO {

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
class DB
{
  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  class Window : Form
  {
    public BlazorWebView webView {get; private set;}
    string registryKey = @"HKEY_CURRENT_USER\SOFTWARE\SimIO\DeviceBrowser";

    // -----------------------------------------------------------------------
    public Window()
    {
      SuspendLayout();
      Controls.Add(webView = new BlazorWebView());
      webView.Dock = DockStyle.Fill;
      Size = new Size(800, 600);
      Text = "SimIO Device Browser";
      ResumeLayout();

      var services = new ServiceCollection();
      services.AddWindowsFormsBlazorWebView();

      webView.HostPage = @"wwwroot/index.html";
      webView.Services = services.BuildServiceProvider();
      webView.RootComponents.Add<Axes>("#app");

      new System.Windows.Forms.Timer() {
        Interval = 16,
        Enabled = true
      }.Tick += (s, a) => SimIO.update();

      Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
    }

    // -----------------------------------------------------------------------
    protected override void OnLoad(EventArgs e)
    {
      try {
        Top =  (int) Registry.GetValue(registryKey, "Top", 200);
        Left =  (int) Registry.GetValue(registryKey, "Left", 200);
        Width =  (int) Registry.GetValue(registryKey, "Width", 800);
        Height =  (int) Registry.GetValue(registryKey, "Height", 600);
        WindowState = bool.Parse((string) Registry.GetValue(registryKey, "Maximized", false)) ? FormWindowState.Maximized : FormWindowState.Normal;
      }
      catch(System.Exception) {
      }
    }

    // -----------------------------------------------------------------------
    protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
    {
      if (WindowState != FormWindowState.Minimized) {
        Registry.SetValue(registryKey, "Top", Top);
        Registry.SetValue(registryKey, "Left", Left);
        Registry.SetValue(registryKey, "Width", Width);
        Registry.SetValue(registryKey, "Height", Height);
        Registry.SetValue(registryKey, "Maximized", WindowState == FormWindowState.Maximized);
      }
    }
  }

  // -------------------------------------------------------------------------
  [STAThread]
  static void Main(string[] args)
  {
    Application.SetHighDpiMode(HighDpiMode.SystemAware);
    Application.SetCompatibleTextRenderingDefault(false);
    Application.Run(new Window());
  }
}

} // End of namespace th.SimIO

