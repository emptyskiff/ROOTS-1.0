using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class InventoryObj : Interactable
{
    public UnityEvent OnInteract;



    private Renderer look;
    private Material original;
    public string objectName;

    void Start()
    {
        interactionType = InteractionType.Inventory;
        look = GetComponent<Renderer>();
        original = look.material;
        ObjectsDisplay = FindObjectOfType<UIObjectsDisplay>();
    }


    void AddToInventory()
    {
        player.GetComponent<InventorySyst>().data.SaveItem(gameObject); 
    }

    void ShowObject()
    {
        player.GetComponent<InventorySyst>().volume.gameObject.SetActive(true);
        FindObjectOfType<MouseLook>().enabled = false;
       // GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
        FindObjectOfType<PlayerMovement>().enabled = false;

        ObjectsDisplay.Display(gameObject);
    }


    //public override string GetDescription()
    //{
    //    return " ";
    //}

    public override void Interact()
    {
        ShowObject();
        AddToInventory();
        //Destroy(gameObject);

    }

    public override void Highlight(Material highlightMaterial)
    {
        if(look != null)
        look.material = highlightMaterial;

    }

    public override void Deselect()
    {
        if(look != null)
        look.material = original;
    }




}
