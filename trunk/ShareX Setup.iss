#define MyAppName "ShareX"
#define MyAppFile "ShareX.exe"
#define MyAppPath "ShareX\bin\Release\ShareX.exe"
#define MyAppVersion GetStringFileInfo(MyAppPath, "Assembly Version")
#define MyAppPublisher "ShareX Developers"
#define MyAppURL "http://code.google.com/p/sharex"

[Setup]
AllowNoIcons=true
AppCopyright=Copyright (C) 2012 {#MyAppPublisher}
AppId=82E6AC09-0FEF-4390-AD9F-0DD3F5561EFC
AppMutex=Global\82E6AC09-0FEF-4390-AD9F-0DD3F5561EFC
AppName={#MyAppName}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}/issues/list
AppUpdatesURL={#MyAppURL}/downloads/list
AppVerName={#MyAppName} {#MyAppVersion}
AppVersion={#MyAppVersion}
ArchitecturesAllowed=x86 x64 ia64
ArchitecturesInstallIn64BitMode=x64 ia64
Compression=lzma/ultra64
CreateAppDir=true
DefaultDirName={pf}\{#MyAppName}
DefaultGroupName={#MyAppName}
DirExistsWarning=no
InfoAfterFile=Docs\VersionHistory.txt
InfoBeforeFile=Docs\license.txt
InternalCompressLevel=ultra64
LanguageDetectionMethod=uilanguage
MinVersion=4.90.3000,5.0.2195sp3
OutputBaseFilename={#MyAppName}-{#MyAppVersion}-setup
OutputDir=Output\
PrivilegesRequired=admin
ShowLanguageDialog=auto
ShowUndisplayableLanguages=false
SignedUninstaller=false
SolidCompression=true
Uninstallable=true
UninstallDisplayIcon={app}\{#MyAppFile}
UsePreviousAppDir=yes
UsePreviousGroup=yes
VersionInfoCompany={#MyAppPublisher}
VersionInfoTextVersion={#MyAppVersion}
VersionInfoVersion={#MyAppVersion}

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "CreateDesktopIcon"; Description: "Create a desktop shortcut"; GroupDescription: "Additional shortcuts:"
Name: "CreateQuickLaunchIcon"; Description: "Create a quick launch shortcut"; GroupDescription: "Additional shortcuts:"; Flags: unchecked
Name: "CreateSendToIcon"; Description: "Create a send to shortcut"; GroupDescription: "Additional shortcuts:"; Flags: unchecked
Name: "CreateStartupIcon"; Description: "Run {#MyAppName} on Windows startup"; GroupDescription: "Other tasks:"; Flags: unchecked

[Files]
Source: "ShareX\bin\Release\*.exe"; Excludes: *.vshost.exe; DestDir: {app}; Flags: ignoreversion
;Source: "ShareX\bin\Release\*.pdb"; DestDir: {app}; Flags: ignoreversion
Source: "ShareX\bin\Release\*.dll"; DestDir: {app}; Flags: ignoreversion
Source: "ShareX\bin\Release\*.wav"; DestDir: {app}; Flags: ignoreversion

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppFile}"; WorkingDir: "{app}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"; WorkingDir: "{app}"
Name: "{userdesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppFile}"; WorkingDir: "{app}"; Tasks: CreateDesktopIcon; Check: not DesktopIconExists
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\{#MyAppName}"; Filename: "{app}\{#MyAppFile}"; WorkingDir: "{app}"; Tasks: CreateQuickLaunchIcon
Name: "{sendto}\{#MyAppName}"; Filename: "{app}\{#MyAppFile}"; WorkingDir: "{app}"; Tasks: CreateSendToIcon
Name: "{userstartup}\{#MyAppName}"; Filename: "{app}\{#MyAppFile}"; WorkingDir: "{app}"; Parameters: "-silent"; Tasks: CreateStartupIcon

[Run]
Filename: "{app}\{#MyAppFile}"; Description: {cm:LaunchProgram,{#MyAppName}}; Flags: nowait postinstall skipifsilent

;[Registry]
;Root: "HKCU"; Subkey: "Software\Microsoft\Windows\CurrentVersion\Run"; ValueName: "{#MyAppName}"; Flags: uninsdeletevalue
;Root: "HKCU"; Subkey: "Software\Classes\*\shell\{#MyAppName}"; Flags: uninsdeletekey
;Root: "HKCU"; Subkey: "Software\Classes\Folder\shell\{#MyAppName}"; Flags: uninsdeletekey

[Code]
function DesktopIconExists(): Boolean;
begin
  Result := FileExists(ExpandConstant('{commondesktop}\{#MyAppName}.lnk'));
end;
