#define ExeName "ScreenLoad"
#define Version "2.0.2.0"
#define FileVersion "2.0.2.0-local"

; Include the scripts to install .NET Framework
; See http://www.codeproject.com/KB/install/dotnetfx_innosetup_instal.aspx
#include "scripts\products.iss"
#include "scripts\products\stringversion.iss"
#include "scripts\products\winversion.iss"
#include "scripts\products\fileversion.iss"
#include "scripts\products\msi20.iss"
#include "scripts\products\msi31.iss"
#include "scripts\products\dotnetfxversion.iss"
#include "scripts\products\dotnetfx35sp1.iss"

[Files]
Source: ..\..\bin\Release\ScreenLoad.exe; DestDir: {app}; Components: screenload; Flags: overwritereadonly ignoreversion replacesameversion
Source: ..\..\bin\Release\ScreenLoadPlugin.dll; DestDir: {app}; Components: screenload; Flags: overwritereadonly ignoreversion replacesameversion
Source: ..\..\bin\Release\ScreenLoad.exe.config; DestDir: {app}; Components: screenload; Flags: overwritereadonly ignoreversion replacesameversion
Source: ..\..\bin\Release\log4net.dll; DestDir: {app}; Components: screenload; Flags: overwritereadonly ignoreversion replacesameversion
Source: ..\..\bin\Release\LinqBridge.dll; DestDir: {app}; Components: screenload; Flags: overwritereadonly ignoreversion 
Source: ..\..\log4net.xml; DestDir: {app}; Components: screenload; Flags: overwritereadonly ignoreversion 
Source: ..\..\bin\Release\checksum.MD5; DestDir: {app}; Components: screenload; Flags: overwritereadonly ignoreversion replacesameversion
Source: ..\additional_files\installer.txt; DestDir: {app}; Components: screenload; Flags: overwritereadonly recursesubdirs ignoreversion replacesameversion
Source: ..\additional_files\license.txt; DestDir: {app}; Components: screenload; Flags: overwritereadonly recursesubdirs ignoreversion replacesameversion

; Core language files
Source: ..\..\Languages\*en-US*; Excludes: "*installer*,*website*"; DestDir: {app}\Languages; Components: screenload; Flags: overwritereadonly ignoreversion replacesameversion;

; Additional language files
Source: ..\..\Languages\*ru-RU*; Excludes: "*installer*,*website*"; DestDir: {app}\Languages; Components: languages\ruRU; Flags: overwritereadonly ignoreversion replacesameversion;

;DownloadRu Plugin
Source: ..\..\bin\Release\Plugins\ScreenLoadDownloadRuPlugin\ScreenLoadDownloadRuPlugin.gsp; DestDir: {app}\Plugins\ScreenLoadDownloadRuPlugin; Components: plugins\downloadru; Flags: overwritereadonly recursesubdirs ignoreversion replacesameversion;
Source: ..\..\bin\Release\Languages\Plugins\ScreenLoadDownloadRuPlugin\*; DestDir: {app}\Languages\Plugins\ScreenLoadDownloadRuPlugin; Components: plugins\downloadru; Flags: overwritereadonly ignoreversion replacesameversion;

;ExternalCommand Plugin
Source: ..\..\bin\Release\Plugins\ScreenLoadExternalCommandPlugin\ScreenLoadExternalCommandPlugin.gsp; DestDir: {app}\Plugins\ScreenLoadExternalCommandPlugin; Components: plugins\externalcommand; Flags: overwritereadonly recursesubdirs ignoreversion replacesameversion;
Source: ..\..\bin\Release\Languages\Plugins\ScreenLoadExternalCommandPlugin\*; DestDir: {app}\Languages\Plugins\ScreenLoadExternalCommandPlugin; Components: plugins\externalcommand; Flags: overwritereadonly ignoreversion replacesameversion;

[Setup]
; changes associations is used when the installer installs new extensions, it clears the explorer icon cache
ChangesAssociations=yes
AppId={#ExeName}
AppName={#ExeName}
AppMutex=7D7D15C8-1740-4CE8-A22D-ED0B81F2CFAE
AppPublisher={#ExeName}
AppPublisherURL=https://download.ru
AppSupportURL=https://download.ru
AppUpdatesURL=https://download.ru
AppVerName={#ExeName} {#Version}
AppVersion={#Version}
ArchitecturesInstallIn64BitMode=x64
Compression=lzma2/ultra64
SolidCompression=yes
DefaultDirName={code:DefDirRoot}\{#ExeName}
DefaultGroupName={#ExeName}
LicenseFile=..\additional_files\license.txt
LanguageDetectionMethod=uilanguage
MinVersion=0,5.01.2600
OutputBaseFilename={#ExeName}-INSTALLER-{#FileVersion}
OutputDir=..\
PrivilegesRequired=none
SetupIconFile=..\..\icons\applicationIcon\icon.ico
; Create a SHA1 signature
SignTool=SignTool sign /sha1  /fd sha1 /t http://timestamp.comodoca.com/rfc3161 $f
; Append a SHA256 to the previous SHA1 signature (this is what as does)
SignTool=SignTool sign /sha1  /as /fd sha256 /tr http://timestamp.comodoca.com/rfc3161 /td sha256 $f
SignedUninstaller=yes
UninstallDisplayIcon={app}\{#ExeName}.exe
Uninstallable=true
VersionInfoCompany={#ExeName}
VersionInfoProductName={#ExeName}
VersionInfoTextVersion={#Version}
VersionInfoVersion={#Version}
; Reference a bitmap, max size 164x314
WizardImageFile=installer-large.bmp
; Reference a bitmap, max size 55x58
WizardSmallImageFile=installer-small.bmp
[Registry]
; Delete all startup entries, so we don't have leftover values
Root: HKCU; Subkey: Software\Microsoft\Windows\CurrentVersion\Run; ValueType: none; ValueName: {#ExeName}; Flags: deletevalue noerror;
Root: HKLM; Subkey: Software\Microsoft\Windows\CurrentVersion\Run; ValueType: none; ValueName: {#ExeName}; Flags: deletevalue noerror;
Root: HKCU32; Subkey: Software\Microsoft\Windows\CurrentVersion\Run; ValueType: none; ValueName: {#ExeName}; Flags: deletevalue noerror; Check: IsWin64()
Root: HKLM32; Subkey: Software\Microsoft\Windows\CurrentVersion\Run; ValueType: none; ValueName: {#ExeName}; Flags: deletevalue noerror; Check: IsWin64()

; delete filetype mappings
; HKEY_LOCAL_USER - for current user only
Root: HKCU; Subkey: Software\Classes\.screenload; ValueType: none; ValueName: {#ExeName}; Flags: deletevalue noerror;
Root: HKCU; Subkey: Software\Classes\ScreenLoad; ValueType: none; ValueName: {#ExeName}; Flags: deletevalue noerror;
; HKEY_LOCAL_MACHINE - for all users when admin (with the noerror this doesn't matter)
Root: HKLM; Subkey: Software\Classes\.screenload; ValueType: none; ValueName: {#ExeName}; Flags: deletevalue noerror;
Root: HKLM; Subkey: Software\Classes\ScreenLoad; ValueType: none; ValueName: {#ExeName}; Flags: deletevalue noerror;

; Create the startup entries if requested to do so
; HKEY_LOCAL_USER - for current user only
Root: HKCU; Subkey: Software\Microsoft\Windows\CurrentVersion\Run; ValueType: string; ValueName: {#ExeName}; ValueData: {app}\{#ExeName}.exe; Permissions: users-modify; Flags: uninsdeletevalue noerror; Tasks: startup; Check: IsRegularUser
; HKEY_LOCAL_MACHINE - for all users when admin
Root: HKLM; Subkey: Software\Microsoft\Windows\CurrentVersion\Run; ValueType: string; ValueName: {#ExeName}; ValueData: {app}\{#ExeName}.exe; Permissions: admins-modify; Flags: uninsdeletevalue noerror; Tasks: startup; Check: not IsRegularUser

; Register our own filetype for all users
; HKEY_LOCAL_USER - for current user only
Root: HKCU; Subkey: Software\Classes\.screenload; ValueType: string; ValueName: ""; ValueData: "ScreenLoad"; Permissions: users-modify; Flags: uninsdeletevalue noerror; Check: IsRegularUser
Root: HKCU; Subkey: Software\Classes\ScreenLoad; ValueType: string; ValueName: ""; ValueData: "ScreenLoad File"; Permissions: users-modify; Flags: uninsdeletevalue noerror; Check: IsRegularUser
Root: HKCU; Subkey: Software\Classes\ScreenLoad\DefaultIcon; ValueType: string; ValueName: ""; ValueData: "{app}\ScreenLoad.EXE,0"; Permissions: users-modify; Flags: uninsdeletevalue noerror; Check: IsRegularUser
Root: HKCU; Subkey: Software\Classes\ScreenLoad\shell\open\command; ValueType: string; ValueName: ""; ValueData: """{app}\ScreenLoad.EXE"" --openfile ""%1"""; Permissions: users-modify; Flags: uninsdeletevalue noerror; Check: IsRegularUser
; HKEY_LOCAL_MACHINE - for all users when admin
Root: HKLM; Subkey: Software\Classes\.screenload; ValueType: string; ValueName: ""; ValueData: "ScreenLoad"; Permissions: admins-modify; Flags: uninsdeletevalue noerror; Check: not IsRegularUser
Root: HKLM; Subkey: Software\Classes\ScreenLoad; ValueType: string; ValueName: ""; ValueData: "ScreenLoad File"; Permissions: admins-modify; Flags: uninsdeletevalue noerror; Check: not IsRegularUser
Root: HKLM; Subkey: Software\Classes\ScreenLoad\DefaultIcon; ValueType: string; ValueName: ""; ValueData: "{app}\ScreenLoad.EXE,0"; Permissions: admins-modify; Flags: uninsdeletevalue noerror; Check: not IsRegularUser
Root: HKLM; Subkey: Software\Classes\ScreenLoad\shell\open\command; ValueType: string; ValueName: ""; ValueData: """{app}\ScreenLoad.EXE"" --openfile ""%1"""; Permissions: admins-modify; Flags: uninsdeletevalue noerror; Check: not IsRegularUser

[Icons]
Name: {group}\{#ExeName}; Filename: {app}\{#ExeName}.exe; WorkingDir: {app}
Name: {group}\Uninstall {#ExeName}; Filename: {uninstallexe}; WorkingDir: {app}; AppUserModelID: "{#ExeName}.{#ExeName}"
Name: {group}\License.txt; Filename: {app}\license.txt; WorkingDir: {app}

[Languages]
Name: en; MessagesFile: compiler:Default.isl
Name: ru; MessagesFile: compiler:Languages\Russian.isl

[Tasks]
Name: startup; Description: {cm:startup}

[CustomMessages]
en.default=Default installation
en.externalcommand=Open with external command plug-in
en.language=Additional languages
en.optimize=Optimizing performance, this may take a while.
en.startscreenload=Start {#ExeName}
en.startup=Start {#ExeName} with Windows start
en.downloadru=Download.RU plug-in

ru.default=Установка по умолчанию
ru.externalcommand=Плагин для использования установленных программ
ru.language=Дополнительные языки
ru.optimize=Оптимизация производительности, это может занять некоторое время.
ru.startscreenload=Запустить {#ExeName}
ru.startup=Автоматический запуск {#ExeName} при загрузке Windows
ru.downloadru=Плагин Download.RU

[Types]
Name: "default"; Description: "{cm:default}"
Name: "full"; Description: "{code:FullInstall}"
Name: "compact"; Description: "{code:CompactInstall}"
Name: "custom"; Description: "{code:CustomInstall}"; Flags: iscustom

[Components]
Name: "screenload"; Description: "ScreenLoad"; Types: default full compact custom; Flags: fixed
Name: "plugins\downloadru"; Description: {cm:downloadru}; Types: default full compact custom; Flags: fixed
Name: "plugins\externalcommand"; Description: {cm:externalcommand}; Types: default full custom; Flags: disablenouninstallwarning 
Name: "languages"; Description: {cm:language}; Types: default full custom; Flags: disablenouninstallwarning
Name: "languages\ruRU"; Description: "Pусский"; Types: default full custom; Flags: disablenouninstallwarning; Check: hasLanguageGroup('5')

[Code]
// Do we have a regular user trying to install this?
function IsRegularUser(): Boolean;
begin
	Result := not (IsAdminLoggedOn or IsPowerUserLoggedOn);
end;

// The following code is used to select the installation path, this is localappdata if non poweruser
function DefDirRoot(Param: String): String;
begin
	if IsRegularUser then
		Result := ExpandConstant('{localappdata}')
	else
		Result := ExpandConstant('{pf}')
end;
	

function FullInstall(Param : String) : String;
begin
	result := SetupMessage(msgFullInstallation);
end;

function CustomInstall(Param : String) : String;
begin
	result := SetupMessage(msgCustomInstallation);
end;

function CompactInstall(Param : String) : String;
begin
	result := SetupMessage(msgCompactInstallation);
end;
/////////////////////////////////////////////////////////////////////
// The following uninstall code was found at:
// http://stackoverflow.com/questions/2000296/innosetup-how-to-automatically-uninstall-previous-installed-version
// and than modified to work in a 32/64 bit environment
/////////////////////////////////////////////////////////////////////
function GetUninstallStrings(): array of String;
var
	sUnInstPath: String;
	sUnInstallString: String;
	asUninstallStrings : array of String;
	index : Integer;
begin
	sUnInstPath := ExpandConstant('Software\Microsoft\Windows\CurrentVersion\Uninstall\{#emit SetupSetting("AppId")}_is1');
	sUnInstallString := '';
	index := 0;
	
	// Retrieve uninstall string from HKLM32 or HKCU32
	if RegQueryStringValue(HKLM32, sUnInstPath, 'UninstallString', sUnInstallString) then
	begin
		SetArrayLength(asUninstallStrings, index + 1);
		asUninstallStrings[index] := sUnInstallString;
		index := index +1;
	end;

	if RegQueryStringValue(HKCU32, sUnInstPath, 'UninstallString', sUnInstallString) then
	begin
		SetArrayLength(asUninstallStrings, index + 1);
		asUninstallStrings[index] := sUnInstallString;
		index := index +1;
	end;
	
	// Only for Windows with 64 bit support: Retrieve uninstall string from HKLM64 or HKCU64
	if IsWin64 then
	begin
		if RegQueryStringValue(HKLM64, sUnInstPath, 'UninstallString', sUnInstallString) then
		begin
			SetArrayLength(asUninstallStrings, index + 1);
			asUninstallStrings[index] := sUnInstallString;
			index := index +1;
		end;

		if RegQueryStringValue(HKCU64, sUnInstPath, 'UninstallString', sUnInstallString) then
		begin
			SetArrayLength(asUninstallStrings, index + 1);
			asUninstallStrings[index] := sUnInstallString;
			index := index +1;
		end;
	end;
	Result := asUninstallStrings;
end;

/////////////////////////////////////////////////////////////////////
procedure UnInstallOldVersions();
var
	sUnInstallString: String;
	index: Integer;
	isUninstallMade: Boolean;
	iResultCode : Integer;
	asUninstallStrings : array of String;
begin
	isUninstallMade := false;
	asUninstallStrings := GetUninstallStrings();
	for index := 0 to (GetArrayLength(asUninstallStrings) -1) do
	begin
		sUnInstallString := RemoveQuotes(asUninstallStrings[index]);
		if Exec(sUnInstallString, '/SILENT /NORESTART /SUPPRESSMSGBOXES','', SW_HIDE, ewWaitUntilTerminated, iResultCode) then
			isUninstallMade := true;
	end;

	// Wait a few seconds to prevent installation issues, otherwise files are removed in one process while the other tries to link to them
	if (isUninstallMade) then
		Sleep(2000);
end;

/////////////////////////////////////////////////////////////////////
procedure CurStepChanged(CurStep: TSetupStep);
begin
	if (CurStep=ssInstall) then
	begin
		UnInstallOldVersions();
	end;
end;
/////////////////////////////////////////////////////////////////////
// End of unstall code
/////////////////////////////////////////////////////////////////////

// Build a list of screenload parameters from the supplied installer parameters
function GetParamsForGS(argument: String): String;
var
	i: Integer;
	parametersString: String;
	currentParameter: String;
	foundStart: Boolean;
	foundNoRun: Boolean;
	foundLanguage: Boolean;
begin
	foundNoRun := false;
	foundLanguage := false;
	foundStart := false;
	for i:= 0 to ParamCount() do begin
		currentParameter := ParamStr(i);
		
		// check if norun is supplied
		if Lowercase(currentParameter) = '/norun' then begin
			foundNoRun := true;
			continue;
		end;

		if foundStart then begin
			parametersString := parametersString + ' ' + currentParameter;
			foundStart := false;
		end
		else begin
			if Lowercase(currentParameter) = '/language' then begin
				foundStart := true;
				foundLanguage := true;
				parametersString := parametersString + ' ' + currentParameter;
			end;
		end;
	end;
	if not foundLanguage then begin
		parametersString := parametersString + ' /language ' + ExpandConstant('{language}');
	end;
	if foundNoRun then begin
		parametersString := parametersString + ' /norun';
	end;
	// For debugging comment out the following
	//MsgBox(parametersString, mbInformation, MB_OK);

	Result := parametersString;
end;

// Check if language group is installed
function hasLanguageGroup(argument: String): Boolean;
var
	keyValue: String;
	returnValue: Boolean;
begin
	returnValue := true;
	if (RegQueryStringValue( HKLM, 'SYSTEM\CurrentControlSet\Control\Nls\Language Groups', argument, keyValue)) then begin
		if Length(keyValue) = 0 then begin
			returnValue := false;
		end;
	end;
	Result := returnValue;
end;

function hasDotNet() : boolean;
begin
	// .NET 4.5 = 4.0 full (with a "Release" key, but this is not interresting!)
	Result := netfxinstalled(NetFX20, '') or netfxinstalled(NetFX30, '') or netfxinstalled(NetFX35, '') or netfxinstalled(NetFX40Client, '') or netfxinstalled(NetFX40Full, '');
end;

function hasDotNet35FullOrHigher() : boolean;
begin
	Result := netfxinstalled(NetFX35, '') or netfxinstalled(NetFX40Full, '');
end;

function hasDotNet45OrHigher() : boolean;
begin
	Result := netfxinstalled(NetFX4x, '');
end;

function getNGENPath(argument: String) : String;
var
	installPath: string;
begin
	if not RegQueryStringValue(HKLM, 'SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full', 'InstallPath', installPath) then begin
		if not RegQueryStringValue(HKLM, 'SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Client', 'InstallPath', installPath) then begin
			// 3.5 doesn't have NGEN and is using the .net 2.0 installation
			installPath := ExpandConstant('{dotnet20}');
		end;
	end;
	Result := installPath;
end;

// Initialize the setup
function InitializeSetup(): Boolean;
begin
	// Check for .NET and install 3.5 if we don't have it
	if not hasDotNet() then
	begin
		// Enhance installer, if needed, otherwise .NET installations won't work
		msi20('2.0');
		msi31('3.0');
		
		//install .net 3.5
		dotnetfx35sp1();
	end;
	Result := true;
end;

function IsWindowsVersionOrNewer(Major, Minor: Integer): Boolean;
var
  Version: TWindowsVersion;
begin
  GetWindowsVersionEx(Version);
  Result :=
    (Version.Major > Major) or
    ((Version.Major = Major) and (Version.Minor >= Minor));
end;

function IsWindows10OrNewer: Boolean;
begin
  Result := IsWindowsVersionOrNewer(10, 0);
end;
[Run]
Filename: "{code:getNGENPath}\ngen.exe"; Parameters: "install ""{app}\{#ExeName}.exe"""; StatusMsg: "{cm:optimize}"; Flags: runhidden runasoriginaluser
Filename: "{code:getNGENPath}\ngen.exe"; Parameters: "install ""{app}\ScreenLoadPlugin.dll"""; StatusMsg: "{cm:optimize}"; Flags: runhidden runasoriginaluser
Filename: "{app}\{#ExeName}.exe"; Description: "{cm:startscreenload}"; Parameters: "{code:GetParamsForGS}"; WorkingDir: "{app}"; Flags: nowait postinstall runasoriginaluser
// Filename: "https://analytics.webmoney.ru/statistics/187871ba896764a04fede6ff1a9e8c09"; Flags: shellexec runasoriginaluser

[InstallDelete]
Name: {app}; Type: dirifempty;

[UninstallRun]
Filename: "{code:GetNGENPath}\ngen.exe"; Parameters: "uninstall ""{app}\{#ExeName}.exe"""; StatusMsg: "Cleanup"; Flags: runhidden
Filename: "{code:GetNGENPath}\ngen.exe"; Parameters: "uninstall ""{app}\ScreenLoadPlugin.dll"""; StatusMsg: "Cleanup"; Flags: runhidden
