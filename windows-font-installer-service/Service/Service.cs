using System.ComponentModel;
using System.ServiceModel;
using System.ServiceProcess;
using System.Configuration;
using System.Configuration.Install;

namespace JLyshoel.FontInstaller.Service
{
    static class Service
    {

        public static void Main()
        {
            ServiceBase.Run(new WindowsFontInstallerService());
        }
    }
}
