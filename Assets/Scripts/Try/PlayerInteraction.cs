﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance;
    //public TMPro.TextMeshProUGUI interactionText;
    public Material highlightMaterial;
    public Camera camera;

    private GameObject player;

    private Interactable current_inreractable, previous_interactable;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;

        bool successfullHit = false;
        bool onHit = Physics.Raycast(ray, out hit, interactionDistance);

        if (onHit)
        {
            if (hit.collider.TryGetComponent(out Interactable interactable))
            {

                previous_interactable = current_inreractable;
                current_inreractable = interactable;

                HandleInteraction(interactable, player);
                //interactionText.text = interactable.GetDescription();

                if (interactable.interactionType == Interactable.InteractionType.Inventory)
                {
                    interactable.Highlight(highlightMaterial);
                }
                successfullHit = true;

            }
        }

        else if (current_inreractable != null)
        {
            current_inreractable.Deselect();
            current_inreractable = null;
        }

        if (onHit && previous_interactable != null && previous_interactable != current_inreractable)
        {
            previous_interactable.Deselect();
            previous_interactable = null;

            //if (!successfullHit) interactionText.text = " ";
        }
    }


    void HandleInteraction(Interactable interactable, GameObject player)
    {   Input.GetMouseButtonDown(0);
        switch (interactable.interactionType)
        {
            case Interactable.InteractionType.Click:
                if (Input.GetMouseButtonDown(0))
                {
                    interactable.player = player;
                    interactable.Interact();
                }
                break;

            case Interactable.InteractionType.Hold:
                if(Input.GetMouseButtonDown(0))
                {
                    interactable.player = player;
                    interactable.Interact();
                }
                break;

            case Interactable.InteractionType.Inventory:
                if(Input.GetMouseButtonDown(0))
                {
                    interactable.player = player;
                    interactable.Interact();
                }
                break;


            default:
                throw new System.Exception("Unsupported type of interactable");
        }
    }

}
