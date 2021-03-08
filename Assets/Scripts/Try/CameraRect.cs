using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRect : MonoBehaviour
{
    private Camera cam;
    float startX = 0;
    float desiredX;
    float startWidth = 1;
    float desiredWidth;
    public float alpha = 0;

    public bool changeAspect;

    AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        desiredWidth = 1 / cam.aspect;
        desiredX = (1 - desiredWidth) / 2;
        changeAspect = false;

        //
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (changeAspect)
        {
            float x = Mathf.Lerp(startX, desiredX, alpha);
            float width = Mathf.Lerp(startWidth, desiredWidth, alpha);
            cam.rect = new Rect(x, 0, width, 1);
        }
    }

    public void ChangeAspect()
    {
        changeAspect = true;
        GetComponentInChildren<Animator>().Play("RectChange");

        //
        source.Play();

    }
}
