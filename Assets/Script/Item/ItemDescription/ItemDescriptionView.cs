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

        private Image itemImage;
        private TMP_Text textDescription;
        private Button addButton;
        private Button removeButton;
        private Button actionButton;
        private TMP_Text textPrice;
        private TMP_Text textQuantity;
        private ItemSO itemData;
        private void Start()
        {
            itemImage = transform.Find("ItemImage").GetComponent<Image>();
            textDescription = transform.Find("ItemDesc").GetComponent<TMP_Text>();
            textPrice = transform.Find("Price/PriceText").GetComponent<TMP_Text>();
            textQuantity = transform.Find("QuantityPanel/QuantityText").GetComponent<TMP_Text>();
            actionButton = transform.Find("ActionButton").GetComponent<Button>();
            removeButton = transform.Find("QuantityPanel/DeleteQuantity").GetComponent<Button>();
            addButton = transform.Find("QuantityPanel/AddQuantity").GetComponent<Button>();

            if(textDescription != null)
            { textDescription.text = "Test"; }
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
        }
    }
}