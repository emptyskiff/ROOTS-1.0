using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIObjectsDisplay : MonoBehaviour
{
    private Turn [] itemsToShow;
    private Dictionary<string, GameObject> items = new Dictionary<string, GameObject>();
    [SerializeField] private GameObject UIPostProcessing;
    private MouseLook mouseLook;
    private PlayerMovement playerMovement;
    private GameObject currentObject;

   
    private void Start()
    {
        mouseLook = FindObjectOfType<MouseLook>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        itemsToShow = GetComponentsInChildren<Turn>();
        foreach(var item in itemsToShow)
        {
            items.Add(item.Name, item.gameObject);
            item.gameObject.SetActive(false);
        }
    }
    
    public void Display(GameObject inspectableObject)
    {
        currentObject = inspectableObject;
        string name = currentObject.GetComponent<InventoryObj>().objectName;

        if (items.ContainsKey(name))
        {
            items[name].SetActive(true);
        }

    }

    public void QuitDisplayMode()
    {

        UIPostProcessing.SetActive(false);
        mouseLook.enabled = true;
        playerMovement.enabled = true;
        if (currentObject != null)
        {
            currentObject.GetComponent<InventoryObj>().StopShowing();
            Debug.Log("Stopped showing");
            string name = currentObject.GetComponent<InventoryObj>().objectName;
            if (items.ContainsKey(name))
            {
                items[name].SetActive(false);
            Debug.Log("Item non-active");
            }


        }

        

    }

}
