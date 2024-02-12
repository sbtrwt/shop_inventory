using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button buttonShop;
    [SerializeField] private GameObject gameShopUI;
    void Start()
    {
        if (buttonShop)
            buttonShop.onClick.AddListener(OnClickStart);
    }

    private void OnClickStart()
    {
        Time.timeScale = 1;
        gameShopUI.SetActive(true);
    }
}