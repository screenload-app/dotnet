using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Forms;
using log4net;
using Microsoft.Win32;

namespace Greenshot.Helpers
{
    internal static class DialogHelper
    {
        private const string DoNotShowMeThisDialogAgainRegistryKey =
            @"Software\Microsoft\Windows\CurrentVersion\Explorer\DontShowMeThisDialogAgain";

        private const string DoNotShowMeThisDialogAgainValue = "NO";

        private static readonly ILog Log = LogManager.GetLogger(typeof(DialogHelper));

        #region Native

        public const int IDYES = 6;
        public const int IDNO = 7;

        private const uint MB_YESNO = 0x00000004;
        private const uint MB_DEFBUTTON2 = 0x00000100;

        [DllImport("shlwapi.dll", EntryPoint = "SHMessageBoxCheckA")]
        public static extern int SHMessageBoxCheck([In] IntPtr hwnd, [In] string pszText, [In] string pszTitle,
            [In] uint uType, [In] int iDefault, [In] string pszRegVal);

        #endregion

        public static DialogResult ShowYesNoDialogWithCheckbox(IWin32Window window, string dialogName, string text, string caption)
        {
            if (null == dialogName)
                throw new ArgumentNullException(nameof(dialogName));

            if (null == text)
                throw new ArgumentNullException(nameof(text));

            if (null == caption)
                throw new ArgumentNullException(nameof(caption));

            int result;

            try
            {
                result = SHMessageBoxCheck(
                    window?.Handle ?? IntPtr.Zero,
                    text,
                    caption,
                    MB_YESNO | MB_DEFBUTTON2,
                    IDYES,
                    dialogName // This last argument is the value of the registry key
                );
            }
            catch (Exception)
            {
                result = -1;
            }

            switch (result)
            {
                case IDYES:
                    return DialogResult.Yes;
                case IDNO:
                    return DialogResult.No;
                default:
                    return MessageBox.Show(window, text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.None,
                        MessageBoxDefaultButton.Button2);
            }
        }

        public static bool IsDoNotShowDialogSet(string dialogName)
        {
            if (null == dialogName)
                throw new ArgumentNullException(nameof(dialogName));

            RegistryKey registryKey = null;
            string value;

            try
            {
                registryKey =
                    Registry.CurrentUser.OpenSubKey(DoNotShowMeThisDialogAgainRegistryKey);
                value = registryKey?.GetValue(dialogName) as string;
            }
            catch (SecurityException exception)
            {
                Log.Error(exception.Message, exception);
                value = null;
            }
            finally
            {
                registryKey?.Close();
            }

            return null != value;
        }

        public static void SetDoNotShowDialog(string dialogName, bool doNotShow)
        {
            if (null == dialogName)
                throw new ArgumentNullException(nameof(dialogName));

            var currentDoNotShowValue = IsDoNotShowDialogSet(dialogName);

            if (currentDoNotShowValue == doNotShow)
                return;

            RegistryKey registryKey = null;

            try
            {
                registryKey =
                    Registry.CurrentUser.OpenSubKey(DoNotShowMeThisDialogAgainRegistryKey, true);

                if (doNotShow)
                    registryKey?.SetValue(dialogName, DoNotShowMeThisDialogAgainValue,
                        RegistryValueKind.String);
                else
                    registryKey?.DeleteValue(dialogName, false);
            }
            catch (SecurityException exception)
            {
                Log.Error(exception.Message, exception);
            }
            finally
            {
                registryKey?.Close();
            }
        }
    }
}
