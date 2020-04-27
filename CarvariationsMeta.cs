using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MergeForm
{
    class CarvariationsMeta
    {
        public static void Merge(XmlDocument vehicles, string rootPath)
        {
            XmlDocument Root = new XmlDocument();
            Root.Load(rootPath);
            XmlNode RootvariationData = Root.SelectSingleNode("/CVehicleModelInfoVariation/variationData");
            if (RootvariationData == null)
            {
                XmlNode tempvariationData = Root.CreateElement("variationData");
                Root.DocumentElement.AppendChild(tempvariationData);
            }
            XmlNode RootvariationData2 = Root.SelectSingleNode("/CVehicleModelInfoVariation/variationData");
            XmlNode newvariationData = vehicles.SelectSingleNode("/CVehicleModelInfoVariation/variationData");
            if (newvariationData != null)
            {
                foreach (XmlNode item in newvariationData)
                {
                    XmlNode tempvariationData = Root.ImportNode(item, true);
                    RootvariationData2.AppendChild(tempvariationData);
                }
            }
            Root.Save(rootPath);
        }
    }
}
