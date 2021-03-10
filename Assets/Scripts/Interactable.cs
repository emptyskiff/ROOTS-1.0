using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public virtual void AlternateInteract() {}
    public abstract void Highlight();
    public abstract void Deselect();
    public GameObject player;

    public Image interactionImage;

    }

