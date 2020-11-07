using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChange : MonoBehaviour
{
    public GameObject player;
    public GameObject spot;
    public static int usedMat;
    /*
     * 0:red
     * 1:green
     * 2:blue
    */

    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject.transform.GetChild(0).gameObject; ;
        spot = this.gameObject.transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerCollisions.gameOver)
        {
            switch (usedMat)
            {
                case 0:
                    player.GetComponent<MeshRenderer>().material.color = Color.red;
                    spot.GetComponent<Light>().color = Color.red;
                    break;
                case 1:
                    player.GetComponent<MeshRenderer>().material.color = Color.green;
                    spot.GetComponent<Light>().color = Color.green;
                    break;
                case 2:
                    player.GetComponent<MeshRenderer>().material.color = Color.blue;
                    spot.GetComponent<Light>().color = Color.blue;
                    break;
            }
        }
        
    }

    
}
