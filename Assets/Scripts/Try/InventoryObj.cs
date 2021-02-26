using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObj : Interactable
{
    private Renderer look;
    private Material original;
    public string objectName;

    void Start()
    {
        interactionType = InteractionType.Inventory;
        look = GetComponent<Renderer>();
        original = look.material;
    }


    void AddToInventory()
    {
        player.GetComponent<InventorySyst>().data.SaveItem(gameObject); 
        Destroy(gameObject);
    }


    public override string GetDescription()
    {
        return "Click to add to inventory";
    }

    public override void Interact()
    {
        AddToInventory();

    }

    public override void Highlight(Material highlightMaterial)
    {
        look.material = highlightMaterial;

    }

    public override void Deselect()
    {
        look.material = original;
    }

}
