using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShopInventory.UI
{
    public class PlayerUIView : MonoBehaviour
    {
        private PlayerUIController playerUIController;

        [SerializeField]private TMP_Text goldText;
        [SerializeField] private Button miningButton;

        private void Awake()
        {
            if(miningButton != null)
            {
                miningButton.onClick.AddListener(OnClickingMining);
            }
        }
        public void SetController(PlayerUIController controller)
        {
            playerUIController = controller;
        }
        public void SetParent(GameObject parent)
        {
            if (parent != null)
            {
                gameObject.transform.SetParent(parent.transform, false);
            }

        }
        public void SetGoldText(int gold)
        {
            if(goldText != null)
            {
                goldText.text = gold.ToString();
            }
        }
        public void OnClickingMining()
        {
            playerUIController.Mining();
        }
    }
}
