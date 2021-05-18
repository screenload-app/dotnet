################################################################
# Greenshot BUILD script, written for the Windows Power Shell
# Assumes the installation of Microsoft .NET Framework 4.5
################################################################
# Greenshot - a free and open source screenshot tool
# Copyright (C) 2007-2015 Thomas Braun, Jens Klingen, Robin Krom
# 
# For more information see: http://getgreenshot.org/
# The Greenshot project is hosted on GitHub https://github.com/greenshot/greenshot
# 
# This program is free software: you can redistribute it and/or modify
# it under the terms of the GNU General Public License as published by
# the Free Software Foundation, either version 1 of the License, or
# (at your option) any later version.
# 
# This program is distributed in the hope that it will be useful,
# but WITHOUT ANY WARRANTY; without even the implied warranty of
# MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
# GNU General Public License for more details.
# 
# You should have received a copy of the GNU General Public License
# along with this program.  If not, see <http://www.gnu.org/licenses/>.
################################################################

$version=$env:APPVEYOR_BUILD_VERSION
if ( !$version ) {
	$version = "2.3.1.0"
}

$buildType=$env:build_type
if ( !$buildType ) {
	$buildType = "local"
}

$gitcommit=$env:APPVEYOR_REPO_COMMIT
if ( !$gitcommit ) {
	$gitcommit = "abcdefghijklmnopqrstuvwxy"
}

$gitcommit=$gitcommit.SubString(0, [math]::Min($gitcommit.Length, 7))
$detailversion=$version + '-' + $gitcommit + " " + $buildType
$release=(([version]$version).build) % 2 -eq 1
$fileversion=$version + "-" + $buildType

#$env:SignTool = "C:\Program Files (x86)\Windows Kits\10\bin\10.0.17134.0\x64\signtool.exe"
#$certThumbprint = "fcb671b0b83566d01aee0e142e9ba5a999208ee4"
#$timestampingServer = "http://timestamp.comodoca.com/rfc3161"

Write-Host "Building ScreenLoad $detailversion"

# Create a MD5 string for the supplied filename
Function MD5($filename) {
	$fileStream = new-object -TypeName System.IO.FileStream -ArgumentList "$filename", "Open", "Read", "Read"
	$MD5CryptoServiceProvider = new-object -TypeName System.Security.Cryptography.MD5CryptoServiceProvider
	$hash = $MD5CryptoServiceProvider.ComputeHash($fileStream)
	return [System.BitConverter]::ToString($hash) -replace "-", ""
}

# Fill the templates
Function FillTemplates {
	Write-Host "Filling templates for version $detailversion`n`n"
	
	Get-ChildItem . -recurse *.template | 
		foreach {
			$oldfile = $_.FullName
			$newfile = $_.FullName -replace '\.template',''
			Write-Host "Modifying file : $oldfile to $newfile"
			# Read the file
			$template = Get-Content $oldfile
			# Create an empty array, this will contain the replaced lines
			$newtext = @()
			foreach ($line in $template) {
				$newtext += $line -replace "\@VERSION\@", $version -replace "\@DETAILVERSION\@", $detailversion -replace "\@FILEVERSION\@", $fileversion -replace "\@CERTTHUMBPRINT\@", $certThumbprint -replace "\@TIMESTAMPINGSERVER\@", $timestampingServer
			}
			# Write the new information to the file
			$newtext | Set-Content $newfile -encoding UTF8
		}
}

# Create the MD5 checksum file
Function MD5Checksums {
	echo "MD5 Checksums:"
	$sourcebase = "$(get-location)\ScreenLoad\bin\Release"

	$INCLUDE=@("*.exe", "*.gsp", "*.dll")
	Get-ChildItem -Path "$sourcebase" -Recurse -Include $INCLUDE | foreach {
		$currentMD5 = MD5($_.fullname)
		$name = $_.Name
		echo "$name : $currentMD5"
	}
}

# This function creates the installer
Function PackageInstaller {
	$setupOutput = "$(get-location)\setup"
	$innoSetup = "$(get-location)\packages\Tools.InnoSetup.5.5.9\tools\ISCC.exe"
	$innoSetupFile =  "$(get-location)\screenload\releases\innosetup\setup.iss"
	$arguments = @("/Qp ", $innoSetupFile)
	
	Write-Host "Starting $innoSetup $innoSetupFile"
	$setupResult = Start-Process -wait -PassThru "$innoSetup" -ArgumentList $arguments -NoNewWindow -RedirectStandardOutput "$setupOutput.log" -RedirectStandardError "$setupOutput.error"
	Write-Host "Log output:"
	Get-Content "$setupOutput.log"| Write-Host
	if ($setupResult.ExitCode -ne 0) {
		Write-Host "Error output:"
		Get-Content "$setupOutput.error"| Write-Host
		exit -1
	}
	return
}

FillTemplates

# This must be after the signing, otherwise they would be different.
echo "Generating MD5"
MD5Checksums | Set-Content "$(get-location)\ScreenLoad\bin\Release\checksum.MD5" -encoding UTF8

echo "Generating Installer"
PackageInstaller

#echo "Generating ZIP"
#PackageZip

#echo "Generating Portable"
#PackagePortable

#echo "Generating Debug Symbols ZIP"
#PackageDbgSymbolsZip

