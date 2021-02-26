using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamin : Interactable
{
    public GameObject point;

    void Start()
    {
        interactionType = InteractionType.Click;
    }

    public void GetObject()
    {
        player.GetComponent<InventorySyst>().data.GiveBack(point.transform.position, point.transform.rotation);
    }
    
    public override string GetDescription()
    {
        return "Click to add to fireplace";
    }

    public override void Interact()
    {
        GetObject();
    }

    public override void Highlight(Material m)
    {
      //  throw new System.NotImplementedException();
    }

    public override void Deselect()
    {
        //throw new System.NotImplementedException();
    }
}