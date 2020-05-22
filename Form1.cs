using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MergeForm
{
    public partial class Merge : Form
    {
        BackgroundWorker backgroundWorker1;
        string vehicleName = "";
        public Merge()
        {
            InitializeComponent();
            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += BackgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += BackgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //throw new NotImplementedException();
            if (guna2CircleProgressBar1.Value == 100)
            {
                MessageBox.Show("Done");
                Process.Start(bunifuCustomLabel1.Text + "/merged");
                Environment.Exit(69);
            }
            else
            {
                bunifuCustomLabel5.ForeColor = Color.Red;
            }
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //throw new NotImplementedException();
            Directory.CreateDirectory(bunifuCustomLabel1.Text + "/merged");
            Directory.CreateDirectory(bunifuCustomLabel1.Text + "/Error");
            Directory.CreateDirectory(bunifuCustomLabel1.Text + "/merged/stream");
            Directory.CreateDirectory(bunifuCustomLabel1.Text + "/merged/data");
            string[] meta = {"/merged/fxmanifest.lua" };
            string __resource = @"fx_version 'adamant'
game 'gta5'
 
files {
    'data/**/*.meta'
}

data_file 'HANDLING_FILE' 'data/**/handling.meta'
data_file 'VEHICLE_METADATA_FILE' 'data/**/vehicles.meta'
data_file 'CARCOLS_FILE' 'data/**/carcols.meta'
data_file 'VEHICLE_VARIATION_FILE' 'data/**/carvariations.meta'
data_file 'VEHICLE_LAYOUTS_FILE' 'data/**/vehiclelayouts.meta'";
            foreach (string metaName in meta)
            {
                string metaPath = bunifuCustomLabel1.Text + metaName;
                //if (!File.Exists(metaPath))
                //{
                //    using (var sw = File.CreateText(metaPath)) { };
                //}
                if (metaName.Contains("vehicles"))
                {
                    XmlWriter writer = XmlWriter.Create(metaPath);
                    writer.WriteStartDocument();
                    writer.WriteStartElement("CVehicleModelInfo__InitDataList");
                    writer.WriteEndElement();
                    writer.Flush();
                    writer.Close();
                }
                else if (metaName.Contains("carcols"))
                {
                    XmlWriter writer = XmlWriter.Create(metaPath);
                    writer.WriteStartDocument();
                    writer.WriteStartElement("CVehicleModelInfoVarGlobal");
                    writer.WriteEndElement();
                    writer.Flush();
                    writer.Close();
                }
                else if (metaName.Contains("carvariations"))
                {
                    XmlWriter writer = XmlWriter.Create(metaPath);
                    writer.WriteStartDocument();
                    writer.WriteStartElement("CVehicleModelInfoVariation");
                    writer.WriteEndElement();
                    writer.Flush();
                    writer.Close();
                }
                else if (metaName.Contains("handling"))
                {
                    XmlWriter writer = XmlWriter.Create(metaPath);
                    writer.WriteStartDocument();
                    writer.WriteStartElement("CHandlingDataMgr");
                    writer.WriteEndElement();
                    writer.Flush();
                    writer.Close();
                }
                else if (metaName.Contains("vehiclelayouts"))
                {
                    XmlWriter writer = XmlWriter.Create(metaPath);
                    writer.WriteStartDocument();
                    writer.WriteStartElement("CVehicleMetadataMgr");
                    writer.WriteEndElement();
                    writer.Flush();
                    writer.Close();
                }
                else if (metaName.Contains("fxmanifest"))
                {
                    using (StreamWriter sw = File.CreateText(metaPath))
                    {
                        sw.WriteLine(__resource);
                    }
                }

            }
            string root = bunifuCustomLabel1.Text;
            string[] subdirectoryEntries = Directory.GetDirectories(root);
            int i = 0;
            float length = subdirectoryEntries.Length;
            try
            {
                foreach (string subdirectory in subdirectoryEntries)
                {
                    if (!subdirectory.Contains("merged"))
                    {
                        //MessageBox.Show(subdirectory);
                        string FolderName = Path.GetFileName(subdirectory);
                        Directory.CreateDirectory(bunifuCustomLabel1.Text + "/merged/data/"+FolderName);
                        i = i + 1;
                        backgroundWorker1.ReportProgress((int)((i / length) * 100));
                        if (bunifuCustomLabel5.InvokeRequired)
                        {
                            bunifuCustomLabel5.Invoke((Action)(() => bunifuCustomLabel5.Text = "Loading " + subdirectory));
                        }
                        DirectoryInfo d = new DirectoryInfo(subdirectory);
                        FileInfo[] Files = d.GetFiles("*.meta");
                        try
                        {
                            foreach (FileInfo file in Files)
                            {
                                //if (file.Name == "vehicles.meta")
                                //{
                                //    XmlDocument vehicles = new XmlDocument();
                                //    vehicles.Load(file.FullName);
                                //    vehicleName = vehicleName + "|" + VehiclesMeta.Merge(vehicles, bunifuCustomLabel1.Text + "/merged/vehicles.meta", bunifuCustomLabel1.Text + "/merged/vehiclename.txt");
                                //}
                                //if (file.Name == "carcols.meta")
                                //{
                                //    XmlDocument carcols = new XmlDocument();
                                //    carcols.Load(file.FullName);
                                //    CarcolsMeta.Merge(carcols, bunifuCustomLabel1.Text + "/merged/carcols.meta");
                                //}
                                //if (file.Name == "handling.meta")
                                //{
                                //    XmlDocument handling = new XmlDocument();
                                //    handling.Load(file.FullName);
                                //    HandlingMeta.Merge(handling, bunifuCustomLabel1.Text + "/merged/handling.meta");
                                //}
                                //if (file.Name == "carvariations.meta")
                                //{
                                //    XmlDocument carvariations = new XmlDocument();
                                //    carvariations.Load(file.FullName);
                                //    CarvariationsMeta.Merge(carvariations, bunifuCustomLabel1.Text + "/merged/carvariations.meta");
                                //}
                                //if (file.Name == "vehiclelayouts.meta")
                                //{
                                //    XmlDocument vehiclelayouts = new XmlDocument();
                                //    vehiclelayouts.Load(file.FullName);
                                //    VehiclelayoutsMeta.Merge(vehiclelayouts, bunifuCustomLabel1.Text + "/merged/vehiclelayouts.meta");
                                //}
                                File.Copy(file.FullName, Path.Combine(bunifuCustomLabel1.Text + "/merged/data/" + FolderName, Path.GetFileName(file.FullName)));
                            }
                            if (Directory.Exists(subdirectory + "/stream"))
                            {
                                DirectoryInfo stream = new DirectoryInfo(subdirectory + "/stream");
                                FileInfo[] StreamFile = stream.GetFiles();
                                foreach (FileInfo file in StreamFile)
                                {
                                    if (!File.Exists(bunifuCustomLabel1.Text + "/merged/stream/" + file.Name))
                                    {
                                        File.Copy(file.FullName, Path.Combine(bunifuCustomLabel1.Text + "/merged/stream", Path.GetFileName(file.FullName)));
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            try
                            {
                                string errFolderName = Path.GetFileName(subdirectory);
                                Console.WriteLine("asdasd" + errFolderName);
                                Directory.Move(subdirectory, bunifuCustomLabel1.Text + "/Error/" + errFolderName);
                            }
                            catch (Exception exd)
                            {
                                MessageBox.Show(exd.Message);
                            }
                            MessageBox.Show(ex.Message + "\n" + "Moved " + subdirectory + " to " + bunifuCustomLabel1.Text + "/Error", "ERROR in " + subdirectory, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    Thread.Sleep(500);
                }
                using (StreamWriter sw = File.CreateText(bunifuCustomLabel1.Text + "/merged/Merged-Vehicle.txt"))
                {
                    sw.WriteLine(vehicleName);
                }
                backgroundWorker1.ReportProgress(100);
            }
            catch (Exception ex)
            {
            MessageBox.Show(ex.Message);

            if (bunifuCustomLabel5.InvokeRequired)
            {
                bunifuCustomLabel5.Invoke((Action)(() => bunifuCustomLabel5.Text = "ERROR " + bunifuCustomLabel5.Text +" | Check your meta"));
            }
            }
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //throw new NotImplementedException();
            if (!backgroundWorker1.CancellationPending)
            {
                guna2CircleProgressBar1.Value = e.ProgressPercentage;
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            folderBrowser.FileName = "Folder Selection";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                bunifuCustomLabel1.Text = folderPath;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
                guna2Button1.Text = "Merge";
            }
            else
            {
                if (bunifuCustomLabel1.Text == "")
                {
                    MessageBox.Show("Invalid Path");
                }
                else
                {
                    guna2Button1.Text = "Stop";
                    backgroundWorker1.RunWorkerAsync();
                }
            }
        }

        public void Notification(string mes)
        {
            bunifuCustomLabel2.Text = mes;
        }
    }
}