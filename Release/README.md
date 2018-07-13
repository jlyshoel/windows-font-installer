# File Description

**windows-font-installer-setup.msi**

The Windows Installer package for the HelloWorld project. We can change its name to something more conventional by modifying the Output file name property in the setup project's Property Pages dialog.

**Setup.exe**

The setup bootstrapper file, which reads Setup.ini to determine the required installation tasks. This is the file that is run to start the installation. Setup.exe will check for the required .NET runtime and prompt users to download it if it is not found on the target PC.
