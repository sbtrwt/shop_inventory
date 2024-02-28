using ShopInventory.Global;
using ShopInventory.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShopInventory.Game
{
    public class GameController : MonoBehaviour
    {
        private ServiceLocator serviceLocator;
        [SerializeField]private ServiceLocatorData serviceLocatorData;
        private void Start()
        {
            serviceLocator = new ServiceLocator(serviceLocatorData);
        }
    }
}


