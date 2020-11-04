using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerCollisions : MonoBehaviour
{
    public GameObject player;
    public GameObject prefab;
    public Text text;
    private int score;
    void Start()
    {  
    }

    void Update()
    {
        if(player.transform.position.y<-2)
        {
            this.transform.DetachChildren();
            GameObject.Destroy(player);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            GameObject.Destroy(collision.gameObject);
            score++;
            player.GetComponent<AudioSource>().Play(0);

            //display score
            text.text = "Score: "+score;

            //Vector3 pos = new Vector3(
            //    Random.Range(player.transform.position.x - 1, player.transform.position.x - 10),
            //    0,
            //    Random.Range(- 10, 10));

            //Instantiate(prefab, pos, Quaternion.identity);


        }
        if (collision.gameObject.CompareTag("Hazard"))
        {
            player.transform.DetachChildren();
            GameObject.Destroy(player);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            Debug.Log("LEFT GROUND");
    }


    void OnTriggerEnter(Collider other)
    {
        
    }

    void OnTriggerExit(Collider other)
    {

    }


}
