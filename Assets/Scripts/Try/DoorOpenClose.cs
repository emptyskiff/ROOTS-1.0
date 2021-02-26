using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    void Start()
    {
        interactionType = InteractionType.Click;
    }

    private void Awake()
    {
        doorAnim = gameObject.GetComponent<Animator>();
    }

    public override void Highlight(Material highlightMaterial) { }
    public override void Deselect() { }

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
            doorAnim.Play(closeAnimation);
            doorOpen = false;
            StartCoroutine(PauseDoorInteraction());
        }
    }


    public override string GetDescription()
    {
        if (!doorOpen) return "Press to open the door";
        return "Press to close the door";
    }

    public override void Interact()
    {
        OpenDoor();

    }
}
