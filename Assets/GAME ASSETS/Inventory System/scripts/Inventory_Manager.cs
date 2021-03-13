using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gbamis
{
    public class Inventory_Manager : MonoBehaviour
    {
        public InventoryDataStore_SO inventoryDataStore_SO;
        public GameObject gridListItem;
        public GameObject gridListLayout;


        void Awake()
        {
            CreateInventoryPanel();
        }

        void Start()
        {
            InventoryEvent_SO.OnConsumableAdded += addConsumable;
            InventoryEvent_SO.OnConsumableUpdatedAt += updateConsumableAtIndex;
            PopulatePanel();

            //////////////

        }

        void CreateInventoryPanel()
        {
            for (int i = 0; i < inventoryDataStore_SO.InventoryItemCount; i++)
            {
                GameObject clone = Instantiate(gridListItem);
                clone.transform.SetParent(gridListLayout.transform);
            }
        }

        void addConsumable(Consumable_SO con,int index)
        {

             if (gridListLayout.transform.GetChild(index).GetChild(0).gameObject.activeSelf == false)
                {
                    gridListLayout.transform.GetChild(index).GetChild(0).gameObject.GetComponent<InventoryConsumableUI>()
                    .SetData(con);

                    gridListLayout.transform.GetChild(index).GetChild(0).gameObject.SetActive(true);
                   
                }
            
            
        }

        void updateConsumableAtIndex(Consumable_SO con, int index)
        {

            gridListLayout.transform.GetChild(index).GetChild(0).gameObject.GetComponent<InventoryConsumableUI>().SetData(con);
        }
        void PopulatePanel()
        {
            if (inventoryDataStore_SO.consumables != null)
            {
                int index = 0;
                foreach (Consumable_SO con in inventoryDataStore_SO.consumables)
                {
                    gridListLayout.transform.GetChild(index)
                    .GetChild(0).gameObject
                    .GetComponent<InventoryConsumableUI>().SetData(con);

                    gridListLayout.transform.GetChild(index).GetChild(0).gameObject.SetActive(true);
                    index += 1;
                }
            }
        }

    }

}

