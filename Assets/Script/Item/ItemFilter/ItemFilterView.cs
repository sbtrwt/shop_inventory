using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShopInventory.Item
{
    public class ItemFilterView : MonoBehaviour
    {
        private ItemFilterController itemFilterController;


        [SerializeField] private Button materialButton;
        [SerializeField] private Button weaponButton;
        [SerializeField] private Button consumableButton;
        [SerializeField] private Button treasureButton;
        [SerializeField] private Button allButton;
        private void Start()
        {
            materialButton.onClick.AddListener(OnMaterialButtonClick);
            weaponButton.onClick.AddListener(OnWeaponButtonClick);
            consumableButton.onClick.AddListener(OnConsumableButtonClick);
            treasureButton.onClick.AddListener(OnTreasueButtonClick);
            allButton.onClick.AddListener(OnAllButtonClick);
        }
        public void SetParent(GameObject parent)
        {
            if (parent != null)
            {
                gameObject.transform.SetParent(parent.transform, false);
            }
        }

        public void SetController(ItemFilterController controller)
        {
            itemFilterController = controller;
        }



        public void OnMaterialButtonClick()
        {
            itemFilterController.OnClickFilter(ItemType.Material);
        }
        public void OnWeaponButtonClick()
        {
            itemFilterController.OnClickFilter(ItemType.Weapon);
        }
        public void OnConsumableButtonClick()
        {
            itemFilterController.OnClickFilter(ItemType.Consumable);
        }
        public void OnTreasueButtonClick()
        {
            itemFilterController.OnClickFilter(ItemType.Treasure);
        }
        public void OnAllButtonClick()
        {
            itemFilterController.OnClickFilter(ItemType.None);
        }
    }
}