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
    public class SyndeoServiceCheck
    {

        private static readonly string SERVICE_NAME = "WindowsFontInstaller";

        public static bool IsSyndeoInstalled()
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

        public static ServiceControllerStatus GetSyndeoStatus()
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

        public static bool GetSyndeoEnabled()
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

        public static void SetSyndeoEnabled(bool enabled)
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

        public static void StartSyndeo()
        {
            ServiceController ctl = ServiceController.GetServices()
                .FirstOrDefault(s => s.ServiceName == SERVICE_NAME);

            if (ctl != null) ctl.Start();
        }

        public static void StopSyndeo()
        {
            ServiceController ctl = ServiceController.GetServices()
                .FirstOrDefault(s => s.ServiceName == SERVICE_NAME);

            if (ctl != null) ctl.Stop();
        }

        public static bool InstallSyndeoService(string path)
        {
            string dirPath = path;
            if (!dirPath.EndsWith(@"\"))
                dirPath = dirPath + @"\";

            Assembly assembly = Assembly.LoadFrom(dirPath + "windows-font-installer-service.exe");
            ServiceInstaller.InstallService(SERVICE_NAME, assembly);
            return true;
        }
        public static bool UninstallSyndeoService(string path)
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
