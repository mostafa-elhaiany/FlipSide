using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectsMovment : MonoBehaviour
{
    public float speed;
    public static bool incSpeed = false;
    public static bool decSpeed = false;

    void Update()
    {
        if(incSpeed)
        {
            speed += 15;
            incSpeed = false;
        }

        if (decSpeed)
        {
            //speed -= 5;
            decSpeed = false;
        }

        if(playerCollisions.gameOver)
        {
            speed = 0;
        }


        GameObject[] collectables = GameObject.FindGameObjectsWithTag("Collectable");
        foreach(GameObject collectable in collectables)
        {
            Vector3 move = new Vector3(0, 0, - speed * Time.deltaTime);
            collectable.transform.Translate(move);
        }

        GameObject[] hazards = GameObject.FindGameObjectsWithTag("Hazard");
        foreach (GameObject hazard in hazards)
        {
            Vector3 move = new Vector3(0, 0, -speed * Time.deltaTime);
            hazard.transform.Translate(move);
        }
    }

}
