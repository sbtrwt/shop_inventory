using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ShopInventory.Shop
{
    public class ShopView : MonoBehaviour
    {
        private ShopController shopController;
        private Button shopButton;
        private GameObject parent;
        // Start is called before the first frame update
        void Start()
        {
           
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetController(ShopController shopController)
        {
            this.shopController = shopController;
        }


        public void SetParent(GameObject parent)
        {
          
            if (parent != null)
            {
                this.parent = parent;
                gameObject.transform.SetParent(parent?.transform, false);
            }
               
        }

        public void SetShopButton(Button _shopButton)
        {
            shopButton = GameObject.Instantiate(_shopButton);
            if (parent != null)
                shopButton.transform.SetParent(parent.transform, false);
            shopButton.onClick.AddListener (OnToggleShop);
        }
        public void OnToggleShop()
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}