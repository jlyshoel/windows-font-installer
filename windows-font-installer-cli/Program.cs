using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ServiceProcess;
using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;
using System.Threading;
using JLyshoel.FontInstaller.Lib;
using System.ServiceModel;
using JLyshoel.FontInstaller.Contract;

namespace JLyshoel.FontInstaller
{
    class Program
    {


        static void Main(string[] args)
        {

            //FontRegistry.RegisterFont(@"C:\temp\Pacifico.ttf");
            //FontRegistry.UnregisterFont("Pacifico");

            //SyndeoServiceCheck.UninstallSyndeoService(@"C:\development\windows-font-installer\windows-font-installer-service\bin\Debug");
            //SyndeoServiceCheck.InstallSyndeoService(@"C:\development\windows-font-installer\windows-font-installer-service\bin\Debug");
            /*
            var client = new NamedPipeClientStream("PipesOfPiece");
            Console.WriteLine("Connect 1");
            client.Connect();
            Console.WriteLine("Connect 2");
            StreamReader reader = new StreamReader(client);
            StreamWriter writer = new StreamWriter(client);

            Console.WriteLine("Connect 3");
            writer.WriteLine(@"C:\temp\Pacifico.ttf");
            writer.Flush();

            Console.WriteLine("Connect 4");
            Console.WriteLine(reader.ReadLine());
            Console.WriteLine("Completed");*/








            new FontInstallerCLICallbackService().Run();


















        }
    }


    class FontInstallerCLICallbackService : IFontInstallerCallbackService
    {
        private readonly string font = @"C:\temp\Pacifico.ttf";

        public void Run()
        {
            // Consume the service
            var factory = new DuplexChannelFactory<IFontInstallerService>(new InstanceContext(this), new NetNamedPipeBinding(), new EndpointAddress("net.pipe://localhost/FontInstallerService"));
            var proxy = factory.CreateChannel();

            Console.WriteLine(proxy.InstallFont(font));
        }

        public void NotifyClient()
        {
            Console.WriteLine("Notification from Server");
        }

        public void FontInstalledCallback(bool installedOk, string message)
        {
            Console.WriteLine("Notification from Server");
        }
    }





}
