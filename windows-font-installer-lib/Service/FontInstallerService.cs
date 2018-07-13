using JLyshoel.FontInstaller.Contract;
using JLyshoel.FontInstaller.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace JLyshoel.FontInstaller.Service
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class FontInstallerService : IFontInstallerService
    {
        public void InstallFont(string fontFilePath)
        {
            var callback = OperationContext.Current.GetCallbackChannel<IFontInstallerCallbackService>();

            try
            {
                FontRegistry.RegisterFont(fontFilePath);
                callback.FontInstalledCallback(true, "");
            }
            catch (Exception e)
            {
                callback.FontInstalledCallback(false, e.Message);
            }
        }
    }

}
