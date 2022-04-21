/* ----------------------------------------------------------------------- *

    * HidUsage.cs

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
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace th.SimIO {

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
public class HidUsage
{
  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  public enum UsagePage : UInt16 {
    Unknown                 = 0x0,
    Any = Unknown,
    GenericDesktop          = 0x01, //  4. Generic Desktop Page
    SimulationControls      = 0x02, //  5. Simulation Controls Page
    VrControls              = 0x03, //  6. VR Controls Page
    SportControls           = 0x04, //  7. Sport Controls Page
    GameControls            = 0x05, //  8. Game Controls Page
    GenericDeviceControls   = 0x06, //  9. Generic Device Controls Page
    Keyboard                = 0x07, // 10. Keyboard/Keypad Page
    Led                     = 0x08, // 11. LED Page
    Button                  = 0x09, // 12. Button Page
    Ordinal                 = 0x0A, // 13. Ordinal Page
    Telephony               = 0x0B, // 14. Telephony Device Page
    Consumer                = 0x0C, // 15. Consumer Page
    Digitizers              = 0x0D, // 16. Digitizers
    Unicode                 = 0x10, // 17. Unicode Page
    AlphanumericDisplay     = 0x14, // 18. Alphanumeric Display Page
    MedicalInstrument       = 0x40, // 19. Medical Instrument Page
  }

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  public enum Usage : UInt16 {
    // Generic Desktop Page
    Pointer                           = 0x01, // CP     Pointer
    Mouse                             = 0x02, // CA     Mouse
    Joystick                          = 0x04, // CA     Joystick
    GamePad                           = 0x05, // CA     Game Pad
    Keyboard                          = 0x06, // CA     Keyboard
    Keypad                            = 0x07, // CA     Keypad
    MultiAxisController               = 0x08, // CA     Multi-axis Controller
    TabletPcSystemControls            = 0x09, // CA     Tablet PC System Controls
    X                                 = 0x30, // DV     X
    Y                                 = 0x31, // DV     Y
    Z                                 = 0x32, // DV     Z
    Rx                                = 0x33, // DV     Rx
    Ry                                = 0x34, // DV     Ry
    Rz                                = 0x35, // DV     Rz
    Slider                            = 0x36, // DV     Slider
    Dial                              = 0x37, // DV     Dial
    Wheel                             = 0x38, // DV     Wheel
    HatSwitch                         = 0x39, // DV     Hat switch
    CountedBuffer                     = 0x3A, // CL     Counted Buffer
    ByteCount                         = 0x3B, // DV     Byte Count
    MotionWakeup                      = 0x3C, // OSC    Motion Wakeup
    Start                             = 0x3D, // OOC    Start
    Select                            = 0x3E, // OOC    Select
    Vx                                = 0x40, // DV     Vx
    Vy                                = 0x41, // DV     Vy
    Vz                                = 0x42, // DV     Vz
    Vbrx                              = 0x43, // DV     Vbrx
    Vbry                              = 0x44, // DV     Vbry
    Vbrz                              = 0x45, // DV     Vbrz
    Vno                               = 0x46, // DV     Vno
    FeatureNotification               = 0x47, // DV,DF  Feature Notification
    ResolutionMultiplier              = 0x48, // DV     Resolution Multiplier
    SystemControl                     = 0x80, // CA     System Control
    SystemPowerDown                   = 0x81, // OSC    System Power Down
    SystemSleep                       = 0x82, // OSC    System Sleep
    SystemWakeUp                      = 0x83, // OSC    System Wake Up
    SystemContextMenu                 = 0x84, // OSC    System Context Menu
    SystemMainMenu                    = 0x85, // OSC    System Main Menu
    SystemAppMenu                     = 0x86, // OSC    System App Menu
    SystemMenuHelp                    = 0x87, // OSC    System Menu Help
    SystemMenuExit                    = 0x88, // OSC    System Menu Exit
    SystemMenuSelect                  = 0x89, // OSC    System Menu Select
    SystemMenuRight                   = 0x8A, // RTC    System Menu Right
    SystemMenuLeft                    = 0x8B, // RTC    System Menu Left
    SystemMenuUp                      = 0x8C, // RTC    System Menu Up
    SystemMenuDown                    = 0x8D, // RTC    System Menu Down
    SystemColdRestart                 = 0x8E, // OSC    System Cold Restart
    SystemWarmRestart                 = 0x8F, // OSC    System Warm Restart
    DPadUp                            = 0x90, // OOC    D-pad Up
    DPadDown                          = 0x91, // OOC    D-pad Down
    DPadRight                         = 0x92, // OOC    D-pad Right
    DPadLeft                          = 0x93, // OOC    D-pad Left
    SystemDock                        = 0xA0, // OSC    System Dock
    SystemUndock                      = 0xA1, // OSC    System Undock
    SystemSetup                       = 0xA2, // OSC    System Setup
    SystemBreak                       = 0xA3, // OSC    System Break
    SystemDebuggerBreak               = 0xA4, // OSC    System Debugger Break
    ApplicationBreak                  = 0xA5, // OSC    Application Break
    ApplicationDebuggerBreak          = 0xA6, // OSC    Application Debugger Break
    SystemSpeakerMute                 = 0xA7, // OSC    System Speaker Mute
    SystemHibernate                   = 0xA8, // OSC    System Hibernate
    SystemDisplayInvert               = 0xB0, // OSC    System Display Invert
    SystemDisplayInternal             = 0xB1, // OSC    System Display Internal
    SystemDisplayExternal             = 0xB2, // OSC    System Display External
    SystemDisplayBoth                 = 0xB3, // OSC    System Display Both
    SystemDisplayDual                 = 0xB4, // OSC    System Display Dual
    SystemDisplayToggleIntExt         = 0xB5, // OSC    System Display Toggle Int/Ext
    SystemDisplaySwapPrimarySecondary = 0xB6, // OSC    System Display Swap Primary/Secondary
    SystemDisplayLcdAutoscale         = 0xB7, // OSC    System Display LCD Autoscale

    // Simulation controls page
    FlightSimulationDevice            = 0x01, // CA     Flight Simulation Device
    AutomobileSimulationDevice        = 0x02, // CA     Automobile Simulation Device
    TankSimulationDevice              = 0x03, // CA     Tank Simulation Device
    SpaceshipSimulationDevice         = 0x04, // CA     Spaceship Simulation Device
    SubmarineSimulationDevice         = 0x05, // CA     Submarine Simulation Device
    SailingSimulationDevice           = 0x06, // CA     Sailing Simulation Device
    MotorcycleSimulationDevice        = 0x07, // CA     Motorcycle Simulation Device
    SportsSimulationDevice            = 0x08, // CA     Sports Simulation Device
    AirplaneSimulationDevice          = 0x09, // CA     Airplane Simulation Device
    HelicopterSimulationDevice        = 0x0A, // CA     Helicopter Simulation Device
    MagicCarpetSimulationDevice       = 0x0B, // CA     Magic Carpet Simulation Device
    BicycleSimulationDevice           = 0x0C, // CA     Bicycle Simulation Device
    FlightControlStick                = 0x20, // CA     Flight Control Stick
    FlightStick                       = 0x21, // CA     Flight Stick
    CyclicControl                     = 0x22, // CP     Cyclic Control
    CyclicTrim                        = 0x23, // CP     Cyclic Trim
    FlightYoke                        = 0x24, // CA     Flight Yoke
    TrackControl                      = 0x25, // CP     Track Control
    Aileron                           = 0xB0, // DV     Aileron
    AileronTrim                       = 0xB1, // DV     Aileron Trim
    AntiTorqueControl                 = 0xB2, // DV     Anti-Torque Control
    AutopilotEnable                   = 0xB3, // OOC    Autopilot Enable
    ChaffRelease                      = 0xB4, // OSC    Chaff Release
    CollectiveControl                 = 0xB5, // DV     Collective Control
    DiveBrake                         = 0xB6, // DV     Dive Brake
    ElectronicCountermeasures         = 0xB7, // OOC    Electronic Countermeasures
    Elevator                          = 0xB8, // DV     Elevator
    ElevatorTrim                      = 0xB9, // DV     Elevator Trim
    Rudder                            = 0xBA, // DV     Rudder
    Throttle                          = 0xBB, // DV     Throttle
    FlightCommunications              = 0xBC, // OOC    Flight Communications
    FlareRelease                      = 0xBD, // OSC    Flare Release
    LandingGear                       = 0xBE, // OOC    Landing Gear
    ToeBrake                          = 0xBF, // DV     Toe Brake
    Trigger                           = 0xC0, // MC     Trigger
    WeaponsArm                        = 0xC1, // OOC    Weapons Arm
    WeaponsSelect                     = 0xC2, // OSC    Weapons Select
    WingFlaps                         = 0xC3, // DV     Wing Flaps
    Accelerator                       = 0xC4, // DV     Accelerator
    Brake                             = 0xC5, // DV     Brake
    Clutch                            = 0xC6, // DV     Clutch
    Shifter                           = 0xC7, // DV     Shifter
    Steering                          = 0xC8, // DV     Steering
    TurretDirection                   = 0xC9, // DV     Turret Direction
    BarrelElevation                   = 0xCA, // DV     Barrel Elevation
    DivePlane                         = 0xCB, // DV     Dive Plane
    Ballast                           = 0xCC, // DV     Ballast
    BicycleCrank                      = 0xCD, // DV     Bicycle Crank
    HandleBars                        = 0xCE, // DV     Handle Bars
    FrontBrake                        = 0xCF, // DV     Front Brake
    RearBrake                         = 0xD0, // DV     Rear Brake

    // VR Controls Page
    Belt                              = 0x01, // CA     Belt
    BodySuit                          = 0x02, // CA     Body Suit
    Flexor                            = 0x03, // CP     Flexor
    Glove                             = 0x04, // CA     Glove
    HeadTracker                       = 0x05, // CP     Head Tracker
    HeadMountedDisplay                = 0x06, // CA     Head Mounted Display
    HandTracker                       = 0x07, // CA     Hand Tracker
    Oculometer                        = 0x08, // CA     Oculometer
    Vest                              = 0x09, // CA     Vest
    AnimatronicDevice                 = 0x0A, // CA     Animatronic Device
    StereoEnable                      = 0x20, // OOC    Stereo Enable
    DisplayEnable                     = 0x21, // OOC    Display Enable

    // Sport Controls Page
    BaseballBat                       = 0x01, // CA     Baseball Bat
    GolfClub                          = 0x02, // CA     Golf Club
    RowingMachine                     = 0x03, // CA     Rowing Machine
    Treadmill                         = 0x04, // CA     Treadmill
    Oar                               = 0x30, // DV     Oar
    Slope                             = 0x31, // DV     Slope
    Rate                              = 0x32, // DV     Rate
    StickSpeed                        = 0x33, // DV     Stick Speed
    StickFaceAngle                    = 0x34, // DV     Stick Face Angle
    StickHeelToe                      = 0x35, // DV     Stick Heel/Toe
    StickFollowThrough                = 0x36, // DV     Stick Follow Through
    StickTempo                        = 0x37, // DV     Stick Tempo
    StickType                         = 0x38, // NAry   Stick Type
    StickHeight                       = 0x39, // DV     Stick Height
    Putter                            = 0x50, // Sel    Putter
    Iron1                             = 0x51, // Sel    1 Iron
    Iron2                             = 0x52, // Sel    2 Iron
    Iron3                             = 0x53, // Sel    3 Iron
    Iron4                             = 0x54, // Sel    4 Iron
    Iron5                             = 0x55, // Sel    5 Iron
    Iron6                             = 0x56, // Sel    6 Iron
    Iron7                             = 0x57, // Sel    7 Iron
    Iron8                             = 0x58, // Sel    8 Iron
    Iron9                             = 0x59, // Sel    9 Iron
    Iron10                            = 0x5A, // Sel    10 Iron
    Iron11                            = 0x5B, // Sel    11 Iron
    SandWedge                         = 0x5C, // Sel    Sand Wedge
    LoftWedge                         = 0x5D, // Sel    Loft Wedge
    PowerWedge                        = 0x5E, // Sel    Power Wedge
    Wood1                             = 0x5F, // Sel    1 Wood
    Wood3                             = 0x60, // Sel    3 Wood
    Wood5                             = 0x61, // Sel    5 Wood
    Wood7                             = 0x62, // Sel    7 Wood
    Wood9                             = 0x63, // Sel    9 Wood

    // Game Controls Page
    ThreeDGameController              = 0x01, // CA     3D Game Controller
    PinballDevice                     = 0x02, // CA     Pinball Device
    GunDevice                         = 0x03, // CA     Gun Device
    PointOfView                       = 0x20, // CP     Point of View
    TurnRightLeft                     = 0x21, // DV     Turn Right/Left
    PitchForwardBackward              = 0x22, // DV     Pitch Forward/Backward
    RollRightLeft                     = 0x23, // DV     Roll Right/Left
    MoveRightLeft                     = 0x24, // DV     Move Right/Left
    MoveForwardBackward               = 0x25, // DV     Move Forward/Backward
    MoveUpDown                        = 0x26, // DV     Move Up/Down
    LeanRightLeft                     = 0x27, // DV     Lean Right/Left
    LeanForwardBackward               = 0x28, // DV     Lean Forward/Backward
    HeightOfPov                       = 0x29, // DV     Height of POV
    Flipper                           = 0x2A, // MC     Flipper
    SecondaryFlipper                  = 0x2B, // MC     Secondary Flipper
    Bump                              = 0x2C, // MC     Bump
    NewGame                           = 0x2D, // OSC    New Game
    ShootBall                         = 0x2E, // OSC    Shoot Ball
    Player                            = 0x2F, // OSC    Player
    GunBolt                           = 0x30, // OOC    Gun Bolt
    GunClip                           = 0x31, // OOC    Gun Clip
    GunSelector                       = 0x32, // NAry   Gun Selector
    GunSingleShot                     = 0x33, // Sel    Gun Single Shot
    GunBurst                          = 0x34, // Sel    Gun Burst
    GunAutomatic                      = 0x35, // Sel    Gun Automatic
    GunSafety                         = 0x36, // OOC    Gun Safety
    GamepadFireJump                   = 0x37, // CL     Gamepad Fire/Jump
    GamepadTrigger                    = 0x39, // CL     Gamepad Trigger

    // Generic Device Controls Page
    BatteryStrength                   = 0x20, // DV     Battery Strength
    WirelessChannel                   = 0x21, // DV     Wireless Channel
    WirelessId                        = 0x22, // DV     Wireless ID
    DiscoverWirelessControl           = 0x23, // OSC    Discover Wireless Control
    SecurityCodeCharacterEntered      = 0x24, // OSC    Security Code Character Entered
    SecurityCodeCharacterErased       = 0x25, // OSC    Security Code Character Erased
    SecurityCodeCleared               = 0x26, // OSC    Security Code Cleared

    // Keyboard page
    KeyA                              =   4,
    KeyB                              =   5,
    KeyC                              =   6,
    KeyD                              =   7,
    KeyE                              =   8,
    KeyF                              =   9,
    KeyG                              =  10,
    KeyH                              =  11,
    KeyI                              =  12,
    KeyJ                              =  13,
    KeyK                              =  14,
    KeyL                              =  15,
    KeyM                              =  16,
    KeyN                              =  17,
    KeyO                              =  18,
    KeyP                              =  19,
    KeyQ                              =  20,
    KeyR                              =  21,
    KeyS                              =  22,
    KeyT                              =  23,
    KeyU                              =  24,
    KeyV                              =  25,
    KeyW                              =  26,
    KeyX                              =  27,
    KeyY                              =  28,
    KeyZ                              =  29,
    Key1                              =  30,
    Key2                              =  31,
    Key3                              =  32,
    Key4                              =  33,
    Key5                              =  34,
    Key6                              =  35,
    Key7                              =  36,
    Key8                              =  37,
    Key9                              =  38,
    Key0                              =  39,
    KeyEnter                          =  40,
    KeyEscape                         =  41,
    KeyBackspace                      =  42,
    KeyTab                            =  43,
    KeySpace                          =  44,
    KeyMinus                          =  45,
    KeyEquals                         =  46,
    KeyLeftBracket                    =  47,
    KeyRightBracket                   =  48,
    KeyBackslash                      =  49,
    KeySemicolon                      =  51,
    KeyQuote                          =  52,
    KeyGrave                          =  53,
    KeyComma                          =  54,
    KeyPeriod                         =  55,
    KeySlash                          =  56,
    KeyCapslock                       =  57,
    KeyF1                             =  58,
    KeyF2                             =  59,
    KeyF3                             =  60,
    KeyF4                             =  61,
    KeyF5                             =  62,
    KeyF6                             =  63,
    KeyF7                             =  64,
    KeyF8                             =  65,
    KeyF9                             =  66,
    KeyF10                            =  67,
    KeyF11                            =  68,
    KeyF12                            =  69,
    KeyPrintScreen                    =  70,
    KeyScrollLock                     =  71,
    KeyPause                          =  72,
    KeyInsert                         =  73,
    KeyHome                           =  74,
    KeyPageup                         =  75,
    KeyDeleteForward                  =  76,
    KeyEnd                            =  77,
    KeyPageDown                       =  78,
    KeyRight                          =  79,
    KeyLeft                           =  80,
    KeyDown                           =  81,
    KeyUp                             =  82,
    KeyKpNumLock                      =  83,
    KeyKpDivide                       =  84,
    KeyKpMultiply                     =  85,
    KeyKpSubtract                     =  86,
    KeyKpAdd                          =  87,
    KeyKpEnter                        =  88,
    KeyKp1                            =  89,
    KeyKp2                            =  90,
    KeyKp3                            =  91,
    KeyKp4                            =  92,
    KeyKp5                            =  93,
    KeyKp6                            =  94,
    KeyKp7                            =  95,
    KeyKp8                            =  96,
    KeyKp9                            =  97,
    KeyKp0                            =  98,
    KeyKpPoint                        =  99,
    KeyNonUsBackslash                 = 100,
    KeyKpEquals                       = 103,
    KeyF13                            = 104,
    KeyF14                            = 105,
    KeyF15                            = 106,
    KeyF16                            = 107,
    KeyF17                            = 108,
    KeyF18                            = 109,
    KeyF19                            = 110,
    KeyF20                            = 111,
    KeyF21                            = 112,
    KeyF22                            = 113,
    KeyF23                            = 114,
    KeyF24                            = 115,
    KeyHelp                           = 117,
    KeyMenu                           = 118,
    KeyMute                           = 127,
    KeySysreq                         = 154,
    KeyReturn                         = 158,
    KeyKpClear                        = 216,
    KeyKpDecimal                      = 220,
    KeyLeftControl                    = 224,
    KeyLeftShift                      = 225,
    KeyLeftAlt                        = 226,
    KeyLeftGui                        = 227,
    KeyRightControl                   = 228,
    KeyRightShift                     = 229,
    KeyRightAlt                       = 230,
    KeyRightGui                       = 231,
  }
}

} // End of namespace th.simio
