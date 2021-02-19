using UnityEngine;
using System.Collections;

public class LightSwitch : MonoBehaviour
{

    public bool onSwitch;
    public bool lightStatus;
    public GameObject theLight;

    void OnTriggerEnter(Collider other)
    {
        onSwitch = true;
    }

    void OnTriggerExit(Collider other)
    {
        onSwitch = false;
    }

    void Update()
    {
        if (theLight.active == true)
        {
            lightStatus = true;
        }
        else
        {
            lightStatus = false;
        }

        if (onSwitch)
        {
            if (lightStatus)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    theLight.SetActive(false);
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    theLight.SetActive(true);
                }
            }
        }
    }

    //void OnGUI()
    //{
    //    if (onSwitch)
    //    {
    //        if (lightStatus)
    //        {
    //            GUI.Box(new Rect(0, 0, 200, 20), "Press E to close the light");

    //        }
    //        else
    //        {
    //            GUI.Box(new Rect(0, 0, 200, 20), "Press E to open the light");
    //        }
    //    }
    //}
}