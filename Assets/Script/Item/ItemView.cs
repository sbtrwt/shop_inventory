using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShopInventory.Item
{
    public class ItemView : MonoBehaviour
    {
        private ItemController itemController;
    // Start is called before the first frame update
    void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

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
    }

}