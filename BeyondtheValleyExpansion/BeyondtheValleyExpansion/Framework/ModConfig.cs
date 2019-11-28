using BeyondtheValleyExpansion.Framework.Config;

namespace BeyondtheValleyExpansion.Framework
{
    class ModConfig
    {
        /// <summary> Checks if specific features are enabled by the player through a configuration file. By default, everything should be set to true. </summary>
        public EnabledFeaturesConfig EnabledFeatures { get; set; } = new EnabledFeaturesConfig();
    }
}
