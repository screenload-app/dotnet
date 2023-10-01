﻿/*
 * ScreenLoad - a free and open source screenshot tool
 * Copyright (C) 2007-2016 Thomas Braun, Jens Klingen, Robin Krom
 * 
 * For more information see: http://getgreenshot.org/
 * The ScreenLoad project is hosted on GitHub https://github.com/greenshot/greenshot
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 1 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using System;
using System.Reflection;

// Remove AppendPrivatePath warning:
#pragma warning disable 0618
namespace ScreenLoad {
	/// <summary>
	/// Description of Main.
	/// </summary>
	public class ScreenLoadMain {
		static ScreenLoadMain() {
			AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
		}

		private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args) {
			Assembly ayResult = null;
			string sShortAssemblyName = args.Name.Split(',')[0];
			Assembly[] ayAssemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach (Assembly ayAssembly in ayAssemblies) {
				if (sShortAssemblyName == ayAssembly.FullName.Split(',')[0]) {
					ayResult = ayAssembly;
					break;
				}
			}
			return ayResult;
		}

		[STAThread]
		public static void Main(string[] args) {
			MainForm.Start(args);
		}
	}
}
