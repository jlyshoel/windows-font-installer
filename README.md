> This project is still in BETA

# Windows Font Installer
In Windows 10 you can't install fonts without admin privileges. There doesn’t seem to be any available GPO nor a simple workaround for this problem. This is especially annoying if you are a sysadmin in a domain environment where your users need the ability to install fonts in their day to day work. You’ll spend your day running around entering your admin password all day. This handy little tool will allow your users to install fonts without you entering your password every 5 minutes. 

It works by installing a service, running under the local system account, and a simple desktop application for your users to upload fonts. 

## Download
[Download latest release](/Release/windows-font-installer-setup.msi?raw=true)

## Risks
In fairness, Microsoft do have a point when choosing to disable and remove this ability. There is a possibility that fonts may contain executable code. By using this tool you will give your users the ability to install this type of malicious code.

Another aspect is licensing. Fonts have different licensing agreements. By using this tool, you will effectively be handing over the legal responsibility to your users.

## Screenshot
![alt text](/assets/screenshot.png "User interface")
![alt text](/assets/screenshot2.png "Service")
