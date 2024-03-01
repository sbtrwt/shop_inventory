using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainerView : MonoBehaviour
{
    private ItemContainerController itemContainerController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetParent(GameObject parent)
    {
        if(parent != null)
        {
            gameObject.transform.SetParent(parent.transform,false);
        }
    }

    public void SetController(ItemContainerController controller)
    {
        itemContainerController = controller;
    }
}