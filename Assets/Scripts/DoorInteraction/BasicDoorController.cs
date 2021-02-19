using UnityEngine;
using System.Collections;

public class BasicDoorController : MonoBehaviour
{
    private Animator doorAnim;
    private bool doorOpen = false;

    [Header("Animation Names")]
    [SerializeField] private string openAnimation = "DoorOpen";
    [SerializeField] private string closeAnimation = "DoorClose"; 

    [Header("Pause Timer")]
    [SerializeField] private int waitTimer = 1;
    [SerializeField] private bool pauseInteraction = false;

    private void Awake()
    {
        doorAnim = gameObject.GetComponent<Animator>();
    }

    private IEnumerator PauseDoorInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);
        pauseInteraction = false;

    }

    public void PlayAnimation()
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
}
