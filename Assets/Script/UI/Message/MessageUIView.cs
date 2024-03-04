using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShopInventory.UI
{
    public class MessageUIView : MonoBehaviour
    {
        private MessageUIController messageUIController;

        private TMP_Text messageText;


        private void Awake()
        {
            messageText = transform.Find("MessageText").GetComponent<TMP_Text>();

        }
        public void SetController(MessageUIController controller)
        {
            messageUIController = controller;
        }
        public void SetParent(GameObject parent)
        {
            if (parent != null)
            {
                gameObject.transform.SetParent(parent.transform, false);
            }

        }
        public void SetMessageText(string message)
        {
            if (messageText != null)
            {
                messageText.text = message;
                StartCoroutine(ShowForSeconds(3));
            }
        }
        IEnumerator ShowForSeconds(float sec)
        {
            gameObject.SetActive(true);
            yield return new WaitForSeconds(sec);
            gameObject.SetActive(false);
        }
    }
}
