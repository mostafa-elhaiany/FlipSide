using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool isPaused = false;

    public Image menu;
    public Button resume;
    public Button restart;
    public Button quit;
    public Image loadingScreen;


    void Update()
    {
        //loadingScreen.gameObject.SetActive(false);
        resume.gameObject.SetActive(isPaused);
        restart.gameObject.SetActive(isPaused);
        quit.gameObject.SetActive(isPaused);
        menu.gameObject.SetActive(isPaused);


        resume.GetComponent<Button>().onClick.AddListener(resumeGame);
        restart.GetComponent<Button>().onClick.AddListener(restartGame);
        quit.GetComponent<Button>().onClick.AddListener(quitGame);
    }

    void resumeGame()
    {
        isPaused = false;
    }

    void restartGame()
    {
        isPaused = false;
        loadingScreen.gameObject.SetActive(true);
        SceneManager.LoadScene("Game");
    }

    void quitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
