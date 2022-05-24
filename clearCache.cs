using System.IO;
using System.Management.Automation.Runspaces;

namespace StorefrontTraceUtility
{
    class clearCache
    {
        public static void Garbage()
        {
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(@"Import-Module 'C:\Program Files\Citrix\Receiver StoreFront\Admin\Citrix.DeliveryServices.Framework.Commands.dll'");
            pipeline.Commands.AddScript(@"Set-DSTraceLevel –All –TraceLevel Off");
            pipeline.Invoke();
            runspace.Close();
            try
            {                
                string rootpath = @"C:\Program Files\Citrix\Receiver StoreFront\Admin\Trace\";
                string[] files = Directory.GetFiles(rootpath);
                foreach (string file in files)
                {
                    if (File.Exists(file))
                    {
                        File.Delete(file);
                    }
                }               
            }
            catch (System.IO.IOException e)
            {
                return;
            }
            catch (System.UnauthorizedAccessException a)
            {
                return;
            }
        }       
    }  
}
