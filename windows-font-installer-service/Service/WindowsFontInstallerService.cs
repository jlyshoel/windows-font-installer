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



        /*
        private PipeClient _pipeClient;
        private int _ctr;


        public WindowsFontInstallerService()
        {
            InitializeComponent();
            _ctr = 1;
        }

        EventLog log = new EventLog();

        protected override void OnStart(string[] args)
        {
            log.Source = "Hello";
            log.WriteEntry("Test", EventLogEntryType.Information);

            try
            {
                _pipeClient = new PipeClient();
                _pipeClient.Send(_ctr.ToString(), "TestPipe", 1000);
                _ctr++;
                _pipeClient = null;



            }
            catch (Exception ex)
            {
                log.WriteEntry(ex.Message, EventLogEntryType.Information);
            }
            log.WriteEntry("Test 2", EventLogEntryType.Information);
            Timer1_Tick();
            log.WriteEntry("Test 3", EventLogEntryType.Information);
        }

        private void Timer1_Tick()
        {
            try
            {
                _pipeClient = new PipeClient();
                _pipeClient.Send(_ctr.ToString(), "TestPipe", 1000);
                _ctr++;
                _pipeClient = null;

            }
            catch (Exception ex)
            {
                log.WriteEntry(ex.Message, EventLogEntryType.Information);
            }
        }

        protected override void OnStop()
        {
            _pipeClient = null;
        }
    }







    /*
            protected override void OnStart(string[] args)
            {
                active = true;
                Task.Factory.StartNew(() =>
                {
                    PipeSecurity ps = new PipeSecurity();
                    ps.AddAccessRule(new PipeAccessRule("Users", PipeAccessRights.ReadWrite, AccessControlType.Allow));
    //                ps.AddAccessRule(new PipeAccessRule(System.Security.Principal.WindowsIdentity.GetCurrent().Name, PipeAccessRights.FullControl, AccessControlType.Allow));
                    ps.AddAccessRule(new PipeAccessRule("SYSTEM", PipeAccessRights.FullControl, AccessControlType.Allow));

                    var server = new NamedPipeServerStream("PipesOfPiece", PipeDirection.InOut, 10, PipeTransmissionMode.Message, PipeOptions.WriteThrough, 1024, 1024, ps);
                    server.WaitForConnection();

                    StreamReader reader = new StreamReader(server);
                    StreamWriter writer = new StreamWriter(server);
                    while (active)
                    {
                        string line = reader.ReadLine();
                        if (String.Equals("BYE", line))
                        {
                            active = false; 
                        }
                        else
                        {
                            FontRegistry.RegisterFont(line);
                            writer.WriteLine("OK");
                            writer.Flush();
                        }
                    }
                });
            }

            protected override void OnStop()
            {
                var client = new NamedPipeClientStream("PipesOfPiece");
                client.Connect();
                StreamReader reader = new StreamReader(client);
                StreamWriter writer = new StreamWriter(client);

                while (true)
                {
                    writer.WriteLine("BYE");
                    writer.Flush();
                }
            }*/
    }
}
