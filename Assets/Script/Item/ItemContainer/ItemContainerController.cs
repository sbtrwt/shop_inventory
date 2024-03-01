using ShopInventory.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainerController
{
    ItemContainerModel itemContainerModel;
    ItemContainerView itemContainerView;
    List<ItemSO> allItems;
    GameObject parent;
    public ItemContainerController(ItemContainerModel model)
    {
        itemContainerModel = model;
        InitView();
    }

    public void InitView()
    {
        itemContainerView = Object.Instantiate(itemContainerModel.itemContainerSO.ItemContainerPrefab);
        itemContainerView.SetController(this);
    }
    public void SetParent(GameObject parent)
    {
        this.parent = parent;
        itemContainerView.SetParent(parent);
    }
    public GameObject GetViewObject()
    {
        return itemContainerView.gameObject;
    }
}
