using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Gbamis
{
    [CreateAssetMenu(fileName = "Consumeable", menuName = "Scriptable Objects/Inventory/ConsumeableData")]
    public class Consumable_SO : ScriptableObject
    {
        public enum ConsumableType
        {
            COIN, HEALTH, GRENADE, AXE, INVISIBILITY, SHIELD, POISION_DUST, TAP_AND_FOLLOW_CHARM
        }

        public ConsumableType consumableType;
        public Sprite consumableUIIcon;
        public Texture2D cursoIcon;

        public float consumableLevel;
        public InventoryEvent_SO inventoryEvent_SO;

        public void USE()
        {
            switch (consumableType)
            {
                case ConsumableType.AXE:
                    Cursor.SetCursor(cursoIcon, Vector2.zero, CursorMode.Auto);
                    break;

                case ConsumableType.POISION_DUST:
                    Cursor.SetCursor(cursoIcon, Vector2.zero, CursorMode.Auto); ;
                    break;

                case ConsumableType.INVISIBILITY:
                    Cursor.SetCursor(cursoIcon, Vector2.zero, CursorMode.Auto);
                    break;

                case ConsumableType.SHIELD:
                    Cursor.SetCursor(cursoIcon, Vector2.zero, CursorMode.Auto); ;
                    break;
            }
            inventoryEvent_SO.USE_Consumable(this);
        }

    }
}
