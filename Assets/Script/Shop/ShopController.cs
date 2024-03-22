using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShopInventory.Shop
{
    public class ShopController
    {
        private ShopView shopView;
        private ShopModel shopModel;

        public ShopController(ShopModel model)
        {
            shopModel = model;
           
            InitView();
        }

      
        public void InitView()
        {
            shopView = Object.Instantiate(shopModel.ShopSO.ShopPrefab);
            shopView.SetController(this);
            shopView.SetParent(shopModel.Canvas);
            shopView.SetShopButton(shopModel.ShopButton);
            
        }
        public void OpenShop() {
            shopView.gameObject.SetActive(true);
        }
        public void CloseShop() { shopView.gameObject.SetActive(false); }
        public void ToggleShop()
        {
            shopView.gameObject.SetActive(!shopView.gameObject.activeSelf);
        }
        public void BuyItem() { }

        public GameObject GetViewObject()
        {
            return shopView.gameObject;
        }
    }
}
