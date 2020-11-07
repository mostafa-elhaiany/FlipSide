﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectableScript : MonoBehaviour
{
    private Color color;
    private GameObject spot;
    void Start()
    {
        spot = this.gameObject.transform.GetChild(1).gameObject;
        int r = Random.Range(0,3);
        switch (r)
        {
            case 0: color = Color.red;
                break;
            case 1: color = Color.blue;
                break;
            case 3: 
            default: color = Color.green;
                break;
        }

        this.gameObject.GetComponent<MeshRenderer>().material.color = color;
        spot.GetComponent<Light>().color = color;
    }

    void Update()
    {
        
    }

}
