using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public UIObjectsDisplay ObjectsDisplay;
    public enum InteractionType
    {
        Click,
        Hold,
        Inventory
    }

    public InteractionType interactionType;
    //public abstract string GetDescription();
    public abstract void Interact();
    public abstract void Highlight(Material m);
    public abstract void Deselect();
    public GameObject player;
    }

