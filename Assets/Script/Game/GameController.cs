using ShopInventory.Global;
using ShopInventory.Shop;
using ShopInventory.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShopInventory.Game
{
    public class GameController : MonoBehaviour
    {
        private ServiceLocator serviceLocator;
        
        [SerializeField]private ServiceLocatorModel serviceLocatorData;
     
        private void Start()
        {
            serviceLocator = new ServiceLocator(serviceLocatorData);
            serviceLocator.Start();
        }
        private void Update()
        {
            //serviceLocator.Update();
        }
    }
}


