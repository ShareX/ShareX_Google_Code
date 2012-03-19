#define MyAppName "ShareX"
#define ExePath "ShareX\bin\Release\ShareX.exe"
#define MyAppVersion GetStringFileInfo(ExePath, "Assembly Version")
#define MyAppPublisher "ZScreen Developers"
#define MyAppURL "http://code.google.com/p/sharex"

[Setup]
AllowNoIcons=true
AppMutex=Global\0167D1A0-6054-42f5-BA2A-243648899A6B
AppId={#MyAppName}
AppName={#MyAppName}
AppPublisher={#MyAppName}
AppPublisherURL=http://code.google.com/p/sharex
AppSupportURL=http://code.google.com/p/sharex/issues/list
AppUpdatesURL=http://code.google.com/p/sharex/downloads/list
AppVerName={#MyAppName} {#MyAppVersion}
AppVersion={#MyAppVersion}
ArchitecturesAllowed=x86 x64 ia64
ArchitecturesInstallIn64BitMode=x64 ia64
Compression=lzma/ultra64
CreateAppDir=true
DefaultDirName={pf}\{#MyAppName}
DefaultGroupName={#MyAppName}
DirExistsWarning=no
InfoBeforeFile=ShareX\Docs\VersionHistory.txt
InternalCompressLevel=ultra64
LanguageDetectionMethod=uilanguage
MinVersion=4.90.3000,5.0.2195sp3
OutputBaseFilename={#MyAppName}-{#MyAppVersion}-setup
OutputDir=Output\
PrivilegesRequired=none
ShowLanguageDialog=auto
ShowUndisplayableLanguages=false
SignedUninstaller=false
SolidCompression=true
Uninstallable=true
UninstallDisplayIcon={app}\{#MyAppName}.exe
UsePreviousAppDir=yes
UsePreviousGroup=yes
VersionInfoCompany={#MyAppName}
VersionInfoTextVersion={#MyAppVersion}
VersionInfoVersion={#MyAppVersion}

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "CreateDesktopIcon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"

[Files]
Source: ShareX\bin\Release\*.exe; Excludes: *.vshost.exe; DestDir: {app}; Flags: ignoreversion
Source: ShareX\bin\Release\*.pdb; DestDir: {app}; Flags: ignoreversion
Source: ShareX\bin\Release\*.dll; DestDir: {app}; Flags: ignoreversion
Source: ShareX\bin\Release\*.wav; DestDir: {app}; Flags: ignoreversion

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppName}.exe"
Name: "{group}\Uninstall {#MyAppName}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppName}.exe"; Check: not DesktopIconExists; Tasks: CreateDesktopIcon

[Run]
Filename: "{app}\{#MyAppName}.exe"; Description: {cm:LaunchProgram,ShareX}; Flags: nowait postinstall skipifsilent

[Registry]
Root: "HKCU"; Subkey: "Software\Microsoft\Windows\CurrentVersion\Run"; ValueName: "{#MyAppName}"; Flags: uninsdeletevalue
Root: "HKCU"; Subkey: "Software\Classes\*\shell\{#MyAppName}"; Flags: uninsdeletekey
Root: "HKCU"; Subkey: "Software\Classes\Folder\shell\{#MyAppName}"; Flags: uninsdeletekey

[Code]
function DesktopIconExists(): Boolean;
begin
  Result := FileExists(ExpandConstant('{commondesktop}\{#MyAppName}.lnk'));
end;
