using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour
{
    public Button startGame;

    public Button options;

    public Button credits;


    void Start()
    {
        startGame.GetComponentInChildren<Text>().text = "Start Game";
        options.GetComponentInChildren<Text>().text = "Options";
        credits.GetComponentInChildren<Text>().text = "Credits";


        Button btn1 = startGame.GetComponent<Button>();
        btn1.onClick.AddListener(StartGame);

        Button btn2 = options.GetComponent<Button>();
        btn2.onClick.AddListener(Options);

        Button btn3 = credits.GetComponent<Button>();
        btn3.onClick.AddListener(Credits);
    }

    void StartGame()
    {
        Debug.Log("Start Game");
    }

    void Options()
    {
        Debug.Log("Options");
    }

    void Credits()
    {
        Debug.Log("Credits");
        SceneManager.LoadScene("Credits");


    }
}
