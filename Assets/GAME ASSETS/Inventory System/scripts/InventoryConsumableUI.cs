using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gbamis
{
    public class InventoryConsumableUI : MonoBehaviour
    {
        public InventoryDataStore_SO inventoryDataStore_SO;
        public Consumable_SO consumable_SO;
        public GameObject UI_ICON_OBJECT;
        

        public Image UI_LEVEL_OBJECT;

        public void SetData(Consumable_SO con)
        {
            this.consumable_SO = con;
            RedrawUI();
        }
        public void RedrawUI()
        {
            this.UI_ICON_OBJECT.GetComponent<Image>().sprite = consumable_SO.consumableUIIcon;
            this.UI_LEVEL_OBJECT.fillAmount = (consumable_SO.consumableLevel / 10);
        }

        public void clicked()
        {          
            this.consumable_SO.consumableLevel -= 0.4f;
            this.consumable_SO.USE();
            inventoryDataStore_SO.UpdateConsumableData(this.consumable_SO);
            RedrawUI();
        }
        public void gameMouseEnter()
        {
            InventoryEvent_SO.mouseIsOverUIElement = true;
        }
        public void gameMouseExit()
        {
            InventoryEvent_SO.mouseIsOverUIElement = false;
        }
    }
}