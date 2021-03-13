using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gbamis
{
    [CreateAssetMenu(fileName = "InventoryDataStore", menuName = "Scriptable Objects/Inventory/InventoryDataStore")]
    public class InventoryDataStore_SO : ScriptableObject
    {
        public InventoryEvent_SO inventoryEvent_SO;
        public List<Consumable_SO> consumables;
        public int InventoryItemCount;

        public void addConsumable(Consumable_SO con)
        {
            Dictionary<bool,int> result = isDataFoundAt(con);
            if(result.ContainsKey(true)){
                if (con.consumableLevel < 10)
                {
                    con.consumableLevel += 1;
                }


                inventoryEvent_SO.ConsumableUpdatedAt(con,result[true]);
            }
            else
            {
                consumables.Add(con);
                int place = consumables.Count-1;
                inventoryEvent_SO.ConsumableAdded(con,place);
            }


        }

        public void UpdateConsumableData(Consumable_SO con)
        {
            int index = 0;
            foreach (Consumable_SO c in consumables)
            {
                if (c.consumableType == con.consumableType)
                {
                    consumables[index] = con;
                    break;
                }
                index += 1;
            }
        }
        Dictionary<bool, int> isDataFoundAt(Consumable_SO con)
        {
            Dictionary<bool, int> foundAt = new Dictionary<bool, int>();
            int index = 0;
            foreach (Consumable_SO c in consumables)
            {
                if (con.consumableType == c.consumableType)
                {
                    foundAt[true] = index;

                    return foundAt;
                }
                index += 1;

            }
            return foundAt;
        }
    }

}