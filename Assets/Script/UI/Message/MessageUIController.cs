using ShopInventory.Event;
using ShopInventory.Item;
using ShopInventory.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageUIController 
{
    private MessageUIView messageUIView;
    private UIModel uiModel;
    private EventService eventService;
    public MessageUIController(UIModel model, EventService eventService)
    {
        this.eventService = eventService;
        uiModel = model;
        InitView();
        if (model?.parent)
            SetParent(model.parent);

        this.eventService.OnItemSell.AddListener(OnActionSell);
        this.eventService.OnItemBuy.AddListener(OnActionBuy);
    }
    public void InitView()
    {
        messageUIView = Object.Instantiate(uiModel.uiSO.messageUIView);
        messageUIView.SetController(this);
    }

    public void SetParent(GameObject parent)
    {
        uiModel.parent = parent;
        messageUIView.SetParent(parent);
    }
   


    public void OnActionSell(ItemSO item) { SetMessage($"{item.actionQuantity} item sold"); }
    public void OnActionBuy(ItemSO item) { SetMessage($"{item.actionQuantity} item bought"); }

    public void SetMessage(string message) 
    { 
        messageUIView.gameObject.SetActive(true);
        messageUIView.SetMessageText(message);
    }
}
