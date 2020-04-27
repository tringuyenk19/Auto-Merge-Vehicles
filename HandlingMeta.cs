using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MergeForm
{
    class HandlingMeta
    {
        public static void Merge(XmlDocument vehicles, string rootPath)
        {
            XmlDocument Root = new XmlDocument();
            Root.Load(rootPath);
            XmlNode RootHandlingData = Root.SelectSingleNode("/CHandlingDataMgr/HandlingData");
            if (RootHandlingData == null)
            {
                XmlNode tempHandlingData = Root.CreateElement("HandlingData");
                Root.DocumentElement.AppendChild(tempHandlingData);
            }
            XmlNode RootHandlingData2 = Root.SelectSingleNode("/CHandlingDataMgr/HandlingData");
            XmlNode newHandlingData = vehicles.SelectSingleNode("/CHandlingDataMgr/HandlingData");
            if (newHandlingData != null)
            {
                foreach (XmlNode item in newHandlingData)
                {
                    XmlNode tempHandlingData = Root.ImportNode(item, true);
                    RootHandlingData2.AppendChild(tempHandlingData);
                }
            }
            Root.Save(rootPath);
        }
    }
}
