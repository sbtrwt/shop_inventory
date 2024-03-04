using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShopInventory.UI
{
    public class PlayerUIView : MonoBehaviour
    {
        private PlayerUIController playerUIController;

        private TMP_Text goldText;
        private Button miningButton;

        private void Awake()
        {
            goldText = transform.Find("CurrencyUI/TotalCurrency").GetComponent<TMP_Text>();
            miningButton = transform.Find("Mining").GetComponent<Button>();
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
