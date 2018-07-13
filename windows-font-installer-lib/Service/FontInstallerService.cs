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
        public string InstallFont(string fontFilePath)
        {
            try
            {
                FontRegistry.RegisterFont(fontFilePath);
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message;
            }



            // Get a handle to the call back channel
            //var callback = OperationContext.Current.GetCallbackChannel<IFontInstallerCallbackService>();
            //callback.NotifyClient();
            //return DateTime.Now.ToString();
        }
    }

}
