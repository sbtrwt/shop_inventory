using ShopInventory.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShopInventory.Inventory
{
    public class Inventory
    {
        private List<ItemSO> items;
        // Start is called before the first frame update
        void Start()
        {
            items = new List<ItemSO> { new ItemSO { } };
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}