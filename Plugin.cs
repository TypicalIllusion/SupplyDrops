using SupplyDrops.Handlers;
using Synapse.Api.Plugin;

namespace SupplyDrops
{
    [PluginInformation(
        Author = "TheVoidNebula",
        Description = "Brings Supplies via MTF helicopter and CI truck.",
        LoadPriority = 0,
        Name = "SupplyDrops",
        SynapseMajor = 2,
        SynapseMinor = 4,
        SynapsePatch = 2,
        Version = "b1.0"
        )]
    public class Plugin : AbstractPlugin
    {
        [Synapse.Api.Plugin.Config(section = "SupplyDrops")]
        public static Config Config;
        public override void Load()
        {
            SynapseController.Server.Logger.Info("SupplyDrops loaded!");

            new EventHandlers();
        }
    }
}
