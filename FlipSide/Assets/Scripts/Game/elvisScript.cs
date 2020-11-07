using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elvisScript : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        
        
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        this.gameObject.transform.position = new Vector3(player.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        
    }
}
