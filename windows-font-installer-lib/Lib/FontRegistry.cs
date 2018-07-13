using Microsoft.Win32;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using static System.Environment;

namespace JLyshoel.FontInstaller.Lib
{
    public class FontRegistry
    {
        public static void RegisterFont(string fontFileName)
        {
            if (!File.Exists(fontFileName))
            {
                new FileNotFoundException();
            }

            string fontName = GetFontName(fontFileName);

            File.Copy(fontFileName,
                Path.Combine(Environment.GetFolderPath(SpecialFolder.Windows),
                    "Fonts", Path.GetFileName(fontFileName)));

            RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts");
            key.SetValue(fontName, Path.GetFileName(fontFileName));
            key.Close();
        }

        public static void UnregisterFont(string fontName)
        {
            RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts");
            string fontFileName = (string)key.GetValue(fontName);
            key.DeleteValue(fontName);
            key.Close();

            string fontFullPath = Path.Combine(Environment.GetFolderPath(SpecialFolder.Windows), "Fonts", Path.GetFileName(fontFileName));
            if (File.Exists(fontFullPath))
            {
                File.Delete(fontFullPath);
            }
        }

        public static bool IsValidFont(string fontFileName)
        {
            try
            {
                byte[] data = File.ReadAllBytes(fontFileName);
                IntPtr hGlob = Marshal.AllocCoTaskMem(data.Length);
                Marshal.Copy(data, 0, hGlob, data.Length);
                PrivateFontCollection fontCol = new PrivateFontCollection();
                fontCol.AddMemoryFont(hGlob, data.Length);
                return !string.IsNullOrEmpty(fontCol.Families[0].Name);
            }
            catch (Exception) { }
            return false;
        }


        public static string GetFontName(string fontFileName)
        {
            try
            {
                byte[] data = File.ReadAllBytes(fontFileName);
                IntPtr hGlob = Marshal.AllocCoTaskMem(data.Length);
                Marshal.Copy(data, 0, hGlob, data.Length);
                PrivateFontCollection fontCol = new PrivateFontCollection();
                fontCol.AddMemoryFont(hGlob, data.Length);
                return fontCol.Families[0].Name;
            }
            catch (Exception) { }
            return null;
        }
    }
}
