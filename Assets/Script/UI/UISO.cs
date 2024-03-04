using UnityEngine;

namespace ShopInventory.UI
{
    [CreateAssetMenu(fileName = "New UI", menuName = "UI")]
    public class UISO : ScriptableObject
    {
        public int ID;
        public PlayerUIView playerUIView;
        public MessageUIView messageUIView;
    }
}
