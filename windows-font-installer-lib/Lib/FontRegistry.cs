using Microsoft.Win32;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
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

            PrivateFontCollection fontCol = new PrivateFontCollection();
            fontCol.AddFontFile(fontFileName);
            string fontName = fontCol.Families[0].Name;

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
            string fontFileName = (string) key.GetValue(fontName);
            key.DeleteValue(fontName);
            key.Close();
            
            string fontFullPath = Path.Combine(Environment.GetFolderPath(SpecialFolder.Windows), "Fonts", Path.GetFileName(fontFileName));
            if (File.Exists(fontFullPath))
            {
                File.Delete(fontFullPath);
            }
        }
    }
}
