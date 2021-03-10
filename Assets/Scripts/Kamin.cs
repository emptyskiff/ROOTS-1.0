using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Kamin : Interactable
{
    public GameObject point;
    private int objectCount;
    public UnityEvent[] actions;

    void Start()
    {
        interactionType = InteractionType.Click;
    }

    public void GetObject()
    {
        player.GetComponent<InventorySyst>().data.GiveBack(point.transform.position, point.transform.rotation);
        objectCount++;
        
        if (objectCount == 3)
        {
            actions[0].Invoke();
        }

        //
    }
    
    //public override string GetDescription()
    //{
    //    return "Click to add to fireplace";
    //}

    public override void Interact()
    {
        GetObject();
    }

    public override void Highlight()
    {
        interactionImage.enabled = true;
        //  throw new System.NotImplementedException();
    }

    public override void Deselect()
    {
        interactionImage.enabled = false;
        //throw new System.NotImplementedException();
    }
}