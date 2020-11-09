using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviour : MonoBehaviour
{
    public GameObject player;
    private float time = 0.0f;
    public float speed = 15.0f;
    public float interpolationPeriod = 15;
    
    void Start()
    {
        
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (!playerCollisions.gameOver)
        {
            if (PauseMenu.isPaused)
                return;

            materialChange();
            movement();
        }
    }

    private void movement()
    {
        Vector3 move;
        if (Application.platform == RuntimePlatform.Android)
        {
            move = new Vector3(3 * Input.acceleration.x * speed * Time.deltaTime, 0, 0);
        }
        else
        {
            move = new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0, 0);
        }
        player.transform.Translate(move);
        //player.GetComponent<Rigidbody>().AddForce(move*200);
        if(player.transform.position.x<= -3.6f)
        {
            player.transform.position = new Vector3(-3.6f, player.transform.position.y, player.transform.position.z);
        }
        if(player.transform.position.x >= 3.6f)
        {
            player.transform.position = new Vector3(3.6f, player.transform.position.y, player.transform.position.z);
        }
    }

    private void materialChange()
    {
        time += Time.deltaTime;

        if (time >= interpolationPeriod)
        {
            time = 0.0f;

            MaterialChange.usedMat = UnityEngine.Random.Range(0, 3); ///(MaterialChange.usedMat + 1) % 3;
            FindObjectOfType<AudioManager>().play("colorChange");

        }
    }
}
