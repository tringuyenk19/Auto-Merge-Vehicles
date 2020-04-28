using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MergeForm
{
    class CarcolsMeta
    {
        public static void Merge(XmlDocument vehicles, string rootPath)
        {
            XmlDocument Root = new XmlDocument();
            Root.Load(rootPath);
            XmlNode RootKits = Root.SelectSingleNode("/CVehicleModelInfoVarGlobal/Kits");
            XmlNode RootLights = Root.SelectSingleNode("/CVehicleModelInfoVarGlobal/Lights");
            if (RootKits == null)
            {
                XmlNode tempKits = Root.CreateElement("Kits");
                Root.DocumentElement.AppendChild(tempKits);
            }
            if (RootLights == null)
            {
                XmlNode tempLights = Root.CreateElement("Lights");
                Root.DocumentElement.AppendChild(tempLights);
            }
            XmlNode RootKits2 = Root.SelectSingleNode("/CVehicleModelInfoVarGlobal/Kits");
            XmlNode RootLights2 = Root.SelectSingleNode("/CVehicleModelInfoVarGlobal/Lights");
            Root.Save(rootPath);
            XmlNode newKits = vehicles.SelectSingleNode("/CVehicleModelInfoVarGlobal/Kits");
            XmlNode newLights = vehicles.SelectSingleNode("/CVehicleModelInfoVarGlobal/Lights");
            if (newKits != null)
            {
                foreach (XmlNode item in newKits.ChildNodes)
                {
                    XmlNode tempKits = Root.ImportNode(item, true);
                    RootKits2.AppendChild(tempKits);
                }
            }
            if (newLights != null)
            {
                foreach (XmlNode item in newLights.ChildNodes)
                {
                    XmlNode tempLights = Root.ImportNode(item, true);
                    RootLights2.AppendChild(tempLights);
                }
            }
            Root.Save(rootPath);
        }
    }
}
