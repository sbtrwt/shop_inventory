using UnityEngine;
using UnityEngine.UI;

namespace ShopInventory.Inventory
{
   public class InventoryView : MonoBehaviour
    {
        private InventoryController inventoryController;
        private Button toggleButton;
        private GameObject parent;


        public void SetController(InventoryController inventoryController)
        {
            this.inventoryController = inventoryController;
        }


        public void SetParent(GameObject parent)
        {

            if (parent != null)
            {
                this.parent = parent;
                gameObject.transform.SetParent(parent?.transform, false);
            }

        }

        public void SetInventoryButton(Button _shopButton)
        {
            toggleButton = GameObject.Instantiate(_shopButton);
            if (parent != null)
                toggleButton.transform.SetParent(parent.transform, false);
            toggleButton.onClick.AddListener(OnToggleInventory);
        }
        public void OnToggleInventory()
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}
