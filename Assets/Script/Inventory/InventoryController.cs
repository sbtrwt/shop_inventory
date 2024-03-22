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
            inventoryView = Object.Instantiate(inventoryModel.InventorySO.InventoryPrefab);
            inventoryView.SetController(this);
            inventoryView.SetParent(inventoryModel.Canvas);
            inventoryView.SetInventoryButton(inventoryModel.ToggleButton);

        }
       
        public void ToggleInventory()
        {
            inventoryView.gameObject.SetActive(!inventoryView.gameObject.activeSelf);
        }
        

        public GameObject GetViewObject()
        {
            return inventoryView.gameObject;
        }
        public void SetWeight(float weight)
        {
            inventoryView.SetWeight(weight);
        }
    }
}