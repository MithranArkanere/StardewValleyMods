using System;
using System.IO;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using xTile;
using BeyondtheValleyExpansion.Framework;
using BeyondtheValleyExpansion.Framework.Actions;
using BeyondtheValleyExpansion.Framework.Multiplayer;

namespace BeyondtheValleyExpansion
{
    class ModEntry : Mod, IAssetLoader 
    {
        /**
        ** Fields
        ***/
        /// <summary> Provides simplified API's for writing mods. </summary>
        public static IModHelper ModHelper;
        /// <summary> Encapsulates monitoring and logging for a given module. </summary>
        public static IMonitor ModMonitor;
        /// <summary> Provides translations stored in a i18n folder. </summary>
        public static ITranslationHelper i18n;
        /// <summary> Provides the mod's manifest information. </summary>
        public static IManifest Manifest;
        /// <summary> Access player-configuration options for the mod. </summary>
        public static ModConfig Config;

        /// <summary> A useless unexpected error message. </summary>
        public static string UnexpectedError = "An unexpected error has occured, you have broken the unbreakable, killed the unkillable, deciphered the undecipherable and ate the inedible. :reeeeeee: ";

        /// <summary> Receive and complete actions based on received messages through the multiplayer API. </summary>
        private MultiplayerMessageFramework _MultiplayerMessageFramework;
        /// <summary> Provides access to the framework for adding custom tile actions on maps. </summary>
        private TileActionFramework _TileActionFramework;
        /// <summary> Apply supported tilesheet recolours when a mod matching the unique id is also running. </summary>
        private TilesheetCompatibility _TilesheetCompatibility;

        /**
        ** Get API 
        ***/
        public override object GetApi()
        {
            return new BeyondtheValleyExpansionAPI();
        }

        /**
        ** Entry
        ***/
        /// <summary> The mod's entry point. </summary> 
        /// <param name="helper"> Provides simplified API's for writing mods. </param>
        public override void Entry(IModHelper helper)
        {
            /* set static fields */
            ModEntry.ModHelper = helper;
            ModEntry.ModMonitor = this.Monitor;
            ModEntry.i18n = helper.Translation;
            ModEntry.Manifest = this.ModManifest;
            ModEntry.Config = this.Helper.ReadConfig<ModConfig>();

            /* hook events */
            helper.Events.GameLoop.SaveLoaded += this.SaveLoaded;
            helper.Events.GameLoop.UpdateTicked += this.UpdateTicked;
            helper.Events.Multiplayer.ModMessageReceived += this.ModMessageReceived;
            helper.Events.Input.ButtonPressed += this.ButtonPressed;
            helper.Events.GameLoop.DayStarted += this.DayStarted;
        }

        /**
        ** Asset Loader
        ***/
        public bool CanLoad<T>(IAssetInfo asset)
        {
            if (asset.AssetNameEquals("Maps/Farm"))
                return true;

            if (asset.AssetNameEquals("Maps/Farm_Fishing"))
                return true;

            if (asset.AssetNameEquals("Maps/Farm_Foraging"))
                return true;

            if (asset.AssetNameEquals("Maps/Farm_Mining"))
                return true;

            if (asset.AssetNameEquals("Maps/Farm_Combat"))
                return true;

            else
                return false;
        }

        /* TODO */
        public T Load<T>(IAssetInfo asset)
        {
            if (asset.AssetNameEquals("Maps/Farm"))
            {
                Map map = this.Helper.Content.Load<Map>("Hello");
                _TilesheetCompatibility.TilesheetRecolours(map);
                return (T)(object)map;
            }

            else
                throw new FileNotFoundException();
        }

        /**
        ** Helper Methods
        ***/ 
        /// <summary> Initialize when a save file is loaded. </summary>
        /// <param name="sender"> The object's sender. </param>
        /// <param name="e"> The event arguments. </param>
        private void SaveLoaded(object sender, SaveLoadedEventArgs e)
        {
            if (Context.IsWorldReady)
                return;

            // TODO
        }

        /// <summary> Initialize every game update tick. </summary>
        /// <param name="sender"> The object's sender. </param>
        /// <param name="e"> The event arguments. </param>
        private void UpdateTicked(object sender, UpdateTickedEventArgs e)
        {
            // TODO
        }

        /// <summary> Initialize when a mod message is received over the network. </summary>
        /// <param name="sender"> The object's sender. </param>
        /// <param name="e"> The event arguments. </param>
        private void ModMessageReceived(object sender, ModMessageReceivedEventArgs e)
        {
            _MultiplayerMessageFramework.MultiplayerMessageEntry(sender, e);
        }

        /// <summary> Initialize when a button is pressed. </summary>
        /// <param name="sender"> The object's sender. </param>
        /// <param name="e"> The event arguments. </param>
        private void ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (!Context.IsPlayerFree)
                return;

            _TileActionFramework.TileActionEntry(e);
        }

        /// <summary> Initialize on the start of the day. </summary>
        /// <param name="sender"> The object's sender. </param>
        /// <param name="e"> The event arguments. </param>
        private void DayStarted(object sender, DayStartedEventArgs e)
        {
            // TODO
        }
    }
}
