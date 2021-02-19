using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaySelectable : MonoBehaviour
{

    public ItemsType Description;

    private Renderer look;
    private Material original;


    void Start()
    {
        look = GetComponent<Renderer>();
        original = look.material;
    }

    public void Highlight(Material highlightMaterial)
    {
        look.material = highlightMaterial;

    }

    public void Deselect()
    {
        look.material = original;
    }

}
