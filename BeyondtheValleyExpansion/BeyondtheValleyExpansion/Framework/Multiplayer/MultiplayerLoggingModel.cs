using StardewModdingAPI;

namespace BeyondtheValleyExpansion.Framework.Multiplayer
{
    class MultiplayerLoggingModel
    {
        /// <summary> The log's message. </summary>
        public string Text { get; set; }
        /// <summary> The log's Log Level. </summary>
        public LogLevel LogLevel { get; set; }
    }
}
