using ShopInventory.Event;
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
        private Dictionary<int, ItemController> allItemControllers;
        private GameObject parent;
        private EventService eventService;
        public ItemService()
        {
                
        }
        public void InjectDependencies(EventService eventService)
        {
            this.eventService = eventService;
        }
        public void InitController(List<ItemSO> allItems, GameObject parent)
        {
            this.parent = parent;
            this.allItems = allItems;
            allItemControllers = new Dictionary<int , ItemController>();
            if(allItems != null)
            {
                foreach(var item in allItems)
                {
                    allItemControllers.Add(item.ID, new ItemController(new ItemModel { 
                         itemSO = item,
                         parent = parent
                    }, eventService));
                }
            }
        }
        public void SetItemParent(GameObject parent)
        {
            
            if (allItemControllers != null)
            {
                foreach (var i in allItemControllers)
                {
                    i.Value.SetParent(parent);
                }
            }
        }

        public void SetParent(GameObject parent)
        {
            this.parent = parent;
            SetItemParent(parent);
        }

        public void ResetItems()
        {
            if (allItems != null)
                allItems.Clear();
            else
                allItems = new List<ItemSO>();
        }
        public void AddNewItem(ItemSO item)
        {
            if (allItems == null)
                allItems = new List<ItemSO>();
            allItems.Add(item);
        }
        public void AddControllerByItem(ItemSO item)
        {
            if (allItemControllers == null)
                allItemControllers = new Dictionary<int, ItemController>();
            if (allItemControllers.ContainsKey(item.ID))
            {
                item.quantity += 1;
                allItemControllers[item.ID].SetItemView(item);
            }
            else
            {
                var newItemController = new ItemController(new ItemModel
                {
                    itemSO = item,
                    parent = parent
                }, eventService);
                newItemController.SetParent(parent);
                allItemControllers.Add(item.ID, newItemController);
            }
        }

        public void RemoveItem(ItemSO item)
        {
            if (allItems == null)
                allItems = new List<ItemSO>();
            allItems.Remove(item);
        }
        public void RemoveControllerByID(int id)
        {
            if(allItemControllers != null && allItemControllers.Count > 0)
            {
               if(allItemControllers.ContainsKey(id))
                {
                    allItemControllers[id].DestroyItemView();
                    allItemControllers.Remove(id);
                }
            }
        }
        public void OnActionAdd(ItemSO item)
        {
            AddNewItem(item);
            AddControllerByItem(item);
        }
        public void OnActionRemove(ItemSO item)
        {
            RemoveItem(item);
            RemoveControllerByID(item.ID);
        }
    }
}
