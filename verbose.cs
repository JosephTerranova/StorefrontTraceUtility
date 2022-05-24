using System.Management.Automation.Runspaces;

namespace StorefrontTraceUtility
{
    public static class verbose
    {
        public static void traceLevel()
        {
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(@"Import-Module 'C:\Program Files\Citrix\Receiver StoreFront\Admin\Citrix.DeliveryServices.Framework.Commands.dll'");
            pipeline.Commands.AddScript(@"Set-DSTraceLevel –All –TraceLevel Verbose");          
            
            pipeline.Invoke();
            runspace.Close();
        }   
    }
}
