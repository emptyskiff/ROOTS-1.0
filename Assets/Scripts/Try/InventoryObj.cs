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
    }

    void ShowObject()
    {
        player.GetComponent<InventorySyst>().volume.gameObject.SetActive(true);
        GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
        GameObject.Find("First Person Player").GetComponent<PlayerMovement>().enabled = false;
    }


    //public override string GetDescription()
    //{
    //    return " ";
    //}

    public override void Interact()
    {
        ShowObject();
        AddToInventory();
        Destroy(gameObject);

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
