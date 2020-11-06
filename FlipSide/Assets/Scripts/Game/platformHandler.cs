using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            Debug.Log("Do something special here!");
        }
        else
        {
            Debug.Log("PC");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
