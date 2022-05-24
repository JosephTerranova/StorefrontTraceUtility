using System.Diagnostics;

namespace StorefrontTraceUtility
{
    class netsh
    {
        public static void runNetworkTrace()
        {
            Process netsh = new Process();
            netsh.StartInfo.FileName = "netsh";            
            netsh.StartInfo.Arguments = "trace start capture=yes tracefile=\"C:\\Program Files\\Citrix\\Receiver StoreFront\\Admin\\Trace\\network.etl\" persistent=yes maxsize=4096";
            netsh.StartInfo.UseShellExecute = false;
            netsh.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            netsh.StartInfo.CreateNoWindow = true;
            netsh.Start();
        }
    }
}
