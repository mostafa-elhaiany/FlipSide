using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    public GameObject prefab;
    public int start = 10;
    public int end = 50;

    void Update()
    {
        int x = 0;
        
        Vector3 pos = new Vector3(-x * 2, 0, Random.Range(-10.0f, 10.0f));
        Instantiate(prefab, pos, Quaternion.identity);

        pos = new Vector3(-x * 2, 0, Random.Range(-10.0f, 10.0f));
        Instantiate(prefab, pos, Quaternion.identity);


        pos = new Vector3(-x * 2, 0, Random.Range(-10.0f, 10.0f));
        Instantiate(prefab, pos, Quaternion.identity);
        
    }
}
