using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    protected Vector3 posLastFrame;
    public Camera UICam;
    public string Name;
    private bool onStart;
    private UIObjectsDisplay uIObjectsDisplay;



    private void Start()
    {
       
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        uIObjectsDisplay = GetComponentInParent<UIObjectsDisplay>();
        Cursor.visible = false;


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (onStart == false)
            {
                posLastFrame = Input.mousePosition;
                onStart = true;
            }
            else
            {
                gameObject.SetActive(false);
            }

        }

        //if (Input.GetMouseButton(0))
       // {
            var delta = Input.mousePosition - posLastFrame;
            posLastFrame = Input.mousePosition;

            var axis = Quaternion.AngleAxis(-90f, Vector3.forward) * delta;
            transform.RotateAround(transform.position, transform.up, delta.magnitude * 0.001f * axis.y);


        //}


    }


    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        uIObjectsDisplay.QuitDisplayMode();
    }
}
