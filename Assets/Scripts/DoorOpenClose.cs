using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorOpenClose : Interactable
{
    private Animator doorAnim;
    private bool doorOpen = false;

    [Header("Animation Names")]
    [SerializeField] private string openAnimation = "DoorOpen";
    [SerializeField] private string closeAnimation = "DoorClose";

    [Header("Pause Timer")]
    [SerializeField] private int waitTimer = 1;
    [SerializeField] private bool pauseInteraction = false;


    public Image openDoor;
    public Image closeDoor;

    void Start()
    {
        interactionType = InteractionType.Click;
    }

    private void Awake()
    {
        doorAnim = gameObject.GetComponent<Animator>();
    }

    public override void Highlight()
    {
        Debug.Log("highlight");
        if (doorOpen)
        {
            Debug.Log("highlight open door");
            closeDoor.enabled = true;
        }
        else
        {
            Debug.Log("highlight closed door");
            openDoor.enabled = true;
        }
    }

    public override void Deselect() 
    {
        Debug.Log("deselect");
        closeDoor.enabled = false;
        if (!doorOpen)
        {
            Debug.Log("deselect open door");
            openDoor.enabled = false;
        }

        else
        {
            Debug.Log("deselect closed door");
            openDoor.enabled = false;
        }
    }

    private IEnumerator PauseDoorInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);
        pauseInteraction = false;
    }

    void OpenDoor()
    {
        if (!doorOpen && !pauseInteraction)
        {  
            doorAnim.Play(openAnimation);
            doorOpen = true;
            StartCoroutine(PauseDoorInteraction());
        }

        else
        {
            //
            //closeDoor.enabled = true;
            //
            doorAnim.Play(closeAnimation);
            doorOpen = false;
            StartCoroutine(PauseDoorInteraction());
        }
    }


    //public override string GetDescription()
    //{
    //    if (!doorOpen) return "Press to open the door";
    //    return "Press to close the door";
    //}

    public override void Interact()
    {
        OpenDoor();

    }
}
