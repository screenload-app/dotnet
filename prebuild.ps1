################################################################
# Greenshot PRE-BUILD script, written for the Windows Power Shell
# Assumes the installation of Microsoft .NET Framework 4.5
################################################################
# Greenshot - a free and open source screenshot tool
# Copyright (C) 2007-2016 Thomas Braun, Jens Klingen, Robin Krom
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

# Fill the credentials
Function FillCredentials {
	Write-Host "Filling credentials with Environment variable values`n`n"
	Get-ChildItem . -recurse *Credentials.cs | foreach {
		$template = Get-Content $_.FullName
		# Create an empty array, this will contain the replaced lines
		$newtext = @()
		foreach ($line in $template) {
			get-childitem -path env:credentials_* | foreach {
				$varname=$_.Name
				$varvalue=$_.Value
				$line = $line -replace "\@$varname\@", $varvalue
			}
			$newtext += $line
		}
		# Write the new information to the file
		Write-Host "Updating $_"
		$newtext | Set-Content $_.FullName -encoding UTF8
	}
}

FillCredentials

# Write the certificate to a file
[System.Convert]::FromBase64String($env:Certificate) | set-content "greenshot.pfx" -encoding byte
# Decode password to secure string
$password = ConvertTo-SecureString $env:CertificatePassword -AsPlainText -Force
# Import pfx
Import-PfxCertificate -FilePath .\Greenshot.pfx -CertStoreLocation Cert:\CurrentUser\My -Password $password
