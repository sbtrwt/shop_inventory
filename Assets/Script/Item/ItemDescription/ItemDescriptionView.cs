using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShopInventory.Item
{
    public class ItemDescriptionView : MonoBehaviour
    {
        private ItemDescriptionController itemDescriptionController;

        [SerializeField] private Image itemImage;
        [SerializeField] private TMP_Text textDescription;
        [SerializeField] private Button addButton;
        [SerializeField] private Button removeButton;
        [SerializeField] private Button actionButton;
        [SerializeField] private TMP_Text textPrice;
        [SerializeField] private TMP_Text textQuantity;
        [SerializeField] private TMP_Text textWeight;
        private ItemSO itemData;
        private void Start()
        {

            textDescription.text = "Test";

            actionButton.onClick.AddListener(OnActionButtonClick);

            addButton.onClick.AddListener(OnAddQuantityButtonClick);

            removeButton.onClick.AddListener(OnRemoveQuantityButtonClick);
        }
        public void SetParent(GameObject parent)
        {
            gameObject.transform.SetParent(parent.transform, false);
        }

        public void SetController(ItemDescriptionController controller)
        {
            itemDescriptionController = controller;
        }

        public void SetItemData(ItemSO itemData)
        {
            this.itemData = itemData;
            textDescription.text = itemData.Description;
            textPrice.text = itemData.BuyPrice.ToString();
            textQuantity.text = itemData.Quantity.ToString();
            itemImage.sprite = itemData.Icon;
            textWeight.text = $"Weight : {itemData.Weight}";
        }

        public void OnActionButtonClick()
        {
            itemDescriptionController.OnActionButtonClick();
        }
        public void OnAddQuantityButtonClick()
        {
            itemDescriptionController.OnAddQuantity();
        }
        public void OnRemoveQuantityButtonClick()
        {
            itemDescriptionController.OnRemoveQuantity();
        }
        public void SetQuantity(float quantity)
        {
            textQuantity.text = quantity.ToString();
        }
    }
}