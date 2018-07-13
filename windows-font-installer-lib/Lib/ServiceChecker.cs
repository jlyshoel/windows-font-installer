using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ServiceProcess;
using System.Management;

namespace JLyshoel.FontInstaller.Lib
{
    public class ServiceCheck
    {

        private static readonly string SERVICE_NAME = "WindowsFontInstaller";

        public static bool IsInstalled()
        {
            try
            {
                ServiceController ctl = ServiceController.GetServices()
                    .FirstOrDefault(s => s.ServiceName == SERVICE_NAME);
                return (ctl != null);
            }
            catch (Exception e) { }
            return false;
        }

        public static ServiceControllerStatus GetStatus()
        {
            try
            {
                ServiceController ctl = ServiceController.GetServices()
                    .FirstOrDefault(s => s.ServiceName == SERVICE_NAME);

                if (ctl != null)
                {
                    return ctl.Status;
                }
            }
            catch (Exception e) { }
            return ServiceControllerStatus.Stopped;
        }

        public static bool GetEnabled()
        {
            try
            {
                string wmiQuery = "SELECT * FROM Win32_Service WHERE Name='" + SERVICE_NAME + "'";
                var searcher = new ManagementObjectSearcher(wmiQuery);
                var results = searcher.Get();

                foreach (ManagementObject service in results)
                {
                    return !string.Equals("Disabled", service["StartMode"]);
                }
            }
            catch (Exception e) { }
            return false;
        }

        public static void SetEnabled(bool enabled)
        {
            try
            {
                string objPath = string.Format("Win32_Service.Name='{0}'", SERVICE_NAME);
                using (var service = new ManagementObject(new ManagementPath(objPath)))
                {
                    service.InvokeMethod("ChangeStartMode", new object[] { enabled ? "Automatic" : "Disabled" });
                }
            }
            catch (Exception e) { }
        }

        public static void Start()
        {
            ServiceController ctl = ServiceController.GetServices()
                .FirstOrDefault(s => s.ServiceName == SERVICE_NAME);

            if (ctl != null) ctl.Start();
        }

        public static void Stop()
        {
            ServiceController ctl = ServiceController.GetServices()
                .FirstOrDefault(s => s.ServiceName == SERVICE_NAME);

            if (ctl != null) ctl.Stop();
        }

        public static bool InstallService(string path)
        {
            string dirPath = path;
            if (!dirPath.EndsWith(@"\"))
                dirPath = dirPath + @"\";

            Assembly assembly = Assembly.LoadFrom(dirPath + "windows-font-installer-service.exe");
            ServiceInstaller.InstallService(SERVICE_NAME, assembly);
            return true;
        }
        public static bool UninstallService(string path)
        {
            string dirPath = path;
            if (!dirPath.EndsWith(@"\"))
                dirPath = dirPath + @"\";

            Assembly assembly = Assembly.LoadFrom(dirPath + "windows-font-installer-service.exe");
            ServiceInstaller.UninstallService(SERVICE_NAME, assembly);
            return true;
        }
    }
}
