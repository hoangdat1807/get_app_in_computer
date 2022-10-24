using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TestingApp.Hardware
{
   public class config_AcessIni
    {
        // Win32APIのGetPrivateProfileString
        // ini文字列読み込み
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString")]
        extern public static uint GetPrivateProfileString(
            string lpAppName,
            string lpKeyName,
            string lpDefault,
            StringBuilder lpReturnedString,
            uint nSize,
            string lpFileName
            );

        // Win32APIのGetPrivateProfileInt
        // ini数値読み込み
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileInt")]
        extern public static uint GetPrivateProfileInt(
            string lpAppName,
            string lpKeyName,
            int nDefault,
            string lpFileName
            );

        // Win32APIのWritePrivateProfileString
        // ini書き込み
        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString")]
        extern public static bool WritePrivateProfileString(
            string lpAppName,
            string lpKeyName,
            string lpString,
            string lpFileName
            );
    }
}
