using System;
using System.Linq;
using System.Diagnostics;
using th.SimIO;
using th.SimIO.Selectors;

// Initialize your devices.
var iJoystick = new Joystick.InputDeviceWrapper();
var oKeyboard = new Keyboard.OutputDeviceWrapper();

// Initialize any modified axes
var xAxis = iJoystick.x.normalizedBidirectional();
var yAxis = iJoystick.y.normalizedBidirectional();


// Wait for the game process before doing anything
Process? gameProcess = null;
do {
  // WARNING remember to change process name from notepad to your game
  gameProcess = Process.GetProcessesByName("notepad").FirstOrDefault();
  // Wait for one second
  Thread.Sleep(1000);
} while(gameProcess == null);

Console.WriteLine("Game started");

// Run while the game is running.
do {
  SimIO.update();

  // Map main X and Y axis of joystick to WSAD keys
  oKeyboard.w.value = yAxis.value < -0.5f ? 1 : 0;
  oKeyboard.s.value = yAxis.value > 0.5f ? 1 : 0;
  oKeyboard.a.value = xAxis.value < -0.5f ? 1 : 0;
  oKeyboard.d.value = xAxis.value > 0.5f ? 1 : 0;

  // Sleep for 16 miliseconds. This will give a refresh rate of 60 frames per second.
  Thread.Sleep(16);
  // Refresh to see if the game process has exited
  gameProcess.Refresh();
} while(!gameProcess.HasExited);

Console.WriteLine("Game exited");