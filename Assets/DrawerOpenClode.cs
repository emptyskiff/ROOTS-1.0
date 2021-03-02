using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerOpenClose : Interactable
{
    private Animator drawerAnim;
    private bool drawerOpen = false;

    [Header("Animation Names")]
    [SerializeField] private string openAnimation = "DrawerOpen";
    [SerializeField] private string closeAnimation = "DrawerClose";

    [Header("Pause Timer")]
    [SerializeField] private int waitTimer = 1;
    [SerializeField] private bool pauseInteraction = false;


    void Start()
    {
        interactionType = InteractionType.Click;
    }

    private void Awake()
    {
        drawerAnim = gameObject.GetComponent<Animator>();
    }

    public override void Highlight(Material highlightMaterial) { }
    public override void Deselect() { }

    private IEnumerator PauseDrawerInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);
        pauseInteraction = false;
    }

    void OpenDrawer()
    {
        if (!drawerOpen && !pauseInteraction)
        {

            drawerAnim.Play(openAnimation);
            drawerOpen = true;
            StartCoroutine(PauseDrawerInteraction());
        }

        else
        {
            drawerAnim.Play(closeAnimation);
            drawerOpen = false;
            StartCoroutine(PauseDrawerInteraction());
        }
    }


    public override string GetDescription()
    {
        if (!drawerOpen) return "Open drawe";
        return "Close drawer";
    }

    public override void Interact()
    {
        OpenDrawer();

    }
}
