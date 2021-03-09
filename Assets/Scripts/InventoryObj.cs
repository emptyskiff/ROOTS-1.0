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
    private bool isObjectInspecting = false;
    public AudioPlayer audioPlayer;
    public float lowVolume;
    public float fullVolume;

    void Start()
    {
        interactionType = InteractionType.Inventory;
        look = GetComponent<Renderer>();
        original = look.material;
        ObjectsDisplay = FindObjectOfType<UIObjectsDisplay>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }


    void AddToInventory()
    {
            Debug.Log("Added to inventory");
            player.GetComponent<InventorySyst>().data.SaveItem(gameObject);
            audioPlayer.PlaySound(objectName, 0, lowVolume);
    }

    void ShowObject()
    {
        player.GetComponent<InventorySyst>().volume.gameObject.SetActive(true);
        FindObjectOfType<MouseLook>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
        FindObjectOfType<PlayerMovement>().enabled = false;
        isObjectInspecting = true;

        audioPlayer.PlaySound(objectName, 0, fullVolume);

        ObjectsDisplay.Display(gameObject);
    }

    public void StopShowing()
    {
       
        audioPlayer.StopSound(objectName);
        isObjectInspecting = false;
    }


    public override void Interact()
    {
        if(isObjectInspecting == false)
        {
            ShowObject();
        }

    }

    public override void AlternateInteract()
    {
        if (isObjectInspecting == false)
        {
            //Debug.Log("AlternateInteract works");
            AddToInventory();
            OnInteract.Invoke(); //эвент
            Destroy(gameObject);
        }

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
