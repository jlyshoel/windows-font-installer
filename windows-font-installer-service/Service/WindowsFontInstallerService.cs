using JLyshoel.FontInstaller.Contract;
using System;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceProcess;

namespace JLyshoel.FontInstaller.Service
{

    public partial class WindowsFontInstallerService : ServiceBase
    {
        public ServiceHost serviceHost = null;
        public WindowsFontInstallerService()
        {
            ServiceName = "WindowsFontInstallerService";
        }

        protected override void OnStart(string[] args)
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }

            serviceHost = new ServiceHost(typeof(FontInstallerService), new Uri("net.pipe://localhost"));
            serviceHost.AddServiceEndpoint(typeof(IFontInstallerService), new NetNamedPipeBinding(), "FontInstallerService");
            serviceHost.Open();
        }
        
        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }
    }
}
