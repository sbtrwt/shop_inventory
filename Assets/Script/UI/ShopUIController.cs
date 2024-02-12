using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIController : MonoBehaviour
{
    [SerializeField] private Button buttonShop;
    [SerializeField] private Button buttonShopClose;
    [SerializeField] private GameObject gameShopUI;
    void Start()
    {
        if (buttonShop)
            buttonShop.onClick.AddListener(OnClickShopOpen);
        if (buttonShopClose)
            buttonShopClose.onClick.AddListener(OnClickShopClose);
    }

    private void OnClickShopOpen()
    {
     
        gameShopUI.SetActive(true);
    }
    private void OnClickShopClose()
    {
        gameShopUI.SetActive(false);
    }
}
