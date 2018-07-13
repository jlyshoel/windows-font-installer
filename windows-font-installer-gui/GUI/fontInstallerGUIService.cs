using JLyshoel.FontInstaller.Contract;
using System;
using System.ServiceModel;

namespace JLyshoel.FontInstaller.GUI
{
    class FontInstallerGUIService : IFontInstallerCallbackService
    {

        private IFontInstallerService proxy;
        private Logger _log;

        public FontInstallerGUIService(Logger log)
        {
            _log = log;
            var factory = new DuplexChannelFactory<IFontInstallerService>(new InstanceContext(this), new NetNamedPipeBinding(), new EndpointAddress("net.pipe://localhost/FontInstallerService"));
            proxy = factory.CreateChannel();
        }

        public void FontInstalledCallback(bool installedOk, string message)
        {

            if (installedOk)
            {
                _log.AddText("SUCCESS: Font installed");
            }
            else
            {
                _log.AddText("FAILED: " + message);
            }
        }

        public void InstallFont(string fontFileName)
        {
            try
            {
                proxy.InstallFont(fontFileName);
            }
            catch (Exception e)
            {
                _log.AddText("FAILED: " + e.Message);
            }
        }

    }
}
