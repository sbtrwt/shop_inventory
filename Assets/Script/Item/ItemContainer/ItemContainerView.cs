using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainerView : MonoBehaviour
{
    private ItemContainerController itemContainerController;


    public void SetParent(GameObject parent)
    {
        gameObject.transform.SetParent(parent.transform, false);
    }

    public void SetController(ItemContainerController controller)
    {
        itemContainerController = controller;
    }
}
