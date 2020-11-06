using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleInput : MonoBehaviour
{
    public GameObject[] Cameras;
    public int activeCam = 0;

    public GameObject player;
    public GameObject elvis;
    public Animator anim;


    public GameObject bottomTeleporter;
    public GameObject upperTeleporter;
    private GameObject[] platforms;

    public int activePlatform = 0;

    
    void Start()
    {
        Cameras[0].SetActive(true);
        platforms = new GameObject[2];
        platforms[0] = bottomTeleporter;
        platforms[1] = upperTeleporter;

    }


    void Update()
    {
        if (playerCollisions.gameOver)
            return;

        if (Input.GetKeyUp(KeyCode.Space))
        {
            flipPlatform();
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            toggleCamera();
        }

    }

    void toggleCamera()
    {
        Cameras[activeCam].SetActive(false);
        if (activeCam == 2)
            activeCam++;
        activeCam = (activeCam + 1) % 2;
        Cameras[activeCam].SetActive(true);
    }
    void flipPlatform()
    {
        activePlatform = (activePlatform + 1) % 2;

        anim.SetBool("jump", !anim.GetBool("jump"));
        if(activeCam == 0)
        {
            Cameras[0].SetActive(false);
            activeCam = 2;
            Cameras[2].SetActive(true);
        }
        else if(activeCam == 2)
        {
            Cameras[2].SetActive(false);
            activeCam = 0;
            Cameras[0].SetActive(true);
        }

        StartCoroutine(switchPlat());

        //Vector3 newPos = platforms[activePlatform].transform.position;

        //player.transform.position = newPos;
    }

    IEnumerator switchPlat()
    {

        Vector3 newPos = platforms[activePlatform].transform.position;
        if (anim.GetBool("jump"))
        {
            yield return new WaitForSeconds(2f);
            //elvis.transform.position = newPos - new Vector3(0, 1.6f, 0);
        }
        else
        {
            yield return new WaitForSeconds(1.2f);
            //elvis.transform.position = newPos + new Vector3(0, 0.8f, 0);
        }
        player.transform.position = newPos;

    }
}
