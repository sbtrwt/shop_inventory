
using UnityEngine;

namespace ShopInventory.Shop
{
    [CreateAssetMenu(fileName = "New Shop", menuName = "Shop")]
    public class ShopSO: ScriptableObject
    {
        public int ID;
        public ShopView ShopPrefab;

    }
}
