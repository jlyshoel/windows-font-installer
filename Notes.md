  
This solution is clean, works without reboot(!) but it does show a "Installing font..." dialogbox (which disappears by itself).
First, add a reference to system32\shell32.dll in your project.
And then, use just these 3 lines of code to install a font:

Shell32.Shell shell = new Shell32.Shell();
Shell32.Folder fontFolder = shell.NameSpace(0x14);
fontFolder.CopyHere(@"path_to\the_font.ttf");



--------


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
    



-----




[DllImport("gdi32", EntryPoint = "AddFontResource")]
public static extern int AddFontResourceA(string lpFileName);
[System.Runtime.InteropServices.DllImport("gdi32.dll")]
private static extern int AddFontResource(string lpszFilename);
[System.Runtime.InteropServices.DllImport("gdi32.dll")]
private static extern int CreateScalableFontResource(uint fdwHidden, string
    lpszFontRes, string lpszFontFile, string lpszCurrentPath);

/// <summary>
/// Installs font on the user's system and adds it to the registry so it's available on the next session
/// Your font must be included in your project with its build path set to 'Content' and its Copy property
/// set to 'Copy Always'
/// </summary>
/// <param name="contentFontName">Your font to be passed as a resource (i.e. "myfont.tff")</param>
private static void RegisterFont(string contentFontName)
{
    // Creates the full path where your font will be installed
    var fontDestination = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts), contentFontName);

    if (!File.Exists(fontDestination))
    {
        // Copies font to destination
        System.IO.File.Copy(Path.Combine(System.IO.Directory.GetCurrentDirectory(), contentFontName), fontDestination);

        // Retrieves font name
        // Makes sure you reference System.Drawing
        PrivateFontCollection fontCol = new PrivateFontCollection();
        fontCol.AddFontFile(fontDestination);
        var actualFontName = fontCol.Families[0].Name;

        //Add font
        AddFontResource(fontDestination);
        //Add registry entry   
        Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts",actualFontName, contentFontName, RegistryValueKind.String);
    }
}
