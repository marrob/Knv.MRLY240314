; -- Inno Setup Installer script --
#define MyAppName "MRLY240314"
#define MyAppVersion GetVersionNumbersString("..\Knv.MRLY240314\bin\Debug\Knv.MRLY240314.exe")
#define MyAppIconFileName "AppIcon.ico"
#define MyAppStartMenuFolder "Konvolúció Bt"
#define MyAppPublisher "Konvolúció Bt"

[Setup]
; The value of AppId uniquely identifies this application
AppId={{8AF65D73-D170-49F9-8AD5-81AA78F31F00}

AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
WizardStyle=modern
DefaultDirName={autopf}\Konvolucio\{#MyAppName}

 ;If this is set to yes, Setup will not show the Select Start Menu Folder wizard page
DisableProgramGroupPage=yes

DefaultGroupName={#MyAppStartMenuFolder}
UninstallDisplayIcon={app}\{#MyAppIconFileName}
Compression=lzma2
SolidCompression=no
OutputDir = ".\Release"
OutputBaseFilename= Setup_{#MyAppName}_v{#MyAppVersion}

;--- for driver setup ---
PrivilegesRequired=admin 

[Files]
;--- App Files ---
Source: "..\Knv.MRLY240314\bin\Debug\Knv.MRLY240314.exe"; DestDir: "{app}"

;--- Icon ---
Source: ".\Resources\AppIcon.ico"; DestDir: "{app}"

;Source: "MyProg.chm"; DestDir: "{app}"
;Source: "Readme.txt"; DestDir: "{app}"; Flags: isreadme

;--- FTDI ---
Source: ".\Resources\FTDI\amd64\ftbusui.dll"; DestDir: "{app}\FTDI\amd64"
Source: ".\Resources\FTDI\amd64\ftcserco.dll"; DestDir: "{app}\FTDI\amd64"
Source: ".\Resources\FTDI\amd64\ftd2xx.lib"; DestDir: "{app}\FTDI\amd64"
Source: ".\Resources\FTDI\amd64\ftd2xx64.dll"; DestDir: "{app}\FTDI\amd64"
Source: ".\Resources\FTDI\amd64\ftdibus.sys"; DestDir: "{app}\FTDI\amd64"
Source: ".\Resources\FTDI\amd64\ftlang.dll"; DestDir: "{app}\FTDI\amd64"
Source: ".\Resources\FTDI\amd64\ftser2k.sys"; DestDir: "{app}\FTDI\amd64"
Source: ".\Resources\FTDI\amd64\ftserui2.dll"; DestDir: "{app}\FTDI\amd64"

Source: ".\Resources\FTDI\i386\ftbusui.dll"; DestDir: "{app}\FTDI\i386"
Source: ".\Resources\FTDI\i386\ftcserco.dll"; DestDir: "{app}\FTDI\i386"
Source: ".\Resources\FTDI\i386\ftd2xx.dll"; DestDir: "{app}\FTDI\i386"
Source: ".\Resources\FTDI\i386\ftd2xx.lib"; DestDir: "{app}\FTDI\i386"
Source: ".\Resources\FTDI\i386\ftdibus.sys"; DestDir: "{app}\FTDI\i386"
Source: ".\Resources\FTDI\i386\ftlang.dll"; DestDir: "{app}\FTDI\i386"
Source: ".\Resources\FTDI\i386\ftser2k.sys"; DestDir: "{app}\FTDI\i386"
Source: ".\Resources\FTDI\i386\ftserui2.dll"; DestDir: "{app}\FTDI\i386"

Source: ".\Resources\FTDI\ftdibus.cat"; DestDir: "{app}\FTDI"
Source: ".\Resources\FTDI\ftdibus.inf"; DestDir: "{app}\FTDI"
Source: ".\Resources\FTDI\ftdiport.cat"; DestDir: "{app}\FTDI"
Source: ".\Resources\FTDI\ftdiport.inf"; DestDir: "{app}\FTDI"
Source: ".\Resources\FTDI\ftd2xx.h"; DestDir: "{app}\FTDI\i386"

Source: ".\Resources\FTDI\dpinst-x86.exe"; DestDir: "{app}\FTDI"
Source: ".\Resources\FTDI\dpinst-amd64.exe"; DestDir: "{app}\FTDI"

Source: ".\Resources\FTDI\LatencyTimer.JPG"; DestDir: "{app}\FTDI"


[Icons]
;for Start Menu
Name: "{group}\{#MyAppName}"; Filename: "{app}\Knv.MRLY240314.exe"; IconFilename: "{app}\{#MyAppIconFileName}"
;for Desktop
Name: "{commondesktop}\{#MyAppName}"; Filename:"{app}\Knv.MRLY240314.exe"; IconFilename: "{app}\{#MyAppIconFileName}"

[Run]
;--- FTDI ---
Filename: "{app}\FTDI\dpinst-x86.exe";   Check: not IsWin64;
Filename: "{app}\FTDI\dpinst-amd64.exe"; Check: IsWin64;

[UninstallRun]
;--- FTDI ---
Filename: "{app}\FTDI\dpinst-amd64.exe"; Parameters: "/U ftdibus.inf"; Check: IsWin64;    RunOnceId:"ftdibus_amd64";
Filename: "{app}\FTDI\dpinst-amd64.exe"; Parameters: "/U ftdiport.inf"; Check: IsWin64;   RunOnceId:"ftdiport_amd64";
Filename: "{app}\FTDI\dpinst-x86.exe"; Parameters: "/U ftdibus.inf"; Check: not IsWin64;  RunOnceId:"ftdibus_x86";
Filename: "{app}\FTDI\dpinst-x86.exe"; Parameters: "/U ftdiport.inf"; Check: not IsWin64; RunOnceId:"ftdiport_x86";