using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorefrontTraceUtility
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            enableNetowrkTraceToolStripMenuItem.Enabled = false;
            textBox1.ForeColor = Color.DarkOrange;
            textBox1.Text = "Starting..";
            await Task.Run(clearCache.Garbage);
            await Task.Run(verbose.traceLevel);         
            
            if (enableNetowrkTraceToolStripMenuItem.CheckState == CheckState.Checked)
            {
                await Task.Run(netsh.runNetworkTrace);                
                button2.Enabled = true;
                textBox1.Text = "Tracing..";
                textBox1.ForeColor = Color.Green;
            }
            else
            {
                button2.Enabled = true;
                textBox1.Text = "Tracing..";
                textBox1.ForeColor = Color.Green;
            }            
        }
        async void button2_Click(object sender, EventArgs e)
        {
            
            button2.Enabled = false;
            textBox1.ForeColor = Color.DarkOrange;
            textBox1.Text = "Collecting Logs..";
            await Task.Run(stopVerbose.off);            
            if (enableNetowrkTraceToolStripMenuItem.CheckState == CheckState.Checked)
            {
                await Task.Run(stopNetwork.stopnet);
                await Task.Run(context.OSinfo);
                await Task.Run(context.Events);
                pack.Zip();
                enableNetowrkTraceToolStripMenuItem.Enabled = true;
                textBox1.ForeColor = Color.Black;
                textBox1.Text = "Stopped.";
                button1.Enabled = true;
            }
            else
            {
                await Task.Run(context.OSinfo);
                await Task.Run(context.Events);
                pack.Zip();
                enableNetowrkTraceToolStripMenuItem.Enabled = true;
                textBox1.ForeColor = Color.Black;
                textBox1.Text = "Stopped.";
                button1.Enabled = true;
            }            
        }
        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Storefront Trace Utility ver.1.0.1" + "\n" + "\n" + "Author: Joseph.Terranova@Citrix.com" + "\n" + "\n" + "This software application is provided to you “AS IS” with no representations, warranties or conditions of any kind. You may use and distribute it at your own risk. CITRIX DISCLAIMS ALL WARRANTIES WHATSOEVER, EXPRESS, IMPLIED, WRITTEN, ORAL OR STATUTORY, INCLUDING WITHOUT LIMITATION WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE, TITLE AND NONINFRINGEMENT. Without limiting the generality of the foregoing, you acknowledge and agree that (a) the software application may exhibit errors, design flaws or other problems, possibly resulting in loss of data or damage to property; (b) it may not be possible to make the software application fully functional; and (c) Citrix may, without notice or liability to you, cease to make available the current version and/or any future versions of the software application.  In no event should the code be used to support of ultra-hazardous activities, including but not limited to life support or blasting activities.  NEITHER CITRIX NOR ITS AFFILIATES OR AGENTS WILL BE LIABLE, UNDER BREACH OF CONTRACT OR ANY OTHER THEORY OF LIABILITY, FOR ANY DAMAGES WHATSOEVER ARISING FROM USE OF THE SOFTWARE APPLICATION, INCLUDING WITHOUT LIMITATION DIRECT, SPECIAL, INCIDENTAL, PUNITIVE, CONSEQUENTIAL OR OTHER DAMAGES, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGES.  You agree to indemnify and defend Citrix against any and all claims arising from your use, modification or distribution of the code.");
        }
        private void enableNetowrkTraceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (enableNetowrkTraceToolStripMenuItem.CheckState == CheckState.Checked)
            {
                textBox2.ForeColor = Color.Green;
                textBox2.Text = "Network Tracing is Enabled";
            } else
            {
                textBox2.ForeColor = Color.Black;
                textBox2.Text = "Network tracing is Disabled";
            }            
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {         
        }
    }
}
