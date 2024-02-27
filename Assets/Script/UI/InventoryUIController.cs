using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIController : MonoBehaviour
{
    [SerializeField] private Button buttonInventory;
    [SerializeField] private Button buttonInventoryClose;
    [SerializeField] private GameObject gameInventoryUI;
    void Start()
    {
        if (buttonInventory)
            buttonInventory.onClick.AddListener(OnClickShopOpen);
        if (buttonInventoryClose)
            buttonInventoryClose.onClick.AddListener(OnClickShopClose);
    }

    private void OnClickShopOpen()
    {

        gameInventoryUI.SetActive(true);
    }
    private void OnClickShopClose()
    {
        gameInventoryUI.SetActive(false);
    }
}
