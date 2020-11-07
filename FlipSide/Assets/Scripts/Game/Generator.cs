using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject CapsulePrefab;
    public GameObject HazardPrefab;

    private float time = 0.0f;

    public static float generationTime = 5;
    public float audienceGenerationTime = 0.5f;
    public bool isAudience = false;


    void Update()
    {
        if(generationTime<=3)
        {
            audienceGenerationTime = 0.25f;
        }

        float genTime = isAudience ? audienceGenerationTime : generationTime;
        time += Time.deltaTime;
        if(time>= genTime)
        {
            time = 0.0f;
            float r = Random.Range(-10.0f, 10.0f); //50% chance of hazard or collectable
            Vector3 pos = this.gameObject.transform.position;
            if (r<0)
            {
                Instantiate(HazardPrefab, pos, Quaternion.identity);
                //GameObject haz =
                //haz.transform.eulerAngles = new Vector3(
                //                    haz.transform.eulerAngles.x + 180,
                //                    haz.transform.eulerAngles.y + 90,
                //                    haz.transform.eulerAngles.z
                //);
            }
            else
            {
                Instantiate(CapsulePrefab, pos, Quaternion.identity);
            }
        }
        //int x = 0;
        
        //Vector3 pos = new Vector3(-x * 2, 0, Random.Range(-10.0f, 10.0f));
        //Instantiate(prefab, pos, Quaternion.identity);

        //pos = new Vector3(-x * 2, 0, Random.Range(-10.0f, 10.0f));
        //Instantiate(prefab, pos, Quaternion.identity);


        //pos = new Vector3(-x * 2, 0, Random.Range(-10.0f, 10.0f));
        //Instantiate(prefab, pos, Quaternion.identity);
        
    }
}
