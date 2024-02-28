using ShopInventory.Player;
using ShopInventory.Service;
using ShopInventory.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShopInventory.Global
{
    public class ServiceLocator 
    {
        private EventService eventService;
        private PlayerService playerService;

        [SerializeField] private UIService uiService;


        public ServiceLocator(ServiceLocatorData data)
        {
            InitializeServices(data);
            InjectDependencies();
        }

        private void InitializeServices(ServiceLocatorData data)
        {
            eventService = new EventService();
        }

        private void InjectDependencies()
        {
        }
        public void Update()
        {
            
        }
    }

}
