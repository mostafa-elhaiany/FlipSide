using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChange : MonoBehaviour
{
    public GameObject player;

    public static int usedMat;
    /*
     * 0:red
     * 1:green
     * 2:blue
    */

    // Start is called before the first frame update
    void Start()
    {
        
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
                    break;
                case 1:
                    player.GetComponent<MeshRenderer>().material.color = Color.green;
                    break;
                case 2:
                    player.GetComponent<MeshRenderer>().material.color = Color.blue;
                    break;
            }
        }
        
    }

    
}
