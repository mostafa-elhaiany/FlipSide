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
            float r = Random.Range(0.0f, 10.0f);
            if(r<3)
            {
                return;
            }

            Vector3 pos = this.gameObject.transform.position;
            r = Random.Range(-10.0f, 10.0f); //50% chance of hazard or collectable
            if (r<0)
            {
                Instantiate(HazardPrefab, pos, Quaternion.identity);
            }
            else
            {
                Instantiate(CapsulePrefab, pos, Quaternion.identity);
            }
        }
    }
}
