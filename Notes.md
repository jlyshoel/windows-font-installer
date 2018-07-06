  
This solution is clean, works without reboot(!) but it does show a "Installing font..." dialogbox (which disappears by itself).
First, add a reference to system32\shell32.dll in your project.
And then, use just these 3 lines of code to install a font:

Shell32.Shell shell = new Shell32.Shell();
Shell32.Folder fontFolder = shell.NameSpace(0x14);
fontFolder.CopyHere(@"path_to\the_font.ttf");



=======


According to docs of AddFontResource()

  This function installs the font only for the current session. When the
  system restarts, the font will not be present. To have the font
  installed even after restarting the system, the font must be listed in
  the registry.

So the best option i found is to copy the font to windows font directory 
File.Copy("MyNewFont.ttf",
    Path.Combine(Environment.GetFolderPath(SpecialFolder.Windows),
        "Fonts", "MyNewFont.ttf"));

And then add respective entries in registery,Like
Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts");
                    key.SetValue("My Font Description", "fontname.tff");
                    key.Close();
    
