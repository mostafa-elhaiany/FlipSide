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
    public static bool switchPlatform = false;
    public static bool switchCamera = false;

    private bool isJumping = false;

    
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

        if (Input.GetKeyUp(KeyCode.Space) || switchPlatform)
        {
            if(!isJumping)
            {
                isJumping = true;
                flipPlatform();
            }
        }

        if (Input.GetKeyUp(KeyCode.C) || switchCamera)
        {
            toggleCamera();
        }

    }

    void toggleCamera()
    {
        if (activeCam == 0)
        {
            Cameras[0].SetActive(false);
            activeCam = 1;
            Cameras[1].SetActive(true);
        }
        else if(activeCam == 1)
        {
            if(activePlatform==0)
            {
                Cameras[1].SetActive(false);
                activeCam = 0;
                Cameras[0].SetActive(true);
            }
            else
            {
                Cameras[1].SetActive(false);
                activeCam = 2;
                Cameras[2].SetActive(true);
            }
        }
        else if(activeCam == 2)
        {
            Cameras[2].SetActive(false);
            activeCam = 1;
            Cameras[1].SetActive(true);
        }
        switchCamera = false;
    }

    void flipPlatform()
    {
        activePlatform = (activePlatform + 1) % 2;

        anim.SetBool("jump", !anim.GetBool("jump"));

        StartCoroutine(switchPlat());

        
        //Vector3 newPos = platforms[activePlatform].transform.position;

        //player.transform.position = newPos;
    }

    IEnumerator switchPlat()
    {
        Vector3 activePos = platforms[activePlatform].transform.position;
        Vector3 newPos = new Vector3(player.transform.position.x,activePos.y,player.transform.position.z);

        if (anim.GetBool("jump"))
        {
            yield return new WaitForSeconds(2f);
            elvis.transform.position = newPos - new Vector3(0, 2f, 0);
        }
        else
        {
            yield return new WaitForSeconds(1.2f);
            elvis.transform.position = newPos + new Vector3(0, 2f, 0);
        }

        switchPlatformCamera();


        player.transform.position = newPos;
        isJumping = false;
        switchPlatform = false;
    }

    private void switchPlatformCamera()
    {
        if (activeCam == 0)
        {
            Cameras[0].SetActive(false);
            activeCam = 2;
            Cameras[2].SetActive(true);
        }
        else if (activeCam == 2)
        {
            Cameras[2].SetActive(false);
            activeCam = 0;
            Cameras[0].SetActive(true);
        }
    }
}
