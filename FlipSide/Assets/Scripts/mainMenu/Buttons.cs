using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour
{
    public Button startGame;

    public Button options;
    public Button[] optionList;
    public bool optionClicked;
    public bool mute;

    public Button credits;


    void Start()
    {
        startGame.GetComponentInChildren<Text>().text = "Start Game";
        options.GetComponentInChildren<Text>().text = "Options";
        credits.GetComponentInChildren<Text>().text = "Credits";


        Button btn1 = startGame.GetComponent<Button>();
        btn1.onClick.AddListener(StartGame);

        Button btn2 = options.GetComponent<Button>();
        btn2.onClick.AddListener(optionsClick);

        Button btn3 = credits.GetComponent<Button>();
        btn3.onClick.AddListener(Credits);

    }

    void StartGame()
    {
       
        SceneManager.LoadScene("Game");
    }

    void optionsClick()
    {
        optionClicked = true;
        startGame.gameObject.SetActive(false);
        credits.gameObject.SetActive(false);

        options.GetComponent<Animator>().SetBool("OptionsClicked", true);
        foreach(Button option in optionList)
        {
            option.gameObject.SetActive(true);
            option.GetComponentInChildren<Text>().text = option.gameObject.name;
            if(option.gameObject.name.Equals("Mute"))
            {
                option.GetComponent<Button>().onClick.AddListener(muteonClick);
            }
            else if (option.gameObject.name.Equals("Back"))
            {
                option.GetComponent<Button>().onClick.AddListener(backOnClick);
            }
        }

    }

    void muteonClick()
    {
        mute = !mute;
        Options.mute = mute;
        GameObject but = GameObject.Find("Mute");
        if(!mute)
            but.GetComponent<Button>().GetComponent<Image>().color = Color.red;
        else
            but.GetComponent<Button>().GetComponent<Image>().color = Color.yellow;

    }

    void backOnClick()
    {
        SceneManager.LoadScene("Main Menu");
    }
    

    void Credits()
    {
        
        SceneManager.LoadScene("Credits");


    }
}
