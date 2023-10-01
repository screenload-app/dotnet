﻿/*
 * dapplo - building blocks for desktop applications
 * Copyright (C) Dapplo 2015-2016
 * 
 * For more information see: http://dapplo.net/
 * dapplo repositories are hosted on GitHub: https://github.com/dapplo
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
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using GreenshotPlugin.Core;
using GreenshotPlugin.UnmanagedHelpers;

namespace GreenshotJiraPlugin.Hooking
{
	/// <summary>
	/// Monitor all title changes
	/// </summary>
	public sealed class WindowsTitleMonitor : IDisposable
	{
		private WindowsEventHook _hook;
		private readonly object _lockObject = new object();
		// ReSharper disable once InconsistentNaming
		private event TitleChangeEventDelegate _titleChangeEvent;

		/// <summary>
		/// Add / remove event handler to the title monitor
		/// </summary>
		public event TitleChangeEventDelegate TitleChangeEvent
		{
			add
			{
				lock (_lockObject)
				{
					if (_hook == null)
					{
						_hook = new WindowsEventHook();
						_hook.Hook(WinEvent.EVENT_OBJECT_NAMECHANGE, WinEventHandler);
					}
					_titleChangeEvent += value;
				}
			}
			remove
			{
				lock (_lockObject)
				{
					_titleChangeEvent -= value;
					if (_titleChangeEvent == null || _titleChangeEvent.GetInvocationList().Length == 0)
					{
						if (_hook != null)
						{
							_hook.Dispose();
							_hook = null;
						}
					}
				}
			}
		}

		/// <summary>
		/// WinEventDelegate for the creation & destruction
		/// </summary>
		/// <param name="eventType"></param>
		/// <param name="hWnd"></param>
		/// <param name="idObject"></param>
		/// <param name="idChild"></param>
		/// <param name="dwEventThread"></param>
		/// <param name="dwmsEventTime"></param>
		private void WinEventHandler(WinEvent eventType, IntPtr hWnd, EventObjects idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
		{
			if (hWnd == IntPtr.Zero || idObject != EventObjects.OBJID_WINDOW)
			{
				return;
			}
			if (eventType == WinEvent.EVENT_OBJECT_NAMECHANGE)
			{
				if (_titleChangeEvent != null)
				{
					string newTitle = new WindowDetails(hWnd).Text;
					_titleChangeEvent(new TitleChangeEventArgs { HWnd = hWnd, Title = newTitle });
				}
			}
		}

		#region IDisposable Support

		private bool _disposedValue; // To detect redundant calls

		/// <summary>
		/// Dispose the underlying hook
		/// </summary>
		public void Dispose(bool disposing)
		{
			if (_disposedValue)
			{
				return;
			}
			lock (_lockObject)
			{
				_hook?.Dispose();
			}
			_disposedValue = true;
		}

		/// <summary>
		/// Make sure the finalizer disposes the underlying hook
		/// </summary>
		~WindowsTitleMonitor()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(false);
		}

		/// <summary>
		/// Dispose the underlying hook
		/// </summary>
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		#endregion
	}

}
