using Synapse.Config;
using System.Collections.Generic;
using UnityEngine;

namespace SupplyDrops
{
    public class Config : AbstractConfigSection
    {
        public int MinPlayersForSupply { get; set; } = 4;

        public bool IsOnlyHelicopter { get; set; } = true;
        public bool IsOnlyCICar { get; set; } = false;

        public int CiCarChance = 50;

        public List<SerializedItem> Items { get; set; } = new List<SerializedItem>()
        {
            new SerializedItem((int) ItemType.Medkit, 0, 0, 0, 0, Vector3.one),
            new SerializedItem((int) ItemType.Medkit, 0, 0, 0, 0, Vector3.one),
            new SerializedItem((int) ItemType.Radio, 0, 0, 0, 0, Vector3.one)
        };

        public float SupplyIntervall { get; set; } = 300;

        public bool DoBroadcast { get; set; } = true;

        public ushort BroadcastDuration { get; set; } = 15;

        public bool DoCassieAnnouncement { get; set; } = true;

        public string BroadcastMessageCI { get; set; } = "<b>A Supply drop has arrived via <color=#2EB800>CI Car</color></b>";

        public string BroadcastMessageMTF { get; set; } = "<b>A Supply drop has arrived via <color=#1F22C7>NTF Helicopter</color>!</b>";

        public string CassieAnnouncement { get; set; } = "Supply has enter the facility";
    }

}