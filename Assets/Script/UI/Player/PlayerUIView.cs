using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShopInventory.UI
{
    public class PlayerUIView : MonoBehaviour
    {
        private PlayerUIController playerUIController;

        private TMP_Text goldText;


        private void Awake()
        {
            goldText = transform.Find("CurrencyUI/TotalCurrency").GetComponent<TMP_Text>();

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
    }
}
