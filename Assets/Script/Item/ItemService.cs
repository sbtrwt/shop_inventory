using ShopInventory.Event;
using ShopInventory.Global;
using ShopInventory.Player;
using ShopInventory.Sound;
using ShopInventory.UI;
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
        private List<ItemSO> allSelectableItems;

        private Dictionary<int, ItemController> allItemControllers;
        private GameObject parent;
        private EventService eventService;
        private UIService uiService;
        private PlayerService playerService;
        private SoundService soundService;
        public ItemService()
        {

        }
        public void InjectDependencies(EventService eventService, UIService uiService, PlayerService playerService, SoundService soundService)
        {
            this.eventService = eventService;
            this.uiService = uiService;
            this.playerService = playerService;
            this.soundService = soundService;
            this.eventService.OnItemFilter.AddListener(OnFilterByItemType);
        }
        public void InitController(List<ItemSO> allItems, GameObject parent)
        {
            this.parent = parent;
            this.allItems = allItems;
            allItemControllers = new Dictionary<int, ItemController>();
            if (allItems != null)
            {
                foreach (var item in allItems)
                {

                    if (item.quantity == 0) item.quantity = 1;

                    allItemControllers.Add(item.ID, new ItemController(new ItemModel
                    {
                        itemSO = item,
                        parent = parent
                    }, eventService, soundService));
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
            soundService.PlaySoundEffects(SoundType.ItemClick);
            if (item == null) return;
            if (allItemControllers == null)
                allItemControllers = new Dictionary<int, ItemController>();
            if (allItemControllers.ContainsKey(item.ID))
            {
                ItemSO tempItem = allItemControllers[item.ID].GetItemData();
                tempItem.quantity += item.actionQuantity;
                allItemControllers[item.ID].SetItemData(tempItem);
                allItemControllers[item.ID].SetItemView(tempItem);
            }
            else
            {
                if (item.actionQuantity > 0)
                {
                    var newItemController = new ItemController(new ItemModel
                    {
                        itemSO = item,
                        parent = parent
                    }, eventService,soundService);
                    newItemController.SetParent(parent);
                    allItemControllers.Add(item.ID, newItemController);
                }
            }
            eventService.OnWeightChange.InvokeEvent();
        }

        public void RemoveItem(ItemSO item)
        {
            if (allItems == null)
                allItems = new List<ItemSO>();
            allItems.Remove(item);
        }
        public void RemoveControllerByID(int id)
        {
            if (allItemControllers != null && allItemControllers.Count > 0)
            {
                if (allItemControllers.ContainsKey(id))
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
            soundService.PlaySoundEffects(SoundType.ItemClick);
            if (allItemControllers != null && allItemControllers.Count > 0)
            {
                if (allItemControllers.ContainsKey(item.ID))
                {
                    ItemSO tempItem = allItemControllers[item.ID].GetItemData();
                    if (tempItem.quantity >= item.quantity)
                    {
                        tempItem.quantity -= item.actionQuantity;
                        allItemControllers[item.ID].SetItemData(tempItem);
                        allItemControllers[item.ID].SetItemView(tempItem);
                    }

                    if (tempItem.quantity <= 0)
                    {
                        RemoveItem(item);
                        RemoveControllerByID(item.ID);

                    }
                    eventService.OnWeightChange.InvokeEvent();
                }
            }
        }
        public void SetAllSelectableItems(List<ItemSO> allSelectableItems)
        {
            this.allSelectableItems = allSelectableItems;
        }
        public void OnMining()
        {
            soundService.PlaySoundEffects(SoundType.Mining);
            ItemSO item = GetRandomItem();
            float tempWeight = item.quantity * item.weight;
            float inventoryWeight = playerService.GetWeight();
            if ((tempWeight + inventoryWeight) <= GlobalConstant.INVENTORY_MAX_WEIGHT)
            {
                uiService.SetMessage($"You got { item.actionQuantity } { item.shortName }");
                AddControllerByItem(item);


            }
            else
            {
                uiService.SetMessage($"Weight overloaded!!");
            }
        }
        public ItemSO GetRandomItem()
        {
            if (allSelectableItems != null && allSelectableItems.Count > 0)
            {
                ItemSO tempItem = ScriptableObject.CreateInstance<ItemSO>();
                int index = UnityEngine.Random.Range(0, allSelectableItems.Count);
                tempItem.Clone(this.allSelectableItems[index]);
                int quantity = UnityEngine.Random.Range(1, 5);
                tempItem.actionQuantity = quantity;
                tempItem.quantity = quantity;
                return tempItem;
            }
            else
                return null;
        }
        public void OnFilterByItemType(ItemType type)
        {
            foreach (var itemCtrl in allItemControllers)
            {
                itemCtrl.Value.SetVisible((type == ItemType.None) || (itemCtrl.Value.GetItemData().type == type));
            }
        }
        public float GetAllWeight()
        {
            float weight = 0;
            foreach (var ctrl in allItemControllers)
            {
                var data = ctrl.Value.GetItemData();
                weight += data.weight * data.quantity;
            }
            return weight;
        }
    }
}
