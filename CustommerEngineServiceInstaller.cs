using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace Manager

{
    [RunInstaller(true)]
    public class CustommerEngineServiceInstaller : Installer
    {
        private ServiceProcessInstaller process;
        private ServiceInstaller service;
        public CustommerEngineServiceInstaller()
        {
            process = new ServiceProcessInstaller();
            process.Account = ServiceAccount.LocalSystem;
            service = new ServiceInstaller();
            service.ServiceName = "CustommerEngineService";
            Installers.Add(process);
            Installers.Add(service);
        }
    }
}