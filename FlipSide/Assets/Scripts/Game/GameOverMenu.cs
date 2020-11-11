using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOverMenu : MonoBehaviour
{
    
    public Image menu;
    public Button restart;
    public Button quit;
    public Image loadingScreen;


    public bool isGameover;
    public void Start()
    {
        isGameover = false;
        loadingScreen.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
    }
    void Update()
    {
        isGameover = playerCollisions.gameOver;
        
        restart.gameObject.SetActive(isGameover);
        quit.gameObject.SetActive(isGameover);
        menu.gameObject.SetActive(isGameover);


        restart.GetComponent<Button>().onClick.AddListener(restartGame);
        quit.GetComponent<Button>().onClick.AddListener(quitGame);
    }
    void restartGame()
    {
        loadingScreen.gameObject.SetActive(true);
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Collectable");
        foreach (GameObject obj in objs)
        {
            GameObject.Destroy(obj.gameObject);
        }
        objs = GameObject.FindGameObjectsWithTag("Hazard");
        foreach (GameObject obj in objs)
        {
            GameObject.Destroy(obj.gameObject);
        }
        StartCoroutine(restarter());
    }
    IEnumerator restarter()
    {
        Behaviour.restart = true;
        yield return new WaitForSeconds(1f);
        isGameover = false;
        FindObjectOfType<AudioManager>().stop("backGroundMusic");
        FindObjectOfType<AudioManager>().play("backGroundMusic");

        loadingScreen.gameObject.SetActive(false);

    }


    void quitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
