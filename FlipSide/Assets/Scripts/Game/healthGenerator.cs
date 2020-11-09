using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthGenerator : MonoBehaviour
{
    public GameObject waterPrefab;

    private float time = 0.0f;

    public static float generationTime = 17;


    void Update()
    {
        if (PauseMenu.isPaused)
            return;

        time += Time.deltaTime;
        if (time >= generationTime)
        {
            time = 0.0f;
            float r = Random.Range(0.0f, 10.0f);
            if (r < 8)
            {
                return;
            }

            Vector3 pos = this.gameObject.transform.position;
            Instantiate(waterPrefab, pos, Quaternion.identity);
            
        }
    }
}
