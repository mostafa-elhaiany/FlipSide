using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerCollisions : MonoBehaviour
{
    public Text scoreText;
    public Text healhText;
    public static int score=0;
    public static int health=3;
    private bool bottomPlatform;
    public static bool restart;
    public static bool gameOver=false;
    public float speedMult=1;

    public Animator anim;
    public Animator anim2;
    private int NextBigScore = 50;

    public static bool incHealth=false;
    public static bool incScore=false;

    private static float minGenTime = 0.5f;

    void Start()
    {
    }

    void Update()
    {
        if(restart)
        {
            score = 0;
            health = 3;
            NextBigScore = 50;
            speedMult = 1;
            bottomPlatform = true;
            HandleInput.restart = true;
            restart = false;
            gameOver = false;
        }

        if (incHealth)
        {
            health = Mathf.Min(3, health + 1);
            incHealth = false;
        }
        if (incScore)
        {
            score += 10;
            incScore = false;
            if (score >= NextBigScore)
            {
                objectsMovment.incSpeed = true;
                speedMult += 0.3f;

                Generator.generationTime = Mathf.Max(minGenTime, Generator.generationTime - 0.2f);
                NextBigScore += 50;
            }
        }


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
                    FindObjectOfType<AudioManager>().play("collect1");
                }
                else
                {
                    score -= 5;
                    FindObjectOfType<AudioManager>().play("incorrect");
                }
            }
            else
            {
                if (bottomPlatform)
                {
                    score -= 5;
                    FindObjectOfType<AudioManager>().play("incorrect");
                }
                else
                {
                    score += 10;
                    FindObjectOfType<AudioManager>().play("collect1");
                }
            }

           
            if(score >= NextBigScore)
            {
                objectsMovment.incSpeed = true;
                speedMult += 0.3f;
                
                Generator.generationTime = Mathf.Max(minGenTime, Generator.generationTime - 0.2f);
                NextBigScore += 50;
            }

        }
        if (collision.gameObject.CompareTag("Hazard"))
        {
            health--;
            FindObjectOfType<AudioManager>().play("incorrect");
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
        if(health<3)
        {
            health++;
            FindObjectOfType<AudioManager>().play("drink");
            GameObject.Destroy(other.gameObject);
        }
    }

}
