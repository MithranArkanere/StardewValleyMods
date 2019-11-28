using BeyondTheValleyExpansion;
using StardewValley;
using StardewValley.Menus;
using System.Collections.Generic;

namespace BeyondtheValleyExpansion.Framework.Alchemy
{
    class AlchemyFramework
    {
        /// <summary> Checks if player has unlocked alchemy. </summary>
        public static bool UnlockedAlchemy;

        /// <summary> Stores the item ids of the items currently in the alchemy pot. </summary>
        private List<int> AlchemyItems = new List<int>();
        private List<Response> AlchemyMenuResponses = new List<Response>();
        /// <summary> Currently stored amount of items in the alchemy pot. </summary>
        private int AmountOfAlchemyItems;

        /// <summary> The entry point to the alchemy framework allowing players to create and use potions. </summary>
        /// <param name="tileAction"> The tile action's string value. </param>
        /// <param name="who"> The player. </param>
        public void AlchemyEntry(string tileAction, Farmer who)
        {
            Log.Info($"{who.Name} interacted with [Action {tileAction}]");

            if (UnlockedAlchemy)
            {
                this.AlchemyMenuResponses.Add(new Response("alchemy.add", ModEntry.i18n.Get("alchemy-add")));
                this.AlchemyMenuResponses.Add(new Response("alchemy.mix", ModEntry.i18n.Get("alchemy-mix")));
                this.AlchemyMenuResponses.Add(new Response("alchemy.remove", ModEntry.i18n.Get("alchemy-remove")));

                Game1.activeClickableMenu = new DialogueBox(ModEntry.i18n.Get("tileaction-alchemy.1"), this.AlchemyMenuResponses);
                Game1.player.currentLocation.afterQuestion = new GameLocation.afterQuestionBehavior((f, choice) => {
                    this.AlchemyMenu(f, choice);
                });
            }

            else
            {
                Log.Trace($"{who.Name} failed to use the alchemy station. (Alchemy not unlocked)");
            }
        }

        private void AlchemyMenu(Farmer who, string ans)
        {
            switch (ans)
            {
                case "alchemy.add":
                    this.AddIngredient(who);
                    break;
                case "alchemy.mix":
                    this.MixIngredients(who);
                    break;
                case "alchemy.remove":
                    this.RemoveIngredients(who);
                    break;
                default:
                    Log.Error($"{ModEntry.UnexpectedError} (BeyondtheValleyExpansion.Framework.Alchemy.AlchemyFramework.AlchemyMenu)");
                    return;
            }
        }

        /// <summary> Add an ingredient to the alchemy pot. </summary>
        /// <param name="who"> The player. </param>
        private void AddIngredient(Farmer who)
        {
            string Alchemy_Failed = $"{who.Name} failed to add {who.CurrentItem.Name}[{who.CurrentItem.ParentSheetIndex}] into the alchemy station.";

            if (RefObjectCategory.AcceptedAlchemyItems.ToString().Contains(who.CurrentItem.Category.ToString()) && this.AmountOfAlchemyItems < 3)
            {
                Game1.player.removeItemsFromInventory(Game1.player.CurrentItem.ParentSheetIndex, 1);
                Log.Trace($"{who.Name} placed a {who.CurrentItem.Name} [{who.CurrentItem.ParentSheetIndex.ToString()}; Category: {who.CurrentItem.getCategoryName()}] into the alchemy pot");
                this.AlchemyItems.Add(who.CurrentItem.ParentSheetIndex);
                this.AmountOfAlchemyItems += 1;
            }

            // errors \\
            // ------ \\
            if (this.AmountOfAlchemyItems >= 3)
            {
                Game1.drawObjectDialogue(ModEntry.i18n.Get("alchemy-failed.1"));
                Log.Trace($"{Alchemy_Failed} (Alchemy station is full)");
            }

            if (!RefObjectCategory.AcceptedAlchemyItems.ToString().Contains(Game1.player.CurrentItem.Category.ToString()))
            {
                Game1.drawObjectDialogue(ModEntry.i18n.Get("alchemy-failed.2"));
                Log.Trace($"{Alchemy_Failed} (Item not accepted by the alchemy station)");
            }

            else
            {
                Game1.drawObjectDialogue(ModEntry.i18n.Get("alchemy-failed.3"));
                Log.Debug($"{Alchemy_Failed} (Unknown)");
            }
        }

        /// <summary> Mix ingredients that are currently in the alchemy station. </summary>
        /// <param name="who"> The player. </param>
        private void MixIngredients(Farmer who)
        {

        }

        /// <summary> Remove all ingredients from the alchemy station. </summary>
        /// <param name="who"> The player. </param>
        private void RemoveIngredients(Farmer who)
        {

        }
    }
}
