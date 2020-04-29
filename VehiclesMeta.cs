using Bunifu.Framework.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MergeForm
{
    class VehiclesMeta
    {
        public static string Merge(XmlDocument vehicles, string rootPath, string metaPath)
        {
            string vehicleName ="";
            XmlDocument Root = new XmlDocument();
            Root.Load(rootPath);
            XmlNode RootresidentTxd = Root.SelectSingleNode("/CVehicleModelInfo__InitDataList/residentTxd");
            XmlNode RootresidentAnims = Root.SelectSingleNode("/CVehicleModelInfo__InitDataList/residentAnims");
            if (RootresidentTxd == null)
            {
                XmlNode tempRootresidentTxd = Root.CreateElement("residentTxd");
                tempRootresidentTxd.InnerText = "vershare";
                Root.DocumentElement.AppendChild(tempRootresidentTxd);
            }
            if (RootresidentAnims == null)
            {
                XmlNode tempRootresidentTxd = Root.CreateElement("residentAnims");
                Root.DocumentElement.AppendChild(tempRootresidentTxd);
            }
            XmlNode newVehicles = vehicles.SelectSingleNode("/CVehicleModelInfo__InitDataList/InitDatas");
            if (newVehicles == null)
            {
                MessageBox.Show("ERROR InitDatas");
                return "InitDatas ERROR" + metaPath;
            }
            XmlNode RootVehicles = Root.SelectSingleNode("/CVehicleModelInfo__InitDataList/InitDatas");
            if (RootVehicles == null)
            {
                XmlNode tempInitDatas = Root.CreateElement("InitDatas");
                Root.DocumentElement.AppendChild(tempInitDatas);
            }
            XmlNode RootVehicles2 = Root.SelectSingleNode("/CVehicleModelInfo__InitDataList/InitDatas");
            foreach (XmlNode item in newVehicles.ChildNodes)
            {
                vehicleName = vehicleName + " " + newVehicles.FirstChild.FirstChild.InnerText;
                //XmlNode Item = Root.CreateElement("Item");
                XmlNode ImportItem = Root.ImportNode(item, true);
                //Item.AppendChild(ImportItem);
                RootVehicles2.AppendChild(ImportItem);
                Root.Save(rootPath);
            }
            XmlNode txdRelationships = vehicles.SelectSingleNode("/CVehicleModelInfo__InitDataList/txdRelationships");
            if (txdRelationships == null)
            {
                MessageBox.Show("Cant Find txdRelationships");
                return "txdRelationships ERROR "+ metaPath;
            }
            XmlNode RoottxdRelationships = Root.SelectSingleNode("/CVehicleModelInfo__InitDataList/txdRelationships");
            if (RoottxdRelationships == null)
            {
                XmlNode tempTxdRelationships = Root.CreateElement("txdRelationships");
                Root.DocumentElement.AppendChild(tempTxdRelationships);
            }
            XmlNode RoottxdRelationships2 = Root.SelectSingleNode("/CVehicleModelInfo__InitDataList/txdRelationships");
            foreach (XmlNode txd in txdRelationships.ChildNodes)
            {
                XmlNode Importtxd = Root.ImportNode(txd, true);
                RoottxdRelationships2.AppendChild(Importtxd);
                Root.Save(rootPath);
            }
            return vehicleName;
        }
    }
}
