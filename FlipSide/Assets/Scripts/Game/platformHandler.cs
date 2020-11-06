using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformHandler : MonoBehaviour
{
    public GameObject[] androidElements;


    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            Debug.Log("Android");
            foreach (GameObject element in androidElements)
            {
                element.SetActive(true);
            }
        }
        else
        {
            Debug.Log("PC");
            foreach (GameObject element in androidElements)
            {
                element.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
