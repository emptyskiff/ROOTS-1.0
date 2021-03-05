using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Interactable
{
    public Light m_Light;
    public bool isOn;


    void Start()
    {
        UpdateLight();
    }

    
    void UpdateLight()
    {
        m_Light.enabled = isOn;
    }


    //public override string GetDescription()
    //{
    //    if (isOn) return "Press to turn <color=red> off </color> the light";
    //    return "Press to turn <color=green> on </color> the light";
    //}

    public override void Interact()
    {
        isOn = !isOn;
        UpdateLight();

    }

    public override void Highlight(Material m)
    {
        //throw new System.NotImplementedException();
    }

    public override void Deselect()
    {
       // throw new System.NotImplementedException();
    }
}
