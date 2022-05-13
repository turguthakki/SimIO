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

namespace th.SimIO.ProjectManager {

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
class MainWindow : Window
{
  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  class Settings : th.SimIO.ProjectManager.GlobalSettings
  {
    public bool maximized {get; set;}
    public int top {get; set;}
    public int left {get; set;}
    public int width {get; set;}
    public int height {get; set;}
  }

  Settings settings = new Settings();

  // -------------------------------------------------------------------------
  public MainWindow() : base(typeof(MainWindowLayout))
  {
    Size = new Size(800, 600);

    new System.Windows.Forms.Timer() {
      Interval = 16,
      Enabled = true
    }.Tick += (s, a) => SimIO.update();
  }

  // -------------------------------------------------------------------------
  protected override void OnLoad(System.EventArgs e)
  {
    if (settings.load()) {
      Top = settings.top;
      Left = settings.left;
      Width = settings.width;
      Height = settings.height;
      WindowState = settings.maximized ? FormWindowState.Maximized : FormWindowState.Normal;
    }
  }

  // -------------------------------------------------------------------------
  protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
  {
    if (WindowState != FormWindowState.Minimized) {
      settings.maximized = WindowState == FormWindowState.Maximized;
      if (!settings.maximized) {
        settings.top = Top;
        settings.left = Left;
        settings.width = Width;
        settings.height = Height;
      }
      settings.save();
    }
  }
}

} // End of namespace th.SimIO.ProjectManager
