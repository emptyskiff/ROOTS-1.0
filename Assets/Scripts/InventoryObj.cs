using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        interactionImage.enabled = false;
        player.GetComponent<InventorySyst>().data.SaveItem(gameObject);
        audioPlayer.PlaySound(objectName, 0, lowVolume);
    }

    void ShowObject()
    {
        interactionImage.enabled = false;
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
        interactionImage.enabled = true;
        Debug.Log("Stopped showing");
        interactionImage.enabled = true;
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
            AddToInventory();
            OnInteract.Invoke(); //эвент
            Destroy(gameObject);
        }

    }

    public override void Highlight()
    {
        interactionImage.enabled = true;
        //if(look != null)
        //look.material = highlightMaterial;

    }

    public override void Deselect()
    {
        interactionImage.enabled = false;
        //if (look != null)
        //look.material = original;
    }




}
