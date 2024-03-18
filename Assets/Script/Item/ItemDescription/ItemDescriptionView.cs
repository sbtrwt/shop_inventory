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

        [SerializeField]private Image itemImage;
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
            if (textDescription != null)
            { textDescription.text = "Test"; }
            if (actionButton != null)
            { actionButton.onClick.AddListener(OnActionButtonClick); }
            if (addButton != null)
            { addButton.onClick.AddListener(OnAddQuantityButtonClick); }
            if (removeButton != null)
            { removeButton.onClick.AddListener(OnRemoveQuantityButtonClick); }
        }
        public void SetParent(GameObject parent)
        {
            if (parent != null)
            {
                gameObject.transform.SetParent(parent.transform, false);
            }
        }

        public void SetController(ItemDescriptionController controller)
        {
            itemDescriptionController = controller;
        }

        public void SetItemData(ItemSO itemData)
        {
            this.itemData = itemData;
            if (textDescription != null)
            { textDescription.text = itemData.description; }
            if (textPrice != null)
            { textPrice.text = itemData.buyPrice.ToString(); }
            if (textQuantity != null)
            { textQuantity.text = itemData.quantity.ToString(); }
            if (itemImage != null)
            { itemImage.sprite = itemData.icon; }
            
            if (textWeight != null)
            { textWeight.text = $"Weight : {itemData.weight}"; }
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
            if (textQuantity != null)
            { textQuantity.text = quantity.ToString(); }
        }
    }
}