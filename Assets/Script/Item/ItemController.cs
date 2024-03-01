using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShopInventory.Item
{
    public class ItemController
    {
        private ItemView itemView;
        private ItemModel itemModel;

        public ItemController(ItemModel model)
        {
            itemModel = model;
            InitView();
            if(model?.parent)
                SetParent(model.parent);
        }

        public void InitView()
        {
            itemView = Object.Instantiate(itemModel.itemSO.itemViewPrefab);
            itemView.SetController(this);
            itemView.SetSprite(itemModel.itemSO.icon);
        }
        public void SetParent(GameObject parent)
        {
            itemModel.parent = parent;
            itemView.SetParent(parent);
        }
        public ItemSO GetItemData()
        {
            return itemModel.itemSO;
        }
    }
}