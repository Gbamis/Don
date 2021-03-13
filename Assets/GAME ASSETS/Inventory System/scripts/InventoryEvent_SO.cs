using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gbamis
{
    [CreateAssetMenu(fileName = "InventoryEventData", menuName = "Scriptable Objects/Inventory/InventoryEventData")]
    public class InventoryEvent_SO : ScriptableObject
    {

        public PlayerData_SO playerData_SO;
        public delegate void consumableAdded(Consumable_SO con, int index);
        public static event consumableAdded OnConsumableAdded;

        public delegate void consumableUpdatedAt(Consumable_SO con, int index);
        public static event consumableUpdatedAt OnConsumableUpdatedAt;

        public static bool mouseIsOverUIElement;

        /////////////////////////////////////
        ////Event Triggers//////////////////


        public void ConsumableAdded(Consumable_SO con, int index)
        {

            OnConsumableAdded(con, index);
        }

        public void ConsumableUpdatedAt(Consumable_SO con, int index)
        {

            OnConsumableUpdatedAt(con, index);
        }   

        public delegate void InvisibilityInUse();
        public static event InvisibilityInUse OnInvisibilityInUse;
        public static event InvisibilityInUse OnInvisibilityDisabled;
        

        public delegate void ConsumableInUse(Consumable_SO con_type);
        public static event ConsumableInUse OnConsumableInUse;
        public static event ConsumableInUse OnConsumableDisable;

        public void USE_Consumable(Consumable_SO type)
        {
            if (type.consumableType == Consumable_SO.ConsumableType.INVISIBILITY)
            {
                OnInvisibilityInUse();
                OnInvisibilityDisabled();
            }
            else if(type.consumableType == Consumable_SO.ConsumableType.HEALTH){
                playerData_SO.player_health = 100;
                EventData_SO.HealthChanged(playerData_SO.player_health);
            }

            else{
                OnConsumableInUse(type);
            }
            
        }
    }

}