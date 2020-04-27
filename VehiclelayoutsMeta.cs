using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MergeForm
{
    class VehiclelayoutsMeta
    {
        public static void Merge(XmlDocument vehicles, string rootPath)
        {
            XmlDocument Root = new XmlDocument();
            Root.Load(rootPath);
            XmlNode RootAnimRateSets = Root.SelectSingleNode("/CVehicleMetadataMgr/AnimRateSets");
            XmlNode RootClipSetMaps = Root.SelectSingleNode("/CVehicleMetadataMgr/ClipSetMaps");
            XmlNode RootVehicleCoverBoundOffsetInfos = Root.SelectSingleNode("/CVehicleMetadataMgr/VehicleCoverBoundOffsetInfos");
            XmlNode RootBicycleInfos = Root.SelectSingleNode("/CVehicleMetadataMgr/BicycleInfos");
            XmlNode RootPOVTuningInfos = Root.SelectSingleNode("/CVehicleMetadataMgr/POVTuningInfos");
            XmlNode RootEntryAnimVariations = Root.SelectSingleNode("/CVehicleMetadataMgr/EntryAnimVariations");
            XmlNode RootVehicleExtraPointsInfos = Root.SelectSingleNode("/CVehicleMetadataMgr/VehicleExtraPointsInfos");
            XmlNode RootDrivebyWeaponGroups = Root.SelectSingleNode("/CVehicleMetadataMgr/DrivebyWeaponGroups");
            XmlNode RootVehicleDriveByAnimInfos = Root.SelectSingleNode("/CVehicleMetadataMgr/VehicleDriveByAnimInfos");
            XmlNode RootVehicleDriveByInfos = Root.SelectSingleNode("/CVehicleMetadataMgr/VehicleDriveByInfos");
            XmlNode RootVehicleSeatInfos = Root.SelectSingleNode("/CVehicleMetadataMgr/VehicleSeatInfos");
            XmlNode RootVehicleSeatAnimInfos = Root.SelectSingleNode("/CVehicleMetadataMgr/VehicleSeatAnimInfos");
            XmlNode RootVehicleEntryPointInfos = Root.SelectSingleNode("/CVehicleMetadataMgr/VehicleEntryPointInfos");
            XmlNode RootVehicleEntryPointAnimInfos = Root.SelectSingleNode("/CVehicleMetadataMgr/VehicleEntryPointAnimInfos");
            XmlNode RootVehicleExplosionInfos = Root.SelectSingleNode("/CVehicleMetadataMgr/VehicleExplosionInfos");
            XmlNode RootVehicleLayoutInfos = Root.SelectSingleNode("/CVehicleMetadataMgr/VehicleLayoutInfos");
            XmlNode RootVehicleScenarioLayoutInfos = Root.SelectSingleNode("/CVehicleMetadataMgr/VehicleScenarioLayoutInfos");
            XmlNode RootSeatOverrideAnimInfos = Root.SelectSingleNode("/CVehicleMetadataMgr/SeatOverrideAnimInfos");
            XmlNode RootInVehicleOverrideInfos = Root.SelectSingleNode("/CVehicleMetadataMgr/InVehicleOverrideInfos");
            XmlNode RootFirstPersonDriveByLookAroundData = Root.SelectSingleNode("/CVehicleMetadataMgr/FirstPersonDriveByLookAroundData");
            if (RootAnimRateSets == null)
            {
                XmlNode tempAnimRateSets = Root.CreateElement("AnimRateSets");
                Root.DocumentElement.AppendChild(tempAnimRateSets);
            }
            XmlNode RootAnimRateSets2 = Root.SelectSingleNode("/CVehicleMetadataMgr/AnimRateSets");
            if (RootClipSetMaps == null)
            {
                XmlNode tempClipSetMaps = Root.CreateElement("ClipSetMaps");
                Root.DocumentElement.AppendChild(tempClipSetMaps);
            }
            XmlNode RootClipSetMaps2 = Root.SelectSingleNode("/CVehicleMetadataMgr/ClipSetMaps");
            if (RootVehicleCoverBoundOffsetInfos == null)
            {
                XmlNode tempVehicleCoverBoundOffsetInfos = Root.CreateElement("VehicleCoverBoundOffsetInfos");
                Root.DocumentElement.AppendChild(tempVehicleCoverBoundOffsetInfos);
            }
            XmlNode RootVehicleCoverBoundOffsetInfos2 = Root.SelectSingleNode("/CVehicleMetadataMgr/VehicleCoverBoundOffsetInfos");
            if (RootBicycleInfos == null)
            {
                XmlNode tempBicycleInfos = Root.CreateElement("BicycleInfos");
                Root.DocumentElement.AppendChild(tempBicycleInfos);
            }
            XmlNode RootBicycleInfos2 = Root.SelectSingleNode("/CVehicleMetadataMgr/BicycleInfos");
            if (RootPOVTuningInfos == null)
            {
                XmlNode tempPOVTuningInfos = Root.CreateElement("POVTuningInfos");
                Root.DocumentElement.AppendChild(tempPOVTuningInfos);
            }
            XmlNode RootPOVTuningInfos2 = Root.SelectSingleNode("/CVehicleMetadataMgr/POVTuningInfos");
            if (RootEntryAnimVariations == null)
            {
                XmlNode tempEntryAnimVariations = Root.CreateElement("EntryAnimVariations");
                Root.DocumentElement.AppendChild(tempEntryAnimVariations);
            }
            XmlNode RootEntryAnimVariations2 = Root.SelectSingleNode("/CVehicleMetadataMgr/EntryAnimVariations");
            if (RootVehicleExtraPointsInfos == null)
            {
                XmlNode tempVehicleExtraPointsInfos = Root.CreateElement("VehicleExtraPointsInfos");
                Root.DocumentElement.AppendChild(tempVehicleExtraPointsInfos);
            }
            XmlNode RootVehicleExtraPointsInfos2 = Root.SelectSingleNode("/CVehicleMetadataMgr/VehicleExtraPointsInfos");
            if (RootDrivebyWeaponGroups == null)
            {
                XmlNode tempDrivebyWeaponGroups = Root.CreateElement("DrivebyWeaponGroups");
                Root.DocumentElement.AppendChild(tempDrivebyWeaponGroups);
            }
            XmlNode RootDrivebyWeaponGroups2 = Root.SelectSingleNode("/CVehicleMetadataMgr/DrivebyWeaponGroups");
            if (RootVehicleDriveByAnimInfos == null)
            {
                XmlNode tempVehicleDriveByAnimInfos = Root.CreateElement("VehicleDriveByAnimInfos");
                Root.DocumentElement.AppendChild(tempVehicleDriveByAnimInfos);
            }
            XmlNode RootVehicleDriveByAnimInfos2 = Root.SelectSingleNode("/CVehicleMetadataMgr/VehicleDriveByAnimInfos");
            if (RootVehicleDriveByInfos == null)
            {
                XmlNode tempVehicleDriveByInfos = Root.CreateElement("VehicleDriveByInfos");
                Root.DocumentElement.AppendChild(tempVehicleDriveByInfos);
            }
            XmlNode RootVehicleDriveByInfos2 = Root.SelectSingleNode("/CVehicleMetadataMgr/VehicleDriveByInfos");
            if (RootVehicleSeatInfos == null)
            {
                XmlNode tempVehicleSeatInfos = Root.CreateElement("VehicleSeatInfos");
                Root.DocumentElement.AppendChild(tempVehicleSeatInfos);
            }
            XmlNode RootVehicleSeatInfos2 = Root.SelectSingleNode("/CVehicleMetadataMgr/VehicleSeatInfos");
            if (RootVehicleSeatAnimInfos == null)
            {
                XmlNode tempVehicleSeatAnimInfos = Root.CreateElement("VehicleSeatAnimInfos");
                Root.DocumentElement.AppendChild(tempVehicleSeatAnimInfos);
            }
            XmlNode RootVehicleSeatAnimInfos2 = Root.SelectSingleNode("/CVehicleMetadataMgr/VehicleSeatAnimInfos");
            if (RootVehicleEntryPointInfos == null)
            {
                XmlNode tempVehicleEntryPointInfos = Root.CreateElement("VehicleEntryPointInfos");
                Root.DocumentElement.AppendChild(tempVehicleEntryPointInfos);
            }
            XmlNode RootVehicleEntryPointInfos2 = Root.SelectSingleNode("/CVehicleMetadataMgr/VehicleEntryPointInfos");
            if (RootVehicleEntryPointAnimInfos == null)
            {
                XmlNode tempVehicleEntryPointAnimInfos = Root.CreateElement("VehicleEntryPointAnimInfos");
                Root.DocumentElement.AppendChild(tempVehicleEntryPointAnimInfos);
            }
            XmlNode RootVehicleEntryPointAnimInfos2 = Root.SelectSingleNode("/CVehicleMetadataMgr/VehicleEntryPointAnimInfos");
            if (RootVehicleExplosionInfos == null)
            {
                XmlNode tempVehicleExplosionInfos = Root.CreateElement("VehicleExplosionInfos");
                Root.DocumentElement.AppendChild(tempVehicleExplosionInfos);
            }
            XmlNode RootVehicleExplosionInfos2 = Root.SelectSingleNode("/CVehicleMetadataMgr/VehicleExplosionInfos");
            if (RootVehicleLayoutInfos == null)
            {
                XmlNode tempVehicleLayoutInfos = Root.CreateElement("VehicleLayoutInfos");
                Root.DocumentElement.AppendChild(tempVehicleLayoutInfos);
            }
            XmlNode RootVehicleLayoutInfos2 = Root.SelectSingleNode("/CVehicleMetadataMgr/VehicleLayoutInfos");
            if (RootVehicleScenarioLayoutInfos == null)
            {
                XmlNode tempVehicleScenarioLayoutInfos = Root.CreateElement("VehicleScenarioLayoutInfos");
                Root.DocumentElement.AppendChild(tempVehicleScenarioLayoutInfos);
            }
            XmlNode RootVehicleScenarioLayoutInfos2 = Root.SelectSingleNode("/CVehicleMetadataMgr/VehicleScenarioLayoutInfos");
            if (RootSeatOverrideAnimInfos == null)
            {
                XmlNode tempSeatOverrideAnimInfos = Root.CreateElement("SeatOverrideAnimInfos");
                Root.DocumentElement.AppendChild(tempSeatOverrideAnimInfos);
            }
            XmlNode RootSeatOverrideAnimInfos2 = Root.SelectSingleNode("/CVehicleMetadataMgr/SeatOverrideAnimInfos");
            if (RootInVehicleOverrideInfos == null)
            {
                XmlNode tempInVehicleOverrideInfos = Root.CreateElement("InVehicleOverrideInfos");
                Root.DocumentElement.AppendChild(tempInVehicleOverrideInfos);
            }
            XmlNode RootInVehicleOverrideInfos2 = Root.SelectSingleNode("/CVehicleMetadataMgr/InVehicleOverrideInfos");
            if (RootFirstPersonDriveByLookAroundData == null)
            {
                XmlNode tempFirstPersonDriveByLookAroundData = Root.CreateElement("FirstPersonDriveByLookAroundData");
                Root.DocumentElement.AppendChild(tempFirstPersonDriveByLookAroundData);
            }
            XmlNode RootFirstPersonDriveByLookAroundData2 = Root.SelectSingleNode("/CVehicleMetadataMgr/FirstPersonDriveByLookAroundData");
            XmlNode newAnimRateSets = vehicles.SelectSingleNode("/CVehicleMetadataMgr/AnimRateSets");
            XmlNode newClipSetMaps = vehicles.SelectSingleNode("/CVehicleMetadataMgr/ClipSetMaps");
            XmlNode newVehicleCoverBoundOffsetInfos = vehicles.SelectSingleNode("/CVehicleMetadataMgr/VehicleCoverBoundOffsetInfos");
            XmlNode newBicycleInfos = vehicles.SelectSingleNode("/CVehicleMetadataMgr/BicycleInfos");
            XmlNode newPOVTuningInfos = vehicles.SelectSingleNode("/CVehicleMetadataMgr/POVTuningInfos");
            XmlNode newEntryAnimVariations = vehicles.SelectSingleNode("/CVehicleMetadataMgr/EntryAnimVariations");
            XmlNode newVehicleExtraPointsInfos = vehicles.SelectSingleNode("/CVehicleMetadataMgr/VehicleExtraPointsInfos");
            XmlNode newDrivebyWeaponGroups = vehicles.SelectSingleNode("/CVehicleMetadataMgr/DrivebyWeaponGroups");
            XmlNode newVehicleDriveByAnimInfos = vehicles.SelectSingleNode("/CVehicleMetadataMgr/VehicleDriveByAnimInfos");
            XmlNode newVehicleDriveByInfos = vehicles.SelectSingleNode("/CVehicleMetadataMgr/VehicleDriveByInfos");
            XmlNode newVehicleSeatInfos = vehicles.SelectSingleNode("/CVehicleMetadataMgr/VehicleSeatInfos");
            XmlNode newVehicleSeatAnimInfos = vehicles.SelectSingleNode("/CVehicleMetadataMgr/VehicleSeatAnimInfos");
            XmlNode newVehicleEntryPointInfos = vehicles.SelectSingleNode("/CVehicleMetadataMgr/VehicleEntryPointInfos");
            XmlNode newVehicleEntryPointAnimInfos = vehicles.SelectSingleNode("/CVehicleMetadataMgr/VehicleEntryPointAnimInfos");
            XmlNode newVehicleExplosionInfos = vehicles.SelectSingleNode("/CVehicleMetadataMgr/VehicleExplosionInfos");
            XmlNode newVehicleLayoutInfos = vehicles.SelectSingleNode("/CVehicleMetadataMgr/VehicleLayoutInfos");
            XmlNode newVehicleScenarioLayoutInfos = vehicles.SelectSingleNode("/CVehicleMetadataMgr/VehicleScenarioLayoutInfos");
            XmlNode newSeatOverrideAnimInfos = vehicles.SelectSingleNode("/CVehicleMetadataMgr/SeatOverrideAnimInfos");
            XmlNode newInVehicleOverrideInfos = vehicles.SelectSingleNode("/CVehicleMetadataMgr/InVehicleOverrideInfos");
            XmlNode newFirstPersonDriveByLookAroundData = vehicles.SelectSingleNode("/CVehicleMetadataMgr/FirstPersonDriveByLookAroundData");
            if (newAnimRateSets != null)
            {
                foreach (XmlNode item in newAnimRateSets)
                {
                    XmlNode tempAnimRateSets = Root.ImportNode(item, true);
                    RootAnimRateSets2.AppendChild(tempAnimRateSets);
                }
            }
            if (newClipSetMaps != null)
            {
                foreach (XmlNode item in newClipSetMaps)
                {
                    XmlNode tempClipSetMaps = Root.ImportNode(item, true);
                    RootClipSetMaps2.AppendChild(tempClipSetMaps);
                }
            }
            if (newVehicleCoverBoundOffsetInfos != null)
            {
                foreach (XmlNode item in newVehicleCoverBoundOffsetInfos)
                {
                    XmlNode tempVehicleCoverBoundOffsetInfos = Root.ImportNode(item, true);
                    RootVehicleCoverBoundOffsetInfos2.AppendChild(tempVehicleCoverBoundOffsetInfos);
                }
            }
            if (newBicycleInfos != null)
            {
                foreach (XmlNode item in newBicycleInfos)
                {
                    XmlNode tempBicycleInfos = Root.ImportNode(item, true);
                    RootBicycleInfos2.AppendChild(tempBicycleInfos);
                }
            }
            if (newPOVTuningInfos != null)
            {
                foreach (XmlNode item in newPOVTuningInfos)
                {
                    XmlNode tempPOVTuningInfos = Root.ImportNode(item, true);
                    RootPOVTuningInfos2.AppendChild(tempPOVTuningInfos);
                }
            }
            if (newEntryAnimVariations != null)
            {
                foreach (XmlNode item in newEntryAnimVariations)
                {
                    XmlNode tempEntryAnimVariations = Root.ImportNode(item, true);
                    RootEntryAnimVariations2.AppendChild(tempEntryAnimVariations);
                }
            }
            if (newVehicleExtraPointsInfos != null)
            {
                foreach (XmlNode item in newVehicleExtraPointsInfos)
                {
                    XmlNode tempVehicleExtraPointsInfos = Root.ImportNode(item, true);
                    RootVehicleExtraPointsInfos2.AppendChild(tempVehicleExtraPointsInfos);
                }
            }
            if (newDrivebyWeaponGroups != null)
            {
                foreach (XmlNode item in newDrivebyWeaponGroups)
                {
                    XmlNode tempDrivebyWeaponGroups = Root.ImportNode(item, true);
                    RootDrivebyWeaponGroups2.AppendChild(tempDrivebyWeaponGroups);
                }
            }
            if (newVehicleDriveByAnimInfos != null)
            {
                foreach (XmlNode item in newVehicleDriveByAnimInfos)
                {
                    XmlNode tempVehicleDriveByAnimInfos = Root.ImportNode(item, true);
                    RootVehicleDriveByAnimInfos2.AppendChild(tempVehicleDriveByAnimInfos);
                }
            }
            if (newVehicleDriveByInfos != null)
            {
                foreach (XmlNode item in newVehicleDriveByInfos)
                {
                    XmlNode tempVehicleDriveByInfos = Root.ImportNode(item, true);
                    RootVehicleDriveByInfos2.AppendChild(tempVehicleDriveByInfos);
                }
            }
            if (newVehicleSeatInfos != null)
            {
                foreach (XmlNode item in newVehicleSeatInfos)
                {
                    XmlNode tempVehicleSeatInfos = Root.ImportNode(item, true);
                    RootVehicleSeatInfos2.AppendChild(tempVehicleSeatInfos);
                }
            }
            if (newVehicleSeatAnimInfos != null)
            {
                foreach (XmlNode item in newVehicleSeatAnimInfos)
                {
                    XmlNode tempVehicleSeatAnimInfos = Root.ImportNode(item, true);
                    RootVehicleSeatAnimInfos2.AppendChild(tempVehicleSeatAnimInfos);
                }
            }
            if (newVehicleEntryPointInfos != null)
            {
                foreach (XmlNode item in newVehicleEntryPointInfos)
                {
                    XmlNode tempVehicleEntryPointInfos = Root.ImportNode(item, true);
                    RootVehicleEntryPointInfos2.AppendChild(tempVehicleEntryPointInfos);
                }
            }
            if (newVehicleEntryPointAnimInfos != null)
            {
                foreach (XmlNode item in newVehicleEntryPointAnimInfos)
                {
                    XmlNode tempVehicleEntryPointAnimInfos = Root.ImportNode(item, true);
                    RootVehicleEntryPointAnimInfos2.AppendChild(tempVehicleEntryPointAnimInfos);
                }
            }
            if (newVehicleExplosionInfos != null)
            {
                foreach (XmlNode item in newVehicleExplosionInfos)
                {
                    XmlNode tempVehicleExplosionInfos = Root.ImportNode(item, true);
                    RootVehicleExplosionInfos2.AppendChild(tempVehicleExplosionInfos);
                }
            }
            if (newVehicleLayoutInfos != null)
            {
                foreach (XmlNode item in newVehicleLayoutInfos)
                {
                    XmlNode tempVehicleLayoutInfos = Root.ImportNode(item, true);
                    RootVehicleLayoutInfos2.AppendChild(tempVehicleLayoutInfos);
                }
            }
            if (newVehicleScenarioLayoutInfos != null)
            {
                foreach (XmlNode item in newVehicleScenarioLayoutInfos)
                {
                    XmlNode tempVehicleScenarioLayoutInfos = Root.ImportNode(item, true);
                    RootVehicleScenarioLayoutInfos2.AppendChild(tempVehicleScenarioLayoutInfos);
                }
            }
            if (newSeatOverrideAnimInfos != null)
            {
                foreach (XmlNode item in newSeatOverrideAnimInfos)
                {
                    XmlNode tempSeatOverrideAnimInfos = Root.ImportNode(item, true);
                    RootSeatOverrideAnimInfos2.AppendChild(tempSeatOverrideAnimInfos);
                }
            }
            if (newInVehicleOverrideInfos != null)
            {
                foreach (XmlNode item in newInVehicleOverrideInfos)
                {
                    XmlNode tempInVehicleOverrideInfos = Root.ImportNode(item, true);
                    RootInVehicleOverrideInfos2.AppendChild(tempInVehicleOverrideInfos);
                }
            }
            if (newFirstPersonDriveByLookAroundData != null)
            {
                foreach (XmlNode item in newFirstPersonDriveByLookAroundData)
                {
                    XmlNode tempFirstPersonDriveByLookAroundData = Root.ImportNode(item, true);
                    RootFirstPersonDriveByLookAroundData2.AppendChild(tempFirstPersonDriveByLookAroundData);
                }
            }
            Root.Save(rootPath);
        }
    }
}
