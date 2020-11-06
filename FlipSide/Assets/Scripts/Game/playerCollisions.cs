using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerCollisions : MonoBehaviour
{
    public Text scoreText;
    public Text healhText;
    private int score;
    private int health;
    private bool bottomPlatform;
    public static bool gameOver=false;
    public float speedMult=1;

    public Animator anim;


    void Start()
    {
        score = 0;
        health=3;
    }

    void Update()
    {
        bottomPlatform = !anim.GetBool("jump");


        if(this.gameObject.transform.position.y< 1.04f)
        {
            this.gameObject.transform.position = new Vector3(0, 1.04f, -42.8f);
            //this.transform.DetachChildren();
            //GameObject.Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            GameObject.Destroy(collision.gameObject);
            if (collision.gameObject.GetComponent<MeshRenderer>().material.color == this.gameObject.GetComponent<MeshRenderer>().material.color)
            {
                if(bottomPlatform)
                {
                    score += 10;

                    //player.GetComponent<AudioSource>().Play(0);
                }
                else
                {
                    score -= 5;
                    objectsMovment.decSpeed = true;
                    //player.GetComponent<AudioSource>().Play(0);
                }
            }
            else
            {
                if (bottomPlatform)
                {
                    score -= 5;
                    objectsMovment.decSpeed = true;
                    //player.GetComponent<AudioSource>().Play(0);
                }
                else
                {
                    score += 10;
                    //player.GetComponent<AudioSource>().Play(0);
                }
            }

            //display text
            scoreText.text = "Score: "+score;

            //Vector3 pos = new Vector3(
            //    Random.Range(player.transform.position.x - 1, player.transform.position.x - 10),
            //    0,
            //    Random.Range(- 10, 10));

            //Instantiate(prefab, pos, Quaternion.identity);
            if(score%50==0)
            {
                objectsMovment.incSpeed = true;
                speedMult += 0.3f;
                anim.SetFloat("speedMult", speedMult);
                Generator.generationTime = Mathf.Max(3, Generator.generationTime - 0.2f);
            }

        }
        if (collision.gameObject.CompareTag("Hazard"))
        {
            health--;
            //display text
            healhText.text = "Health: " + health;

            if (health<0)
            {
                this.gameObject.transform.DetachChildren();
                GameObject.Destroy(this.gameObject);
                GameObject.Destroy(collision.gameObject);
                anim.SetBool("isDead",true);

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
