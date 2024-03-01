using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ShopInventory.Item
{
    public class ItemService
    {
        private List<ItemSO> allItems;
        private List<ItemController> allItemControllers;
        private GameObject parent;
        public ItemService()
        {
                
        }

        public void InitController(List<ItemSO> allItems, GameObject parent)
        {
            this.allItems = allItems;
            allItemControllers = new List<ItemController>();
            if(allItems != null)
            {
                foreach(var item in allItems)
                {
                    allItemControllers.Add(new ItemController(new ItemModel { 
                         itemSO = item,
                         parent = parent
                    }));
                }
            }
        }
        public void SetItemParent(GameObject parent)
        {
            
            if (allItemControllers != null)
            {
                foreach (var i in allItemControllers)
                {
                    i.SetParent(parent);
                }
            }
        }

        public void SetParent(GameObject parent)
        {
            this.parent = parent;
            SetItemParent(parent);
        }
    }
}
