[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{092C5E1D-BB21-47FA-B230-50CB72DB8A1E}
AppName=InKeyKeyboardCreator
AppVerName=InKeyKeyboardCreator 1.9.4
VersionInfoVersion=1.9.4
AppPublisher=Ben Chenoweth
AppPublisherURL=http://code.google.com/p/inkey-keyboard-creator/
AppSupportURL=http://wiki.inkeysoftware.com/doku.php?id=inkeykeyboardcreator
AppUpdatesURL=http://code.google.com/p/inkey-keyboard-creator/downloads/list

; Select destination directory depending on Windows version
DefaultDirName={reg:HKCU\Software\InKeyKeyboardCreator,Path|{pf}\InKeyKeyboardCreator}

DefaultGroupName=InKeyKeyboardCreator
UninstallDisplayIcon={app}\InKeyKeyboardCreator.exe
AllowNoIcons=yes
LicenseFile=InKeyKeyboardCreator License.txt
OutputBaseFilename=InKeyKeyboardCreator Setup 1.9.4
Compression=lzma
SolidCompression=yes
ChangesAssociations=yes

[Languages]
Name: english; MessagesFile: compiler:Default.isl

[Tasks]
Name: desktopicon; Description: {cm:CreateDesktopIcon}; GroupDescription: {cm:AdditionalIcons}; Flags: unchecked
Name: quicklaunchicon; Description: {cm:CreateQuickLaunchIcon}; GroupDescription: {cm:AdditionalIcons}; Flags: unchecked
Name: associate; Description: &Associate IKP files; GroupDescription: Other tasks:

[Files]
Source: InKeyKeyboardCreator.exe; DestDir: {app}; Flags: ignoreversion
Source: generic.ico; DestDir: {app}; Flags: ignoreversion
Source: InKeyKeyboardCreator License.txt; DestDir: {app}; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: {group}\InKeyKeyboardCreator; Filename: {app}\InKeyKeyboardCreator.exe
Name: {commondesktop}\InKeyKeyboardCreator; Filename: {app}\InKeyKeyboardCreator.exe; Tasks: desktopicon
Name: {userappdata}\Microsoft\Internet Explorer\Quick Launch\InKeyKeyboardCreator; Filename: {app}\InKeyKeyboardCreator.exe; Tasks: quicklaunchicon

[Registry]
Root: HKCU; Subkey: Software\InKeyKeyboardCreator; Flags: uninsdeletekeyifempty
Root: HKCU; Subkey: Software\InKeyKeyboardCreator; ValueType: string; ValueName: Path; ValueData: {app}; Flags: uninsdeletekey
Root: HKCR; SubKey: .ikp; ValueType: string; ValueData: IKP File; Flags: uninsdeletekey; Tasks: associate
Root: HKCR; SubKey: IKP File; ValueType: string; ValueData: IKP File; Flags: uninsdeletekey; Tasks: associate
Root: HKCR; SubKey: IKP File\Shell\Open\Command; ValueType: string; ValueData: """{app}\InKeyKeyboardCreator.exe"" ""%1"""; Flags: uninsdeletevalue; Tasks: associate
Root: HKCR; Subkey: IKP File\DefaultIcon; ValueType: string; ValueData: {app}\InKeyKeyboardCreator.exe,1; Flags: uninsdeletevalue; Tasks: associate

[Run]
Filename: {app}\InKeyKeyboardCreator.exe; Description: {cm:LaunchProgram,InKeyKeyboardCreator}; Flags: nowait postinstall skipifsilent
