﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
    
{
    public float time;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Vector3.up, time * Time.deltaTime);
    }
}
