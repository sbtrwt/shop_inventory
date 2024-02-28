using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShopInventory.Item
{
    [CreateAssetMenu(fileName = "New Item Database", menuName = "Inventroy System/Items/Database")]
    public class ItemDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
    {
        public ItemObjectSO[] Items;
        public Dictionary<ItemObjectSO, int> GetId = new Dictionary<ItemObjectSO, int>();
        public void OnAfterDeserialize()
        {
            GetId = new Dictionary<ItemObjectSO, int>();
            for (int i = 0; i < Items.Length; i++)
            {
                GetId.Add(Items[i], i);
            }
        }

        public void OnBeforeSerialize()
        {
            throw new System.NotImplementedException();
        }


    }
}