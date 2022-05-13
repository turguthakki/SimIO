/* ----------------------------------------------------------------------- *

    * Window.cs

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
using System.Reflection;

namespace th.SimIO.ProjectManager {

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
public class Window : Form
{
  public BlazorWebView view {get; private set;}
  public IServiceProvider services => view.Services;

  // -------------------------------------------------------------------------
  public Window(Type componentType, Dictionary<string, object> parameters = null)
  {
    SuspendLayout();
    Controls.Add(view = new BlazorWebView());
    view.Dock = DockStyle.Fill;
    ResumeLayout();

    var services = new ServiceCollection();
    services.AddWindowsFormsBlazorWebView();
#if DEBUG
    services.AddBlazorWebViewDeveloperTools();
#endif

    view.HostPage = @"wwwroot/index.html";
    view.Services = services.BuildServiceProvider();

    if (componentType.isKindOf<SimIOWindowLayout>()) {
      (parameters = new Dictionary<string, object>(parameters ?? new Dictionary<string, object>()))["window"] = this;
      typeof(RootComponentCollectionExtensions).GetMethod("Add").MakeGenericMethod(componentType).Invoke(null, new object[] {view.RootComponents, "#app", parameters});
    }
    else {
      typeof(RootComponentCollectionExtensions).GetMethod("Add").MakeGenericMethod(componentType).Invoke(null, new object[] {view.RootComponents, "#app", parameters});
    }


    Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
  }

  // -------------------------------------------------------------------------
  public Window showDialog(Window dialog)
  {
    dialog.Show(this);
    Enabled = false;
    dialog.FormClosed += (s, e) => Enabled = true;
    return dialog;
  }
}

} // End of namespace th.SimIO.ProjectManager
