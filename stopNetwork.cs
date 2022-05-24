using System.Diagnostics;

namespace StorefrontTraceUtility
{
    internal class stopNetwork
    {
        public static void stopnet()
        {
            Process netsh = new Process();
            netsh.StartInfo.FileName = "netsh";
            netsh.StartInfo.Arguments = "trace Stop";
            netsh.StartInfo.UseShellExecute = false;
            netsh.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            netsh.StartInfo.CreateNoWindow = true;
            netsh.Start();
            netsh.WaitForExit();
        }        
    }
}
