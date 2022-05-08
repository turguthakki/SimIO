using System.Threading;
using System.Diagnostics;
using th.SimIO;
using th.SimIO.Selectors;

// Initialize web server
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages(options => {
  options.RootDirectory = "/";
});

builder.Services.AddServerSideBlazor();

WebApplication app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/index");

// Start simio thread
Thread ioThread = new Thread(() => {
  // Initialize your devices.
  var iJoystick = new Joystick.InputDeviceWrapper();
  var oKeyboard = ApplicationState.oKeyboard = new Keyboard.OutputDeviceWrapper();

  // Initialize any modified axes
  ApplicationState.xAxis = iJoystick.x.normalizedBidirectional();
  ApplicationState.yAxis = iJoystick.y.normalizedBidirectional();

  // Wait for the game process before doing anything
  Process gameProcess = null;
  do {
    // WARNING remember to change process name from notepad to your game
    gameProcess = Process.GetProcessesByName("notepad").FirstOrDefault();
    // Wait for one second
    Thread.Sleep(1000);
  } while(gameProcess == null);

  ApplicationState.gameStarted = true;

  // Run while the game is running.
  do {
    SimIO.update();

    // Map main X and Y axis of joystick to WSAD keys
    oKeyboard.w.value = ApplicationState.yAxis.value < -0.5f ? 1 : 0;
    oKeyboard.s.value = ApplicationState.yAxis.value > 0.5f ? 1 : 0;
    oKeyboard.a.value = ApplicationState.xAxis.value < -0.5f ? 1 : 0;
    oKeyboard.d.value = ApplicationState.xAxis.value > 0.5f ? 1 : 0;

    // Sleep for 16 miliseconds. This will give a refresh rate of 60 frames per second.
    Thread.Sleep(16);
    // Refresh to see if the game process has exited
    gameProcess.Refresh();
  } while(!gameProcess.HasExited);
});

// Run the io thread
ioThread.Start();
// Run the web server
app.Run();

// Wait for simio thread to stop
ioThread.Join();