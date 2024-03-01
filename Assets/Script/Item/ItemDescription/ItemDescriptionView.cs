using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShopInventory.Item
{
    public class ItemDescriptionView : MonoBehaviour
    {
        private ItemDescriptionController itemDescriptionController;
        

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

    }
}