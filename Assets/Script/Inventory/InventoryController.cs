using ShopInventory.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShopInventory.Inventory
{
    public class InventoryController
    {
        private InventoryView inventoryView;
        private InventoryModel inventoryModel;

        public  InventoryController(InventoryModel model)
        {
            inventoryModel = model;

            InitView();
        }


        public void InitView()
        {
            inventoryView = Object.Instantiate(inventoryModel.inventorySO.InventoryPrefab);
            inventoryView.SetController(this);
            inventoryView.SetParent(inventoryModel.canvas);
            inventoryView.SetInventoryButton(inventoryModel.toggleButton);

        }
       
        public void ToggleInventory()
        {
            inventoryView.gameObject.SetActive(!inventoryView.gameObject.activeSelf);
        }
        

        public GameObject GetViewObject()
        {
            return inventoryView.gameObject;
        }

    }
}