using JLyshoel.FontInstaller.Contract;
using JLyshoel.FontInstaller.Lib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace JLyshoel.FontInstaller.Service
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class FontInstallerService : IFontInstallerService
    {
        private EventLog _log;
        public FontInstallerService()
        {
            _log = new EventLog();
            _log.Source = "WindowsFontInstallerService";
        }

        public void InstallFont(string fontFilePath)
        {
            var callback = OperationContext.Current.GetCallbackChannel<IFontInstallerCallbackService>();

            try
            {
                FontRegistry.RegisterFont(fontFilePath);
                callback.FontInstalledCallback(true, "");
                _log.WriteEntry("Font installed: " + fontFilePath, EventLogEntryType.Information);
            }
            catch (Exception e)
            {
                callback.FontInstalledCallback(false, e.Message);
            }
        }
    }

}
