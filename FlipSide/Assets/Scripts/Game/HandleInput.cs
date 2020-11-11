﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleInput : MonoBehaviour
{
    public GameObject[] Cameras;
    public int activeCam = 0;

    public bool bottomPlat = true;
    public static bool bottom = true;

    public static bool switchPlatform = false;
    public static bool switchCamera = false;
    public static bool restart = false;

    public GameObject elvisTop;
    public GameObject elvisBottom;

    private bool isJumping = false;

    
    void Start()
    {
        Cameras[0].SetActive(true);
        //elvisTop = GameObject.FindGameObjectWithTag("ElvisTop");
        //elvisBottom = GameObject.FindGameObjectWithTag("ElvisBottom");
        //elvisBottom.SetActive(false);

    }


    void Update()
    {
        if(restart)
        {
            bottomPlat = true;  
            elvisTop.SetActive(false);
            elvisBottom.SetActive(true);
            restart = false;
        }

        if (playerCollisions.gameOver)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Pause");
            PauseMenu.isPaused = !PauseMenu.isPaused;
        }

        if (PauseMenu.isPaused)
            return;


        if (Input.GetKeyUp(KeyCode.Space) || switchPlatform)
        {
            if(!isJumping)
            {
                //isJumping = true;
                flipPlatform();
                switchPlatform = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.C) || switchCamera)
        {
            toggleCamera();
        }

        if(Input.GetKeyUp(KeyCode.M))
        {
            Options.mute = !Options.mute;
        }

        if(Input.GetKeyDown(KeyCode.B))
        {
            playerCollisions.gameOver = true;
        }

        if (Input.GetKeyDown(KeyCode.R)) //change colors
        {
            Behaviour.matChange();
        }

        if (Input.GetKeyDown(KeyCode.E)) //increase health
        {
            playerCollisions.incHealth = true;
        }

        if (Input.GetKeyDown(KeyCode.Q)) //increase score
        {
            playerCollisions.incScore = true;
        }


    }

    void toggleCamera()
    {
        Cameras[activeCam].SetActive(false);
        activeCam = (activeCam + 1) % 2;
        Cameras[activeCam].SetActive(true);
        switchCamera = false;
    }

    void flipPlatform()
    {
        bottomPlat = !bottomPlat;
        bottom = bottomPlat;
        elvisTop.SetActive(!bottomPlat);
        elvisBottom.SetActive(bottomPlat);
        FindObjectOfType<AudioManager>().play("modeChange");
    }
    

}
