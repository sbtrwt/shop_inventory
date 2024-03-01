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
        [SerializeField] private TextMeshPro quantityText;
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
            itemImage.sprite = image;
        }
        public void OnClickItem()
        {
            ItemSO itemData = itemController.GetItemData();
            Debug.Log("item click ID:" + itemData.ID);
        }
    }

}