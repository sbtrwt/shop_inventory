using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShopInventory.Item
{
    public class ItemView : MonoBehaviour
    {
        private ItemController itemController;
        [SerializeField] private Image itemImage;
        [SerializeField] private TMP_Text quantityText;
        private Button itemButton;
        
        private void Awake()
        {
            quantityText = transform.Find("Quantity").GetComponent<TextMeshPro>();
            itemButton = transform.Find("Button").GetComponent<Button>();
            if (itemButton != null)
            {

                itemImage = itemButton.GetComponent<Image>();
                itemButton.onClick.AddListener(OnClickItem);
            }

        }
        public void SetController(ItemController controller)
        {
            itemController = controller;
        }
        public void SetParent(GameObject parent)
        {

            if (parent != null)
            {
                gameObject.transform.SetParent(parent.transform, false);
            }

        }
        public void SetSprite(Sprite image)
        {
            if(itemImage != null)
            itemImage.sprite = image;
        }
        public void SetQuantity( float quantity)
        {
           if(quantityText != null)
            {
                quantityText.text = quantity.ToString();
            }
        }
        public void OnClickItem()
        {
            ItemSO itemData = itemController.GetItemData();
            itemController.OnItemClick(itemData);
            Debug.Log("item click ID:" + itemData.ID);
        }
        public void SetItemView(ItemSO item)
        {
            SetSprite(item.icon);
            SetQuantity(item.quantity);
        }
    }

}