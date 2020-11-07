using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerCollisions : MonoBehaviour
{
    public Text scoreText;
    public Text healhText;
    private static int score;
    private static int health;
    private bool bottomPlatform;
    public static bool gameOver=false;
    public float speedMult=1;

    public Animator anim;
    public Animator anim2;
    private int NextBigScore = 50;



    void Start()
    {
        score = 0;
        health=3;
    }

    void Update()
    {
        bottomPlatform = HandleInput.bottom;


        if(this.gameObject.transform.position.y< 1.04f)
        {
            this.gameObject.transform.position = new Vector3(0, 1.04f, -42.8f);
            //this.transform.DetachChildren();
            //GameObject.Destroy(this.gameObject);
        }

        //display text
        scoreText.text = "Score: " + score;
        healhText.text = "Health: " + health;


    }

    void OnCollisionEnter(Collision collision)
    {
        Color mat = Color.red;
        switch (MaterialChange.usedMat)
        {
            case 0:
                mat = Color.red;
                break;
            case 1:
                mat = Color.green;
                break;
            case 2:
                mat = Color.blue;
                break;
        }

        if (collision.gameObject.CompareTag("Collectable"))
        {
            GameObject.Destroy(collision.gameObject);
            if (collision.gameObject.GetComponent<MeshRenderer>().material.color == mat)
            {
                if(bottomPlatform)
                {
                    score += 10;
                    //player.GetComponent<AudioSource>().Play(0);
                }
                else
                {
                    score -= 5;
                    //player.GetComponent<AudioSource>().Play(0);
                }
            }
            else
            {
                if (bottomPlatform)
                {
                    score -= 5;
                    //player.GetComponent<AudioSource>().Play(0);
                }
                else
                {
                    score += 10;
                    //player.GetComponent<AudioSource>().Play(0);
                }
            }

           
            if(score >= NextBigScore)
            {
                objectsMovment.incSpeed = true;
                speedMult += 0.3f;
                
                Generator.generationTime = Mathf.Max(2, Generator.generationTime - 0.2f);
                NextBigScore += 50;
            }

        }
        if (collision.gameObject.CompareTag("Hazard"))
        {
            health--;

            if (health<0)
            {
                this.gameObject.transform.DetachChildren();
                GameObject.Destroy(this.gameObject);
                GameObject.Destroy(collision.gameObject);
                
                //TODO display you lost screen
                gameOver = true;
            }
            else
            {
                GameObject.Destroy(collision.gameObject);
                objectsMovment.decSpeed = true;
            }



        }
    }




    void OnTriggerEnter(Collider other)
    {
        
    }

    void OnTriggerExit(Collider other)
    {

    }


}
