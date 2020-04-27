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
    public partial class Form1 : Form
    {
        BackgroundWorker backgroundWorker1;
        string vehicleName = "";
        public Form1()
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

            MessageBox.Show("Done");
            Process.Start(bunifuCustomLabel1.Text + "/merged");
            Environment.Exit(69);
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //throw new NotImplementedException();
            Directory.CreateDirectory(bunifuCustomLabel1.Text + "/merged");
            Directory.CreateDirectory(bunifuCustomLabel1.Text + "/merged/stream");
            string[] meta = { "/merged/vehicles.meta", "/merged/carcols.meta", "/merged/carvariations.meta", "/merged/handling.meta", "/merged/vehiclelayouts.meta", "/merged/__resource.lua" };
            string __resource = @"resource_manifest_version '77731fab-63ca-442c-a67b-abc70f28dfa5'
 
files {
    'vehicles.meta',
    'carvariations.meta',
    'carcols.meta',
    'handling.meta',
    'vehiclelayouts.meta',
}

data_file 'HANDLING_FILE' 'handling.meta'
data_file 'VEHICLE_METADATA_FILE' 'vehicles.meta'
data_file 'CARCOLS_FILE' 'carcols.meta'
data_file 'VEHICLE_VARIATION_FILE' 'carvariations.meta'
data_file 'VEHICLE_LAYOUTS_FILE' 'vehiclelayouts.meta'";
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
                    //Console.WriteLine("asdasdasdasdasdasd");
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
                else if (metaName.Contains("__resource"))
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
            foreach (string subdirectory in subdirectoryEntries)
            {
                if (!subdirectory.Contains("merged"))
                {
                    i = i + 1;
                    Console.WriteLine((i / length).ToString());
                    backgroundWorker1.ReportProgress((int)((i / length) * 100));
                    Console.WriteLine(subdirectory);
                    //LoadSubDir(subdirectory);
                    bunifuCustomLabel5.Text = "Loading " + subdirectory;
                    Console.WriteLine("Loading " + subdirectory);
                    bunifuCustomLabel5.Refresh();
                    DirectoryInfo d = new DirectoryInfo(subdirectory);
                    FileInfo[] Files = d.GetFiles("*.meta");
                    foreach (FileInfo file in Files)
                    {
                        if (file.Name == "vehicles.meta")
                        {
                            XmlDocument vehicles = new XmlDocument();
                            vehicles.Load(file.FullName);
                            vehicleName = vehicleName + "|" + VehiclesMeta.Merge(vehicles, bunifuCustomLabel1.Text + "/merged/vehicles.meta", bunifuCustomLabel1.Text + "/merged/vehiclename.txt");
                        }
                        if (file.Name == "carcols.meta")
                        {
                            XmlDocument carcols = new XmlDocument();
                            carcols.Load(file.FullName);
                            CarcolsMeta.Merge(carcols, bunifuCustomLabel1.Text + "/merged/carcols.meta");
                        }
                        if (file.Name == "handling.meta")
                        {
                            XmlDocument handling = new XmlDocument();
                            handling.Load(file.FullName);
                            HandlingMeta.Merge(handling, bunifuCustomLabel1.Text + "/merged/handling.meta");
                        }
                        if (file.Name == "carvariations.meta")
                        {
                            XmlDocument carvariations = new XmlDocument();
                            carvariations.Load(file.FullName);
                            CarvariationsMeta.Merge(carvariations, bunifuCustomLabel1.Text + "/merged/carvariations.meta");
                        }
                        if (file.Name == "vehiclelayouts.meta")
                        {
                            XmlDocument vehiclelayouts = new XmlDocument();
                            vehiclelayouts.Load(file.FullName);
                            VehiclelayoutsMeta.Merge(vehiclelayouts, bunifuCustomLabel1.Text + "/merged/vehiclelayouts.meta");
                        }
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
                    //Console.WriteLine("222222222");
                }
                Thread.Sleep(500);
            }
            using (StreamWriter sw = File.CreateText(bunifuCustomLabel1.Text + "/merged/Merged-Vehicle.txt"))
            {
                sw.WriteLine(vehicleName);
            }
            backgroundWorker1.ReportProgress(100);
            //Console.WriteLine("end");
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //throw new NotImplementedException();
            if (!backgroundWorker1.CancellationPending)
            {
                Console.WriteLine(e.ProgressPercentage.ToString());
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
        private void LoadSubDir(string dir)
        {
            bunifuCustomLabel5.Text = "Loading " + dir;
            Console.WriteLine("Loading " + dir);
            bunifuCustomLabel5.Refresh();
            DirectoryInfo d = new DirectoryInfo(dir);
            FileInfo[] Files = d.GetFiles("*.meta");
            foreach (FileInfo file in Files)
            {
                if (file.Name == "vehicles.meta")
                {
                    XmlDocument vehicles = new XmlDocument();
                    vehicles.Load(file.FullName);
                    vehicleName = vehicleName+"|" + VehiclesMeta.Merge(vehicles, bunifuCustomLabel1.Text + "/merged/vehicles.meta", bunifuCustomLabel1.Text + "/merged/vehiclename.txt");
                }
                if (file.Name == "carcols.meta")
                {
                    XmlDocument carcols = new XmlDocument();
                    carcols.Load(file.FullName);
                    CarcolsMeta.Merge(carcols, bunifuCustomLabel1.Text + "/merged/carcols.meta");
                }
                if (file.Name == "handling.meta")
                {
                    XmlDocument handling = new XmlDocument();
                    handling.Load(file.FullName);
                    HandlingMeta.Merge(handling, bunifuCustomLabel1.Text + "/merged/handling.meta");
                }
                if (file.Name == "carvariations.meta")
                {
                    XmlDocument carvariations = new XmlDocument();
                    carvariations.Load(file.FullName);
                    CarvariationsMeta.Merge(carvariations, bunifuCustomLabel1.Text + "/merged/carvariations.meta");
                }
                if (file.Name == "vehiclelayouts.meta")
                {
                    XmlDocument vehiclelayouts = new XmlDocument();
                    vehiclelayouts.Load(file.FullName);
                    VehiclelayoutsMeta.Merge(vehiclelayouts, bunifuCustomLabel1.Text + "/merged/vehiclelayouts.meta");
                }
            }
            if (Directory.Exists(dir + "/stream"))
            {
                DirectoryInfo stream = new DirectoryInfo(dir + "/stream");
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

        public void Notification(string mes)
        {
            bunifuCustomLabel2.Text = mes;
        }
    }
}
