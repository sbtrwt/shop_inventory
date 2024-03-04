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
            if (model?.parent)
                SetParent(model.parent);

            this.eventService.OnGoldChange.AddListener(SetGoldText);
        }
        public void InitView()
        {
            playerUIView = Object.Instantiate(uiModel.uiSO.playerUIView);
            playerUIView.SetController(this);
        }

        public void SetParent(GameObject parent)
        {
            uiModel.parent = parent;
            playerUIView.SetParent(parent);
        }
        public void SetGoldText(int gold)
        {
            playerUIView.SetGoldText(gold);
        }
    }
}