using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObj : Interactable
{
    

    void Start()
    {
        interactionType = InteractionType.Inventory;
    }


    void AddToInventory()
    {
        player.GetComponent<InventorySyst>().data.SaveItem(gameObject);
        Destroy(gameObject);
    }


    public override string GetDescription()
    {
        return "Click to ADD to Inventory";
    }

    public override void Interact()
    {
        AddToInventory();

    }
}
