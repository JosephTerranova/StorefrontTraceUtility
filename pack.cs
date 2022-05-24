using System;
using System.IO.Compression;
using System.Windows.Forms;


namespace StorefrontTraceUtility
{
    internal class pack
    {
        public static void Zip()
        {
            string filename = System.Environment.MachineName;
            var date = DateTime.Now;
            DateTime.Now.ToString("yyyy-dd-MM-HH-mm");
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = @"%USERPROFILE%\Desktop";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = filename + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm");
            saveFileDialog.DefaultExt = "zip";
            saveFileDialog.Filter = "zip files (*.zip)|*.zip";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {                
                try
                {
                    string Path = saveFileDialog.FileName;
                    string sourceFolder = @"C:\Program Files\Citrix\Receiver StoreFront\Admin\Trace";

                    ZipFile.CreateFromDirectory(sourceFolder, Path);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    Zip();
                }
            }            
        }
    }
}
