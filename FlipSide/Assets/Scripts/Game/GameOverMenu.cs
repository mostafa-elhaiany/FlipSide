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
        isGameover = false;
        loadingScreen.gameObject.SetActive(true);
        SceneManager.LoadScene("Game");
    }

    void quitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
