using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviour : MonoBehaviour
{
    public GameObject player;
    private float time = 0.0f;
    public float speed = 15.0f;
    public float interpolationPeriod = 3;

    void Update()
    {
        if (!playerCollisions.gameOver)
        {
            materialChange();
            movement();
        }
    }

    private void movement()
    {
        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0, 0);
        player.transform.Translate(move);
    }

    private void materialChange()
    {
        time += Time.deltaTime;

        if (time >= interpolationPeriod)
        {
            time = 0.0f;
            
            MaterialChange.usedMat = (MaterialChange.usedMat + 1) % 3;
        }
    }
}
