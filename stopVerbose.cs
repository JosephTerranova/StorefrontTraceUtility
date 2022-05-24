using System.Management.Automation.Runspaces;

namespace StorefrontTraceUtility
{
    internal class stopVerbose
    {
        public static void off()
        {
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(@"Import-Module 'C:\Program Files\Citrix\Receiver StoreFront\Admin\Citrix.DeliveryServices.Framework.Commands.dll'");
            pipeline.Commands.AddScript(@"Set-DSTraceLevel –All –TraceLevel Off");

            pipeline.Invoke();
            runspace.Close();
        }
    }
}
