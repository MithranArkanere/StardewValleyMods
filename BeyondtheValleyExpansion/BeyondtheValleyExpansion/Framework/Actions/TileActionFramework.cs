using BeyondtheValleyExpansion.Framework.Alchemy;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace BeyondtheValleyExpansion.Framework.Actions
{
    class TileActionFramework
    {
        /// <summary> Provides access to the alchemy framework and menu. </summary>
        private AlchemyFramework _AlchemyFramework = new AlchemyFramework();

        /// <summary> The entry point of the tile action framework. </summary>
        /// <param name="e"> The ButtonPressed event arguments. </param>
        public void TileActionEntry(ButtonPressedEventArgs e)
        {
            if (e.Button.IsActionButton())
            {
                Vector2 tile = e.Cursor.GrabTile;

                string tileAction = Game1.player.currentLocation.doesTileHaveProperty((int)tile.X, (int)tile.Y, "Action", "Buildings");

                if (tileAction != null)
                    this.TileActions(tileAction);

                else
                {
                    ModEntry.ModMonitor.Log("the tile action is not specified", LogLevel.Warn);
                    return;
                }
            }
        }

        /// <summary> Read custom tile actions provided by the mod. </summary>
        /// <param name="tileAction"> The value of the Action tile property. </param>
        private void TileActions(string tileAction)
        {
            // Action BVEAlchemy
            // -----------------
            // triggers the alchemy menu dialogue
            if (tileAction.Contains("BVEAlchemy"))
            {
                Farmer who = new Farmer();

                if (ModEntry.Config.EnabledFeatures.Alchemy == false)
                {
                    ModEntry.ModMonitor.Log("The alchemy feature is disabled in the config.json", LogLevel.Info);
                    Game1.addHUDMessage(new HUDMessage("Alchemy is disabled", 3));
                    return;
                }

                else
                    _AlchemyFramework.AlchemyEntry(tileAction, who);
            }
        }
    }
}
