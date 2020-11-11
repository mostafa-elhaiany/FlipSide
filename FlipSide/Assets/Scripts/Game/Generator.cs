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

    private static float nextMeshScale = 2;

    void Update()
    {
        if (PauseMenu.isPaused)
            return;

        if(generationTime<=3)
        {
            audienceGenerationTime = 0.01f;
        }
        else if (generationTime >= 5)
        {
            audienceGenerationTime = 0.5f;
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
            GameObject instantiated;
            if (r<0)
            {
                instantiated = Instantiate(HazardPrefab, pos, Quaternion.identity);
            }
            else
            {
                instantiated = Instantiate(CapsulePrefab, pos, Quaternion.identity);
            }
            if (genTime < nextMeshScale)
            {
                instantiated.transform.localScale = new Vector3(
                    instantiated.transform.localScale.x,
                    instantiated.transform.localScale.y,
                    instantiated.transform.localScale.z * 2);
                nextMeshScale /= 2;
            }

        }
    }
}
