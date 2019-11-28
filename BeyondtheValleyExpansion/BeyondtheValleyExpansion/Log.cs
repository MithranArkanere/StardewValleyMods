using BeyondtheValleyExpansion.Framework.Multiplayer;
using StardewModdingAPI;
using StardewValley;

namespace BeyondtheValleyExpansion
{
    class Log
    { 
        /// <summary> Logs important information highlighted for the player when player action is needed. </summary>
        /// <param name="message"> The message to output to the log. </param>
        public static void Alert(string message)
        {
            var model = new MultiplayerLoggingModel
            {
                Text = message,
                LogLevel = LogLevel.Alert
            };
            ModEntry.ModHelper.Multiplayer.SendMessage(model, "LogMessage");
        }

        /// <summary> Logs troubleshooting info that may be relevant to the player. </summary>
        /// <param name="message"> The message to output to the log. </param>
        public static void Debug(string message)
        {
            var model = new MultiplayerLoggingModel
            {
                Text = message,
                LogLevel = LogLevel.Debug
            };
            ModEntry.ModHelper.Multiplayer.SendMessage(model, "LogMessage");
        }

        /// <summary> Logs a message indicating that something went wrong. </summary>
        /// <param name="message"> The message to output to the log. </param>
        public static void Error(string message)
        {
            var model = new MultiplayerLoggingModel
            {
                Text = message,
                LogLevel = LogLevel.Error
            };
            ModEntry.ModHelper.Multiplayer.SendMessage(model, "LogMessage");
        }

        /// <summary> Logs info relevant to the player. </summary>
        /// <param name="message"> The message to output to the log. </param>
        public static void Info(string message)
        {
            var model = new MultiplayerLoggingModel
            {
                Text = message,
                LogLevel = LogLevel.Info
            };
            ModEntry.ModHelper.Multiplayer.SendMessage(model, "LogMessage");
        }

        /// <summary> Logs tracing info intended for developers. </summary>
        /// <param name="message"> The message to output to the log. </param>
        public static void Trace(string message)
        {
            var model = new MultiplayerLoggingModel
            {
                Text = message,
                LogLevel = LogLevel.Trace
            };

            ModEntry.ModHelper.Multiplayer.SendMessage(model, "LogMessage");
        }

        /// <summary> Logs an issue the player should be aware of. </summary>
        /// <param name="message"> The message to output to the log. </param>
        public static void Warn(string message)
        {
            var model = new MultiplayerLoggingModel
            {
                Text = message,
                LogLevel = LogLevel.Warn
            };

            ModEntry.ModHelper.Multiplayer.SendMessage(model, "LogMessage");
        }
    }
}
