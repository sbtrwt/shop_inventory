using ShopInventory.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ShopInventory.UI
{
    public class PlayerUIController 
    {
        private PlayerUIView playerUIView;
        private UIModel uiModel;
        private EventService eventService;
        public PlayerUIController(UIModel model, EventService eventService)
        {
            this.eventService = eventService;
            uiModel = model;
            InitView();
            if (model?.Parent)
                SetParent(model.Parent);

            this.eventService.OnGoldChange.AddListener(SetGoldText);
        }
        public void InitView()
        {
            playerUIView = Object.Instantiate(uiModel.UISO.PlayerUIView);
            playerUIView.SetController(this);
        }

        public void SetParent(GameObject parent)
        {
            uiModel.Parent = parent;
            playerUIView.SetParent(parent);
        }
        public void SetGoldText(int gold)
        {
            playerUIView.SetGoldText(gold);
        }
        public void Mining() 
        {
            eventService.OnMining.InvokeEvent();
        }
    }
}