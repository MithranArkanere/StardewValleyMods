using StardewModdingAPI;
using StardewModdingAPI.Events;
using System.Linq;

namespace BeyondtheValleyExpansion.Framework.Multiplayer
{
    class MultiplayerMessageFramework
    {
        /// <summary> Acceptable message ID's that fall under Multiplayer Logging. <summary>
        private string[] MultiplayerLoggingTypes = new string[] { "Log.Alert", "Log.Debug", "Log.Error", "Log.Info", "Log.Trace", "Log.Warn" };

        /// <summary> The entry point to receiving and taking action when a mod message is received. </summary>
        /// <param name="sender"> The ModMessageReceived's object sender. </param>
        /// <param name="e"> The ModMessageReceived's event arguments. </param>
        public void MultiplayerMessageEntry(object sender, ModMessageReceivedEventArgs e)
        {
            if (e.FromModID == ModEntry.Manifest.UniqueID)
            {
                // Log messages
                if (e.Type == "LogMessage") 
                {
                    var message = e.ReadAs<MultiplayerLoggingModel>();
                    ModEntry.ModMonitor.Log(message.Text, message.LogLevel);
                }
            }

            else
            {
                ModEntry.ModMonitor.Log("False mod message received", LogLevel.Debug);
            }
        }
    }
}
