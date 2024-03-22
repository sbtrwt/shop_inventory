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
        if (model?.Parent)
            SetParent(model.Parent);

        this.eventService.OnItemSell.AddListener(OnActionSell);
        this.eventService.OnItemBuy.AddListener(OnActionBuy);
    }
    public void InitView()
    {
        messageUIView = Object.Instantiate(uiModel.UISO.MessageUIView);
        messageUIView.SetController(this);
    }

    public void SetParent(GameObject parent)
    {
        uiModel.Parent = parent;
        messageUIView.SetParent(parent);
    }
   


    public void OnActionSell(ItemSO item) { SetMessage($"{item.ActionQuantity} {item.ShortName} item sold"); }
    public void OnActionBuy(ItemSO item) { SetMessage($"{item.ActionQuantity} {item.ShortName} item bought"); }

    public void SetMessage(string message) 
    { 
        messageUIView.gameObject.SetActive(true);
        messageUIView.SetMessageText(message);
    }
}
