using System.Management.Automation.Runspaces;

namespace StorefrontTraceUtility
{
    internal class context
    {
        public static void OSinfo()
        {
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(@"Import-Module 'C:\Program Files\Citrix\Receiver StoreFront\Admin\Citrix.DeliveryServices.Framework.Commands.dll'");
            pipeline.Commands.AddScript(@"Get-computerinfo -Property OsName | out-file 'C:\Program Files\Citrix\Receiver StoreFront\Admin\Trace\SystemInfo.txt'");
            pipeline.Commands.AddScript(@"Get-WmiObject -Class Win32_ComputerSystem | Select Name,Domain | Out-File -Append 'C:\Program Files\Citrix\Receiver StoreFront\Admin\Trace\SystemInfo.txt'");
            pipeline.Commands.AddScript(@"Get-NetIpConfiguration | Out-File -append 'C:\Program Files\Citrix\Receiver StoreFront\Admin\Trace\SystemInfo.txt'");
            pipeline.Commands.AddScript(@"Get-STFStoreService | Out-File -Append 'C:\Program Files\Citrix\Receiver StoreFront\Admin\Trace\SystemInfo.txt'");
            pipeline.Invoke();
            runspace.Close();
        }
            
        public static void Events()
        {
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(@"$Path = 'C:\Program Files\Citrix\Receiver StoreFront\Admin\Trace'");
            pipeline.Commands.AddScript("(Get-WmiObject Win32_NTEventlogFile -Filter \"LogFileName = 'Citrix Delivery Services'\").BackupEventlog(\"$Path\\CitrixDeliveryServices.evt\")");
            pipeline.Invoke();
            runspace.Close();
        }
    }
}
