using ShopInventory.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShopInventory.UI
{
    public class UIService
    {
        private PlayerUIController playerUIController;
        private MessageUIController messageUIController;
        private UIModel uiModel;
        private EventService eventService;
        public UIService(UIModel uiModel)
        {
            this.uiModel = uiModel;
        }
        public void InjectDependencies(EventService eventService)
        {
            this.eventService = eventService;
            playerUIController = new PlayerUIController(uiModel, this.eventService);
            messageUIController = new MessageUIController(uiModel, this.eventService);
        }
        public void SetMessage(string message)
        {
            messageUIController.SetMessage(message);
        }
    }
}

