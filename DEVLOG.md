# Development Log

## 2022.05.14
I'm working on a **"project manager"** / **launcher**.

Here is a list of what I have in mind:
  * Start with windows, stay in tray *(Optional of course)*
  * Manage *dotnet* projects in a *project directory* using SimIO templates
    * Create new projects using one of the provided SimIO templates or perhaps arbitrarily.
  * Run said projects automatically when it's associated game is started.
    * With ability to run arbitrary shell commands before and after.
  * Act as a generic game launcher with ability to auto detect games from popular platforms (such as steam)
  * Edit projects using an external editor such as *Visual Studio Code* and *Visual Studio*, monitor changes and rebuild automatically as needed.
  * Include a *bare bones* code editor based on *Monaco* (?) or something else perhaps.

  ### Future features featuring great uncertainity about their probable existances.
  * Own HID drivers replacing / augmenting SendInput and vJoy
  * XInput input and output (Again, using my own drivers perhaps)
  * A wrapper API that can read / write rawinput (HID) devices, so you can try to use some unknown button on a device only you own in the whole wide world as chaff / flare release.
  * Gamepad Translation using SDL's database.

