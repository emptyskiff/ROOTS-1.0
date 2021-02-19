using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance;
    public TMPro.TextMeshProUGUI interactionText;
    public Camera camera;
    
    //void Start()
    //{
    //    camera = GetComponent<Camera>();
    //}

    
    void Update()
    {
        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;

        bool successfullHit = false;

        if (Physics.Raycast(ray, out hit, interactionDistance)) { 
            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if (interactable !=null)
            {
                HandleInteraction(interactable);
                interactionText.text = interactable.GetDescription();
                successfullHit = true;
            }
        }

        if (!successfullHit) interactionText.text = "";
    }


    void HandleInteraction(Interactable interactable)
    {   Input.GetMouseButtonDown(0);
        switch (interactable.interactionType)
        {
            case Interactable.InteractionType.Click:
                if (Input.GetMouseButtonDown(0))
                {
                    interactable.Interact();
                }
                break;

            case Interactable.InteractionType.Hold:
                if(Input.GetMouseButtonDown(0))
                {
                    interactable.Interact();
                }
                break;

            case Interactable.InteractionType.Inventory:
                if(Input.GetMouseButtonDown(0))
                {
                    interactable.Interact();
                }
                break;


            default:
                throw new System.Exception("Unsupported type of interactable");
        }
    }

}
