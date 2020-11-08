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
    public Button quit;


    public Button[] optionList;
    public bool optionClicked;
    public bool mute;


    public Text pcText;
    public Text androidText;



    void Start()
    {
        startGame.GetComponentInChildren<Text>().text = "Start Game";
        options.GetComponentInChildren<Text>().text = "Options";
        credits.GetComponentInChildren<Text>().text = "Credits";
        quit.GetComponentInChildren<Text>().text = "Quit";


        startGame.GetComponent<Button>().onClick.AddListener(StartGame);
        options.GetComponent<Button>().onClick.AddListener(optionsClick);
        credits.GetComponent<Button>().onClick.AddListener(Credits);
        quit.GetComponent<Button>().onClick.AddListener(quitGame);

        

    }
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if (optionClicked)
                optionsBack();
            else
                quitGame();
        }
    }

    void quitGame()
    {
        Debug.Log("QUITTING!");
        Application.Quit();
    }

    void StartGame()
    {
       
        SceneManager.LoadScene("Game");
    }

    void optionsBack()
    {
        optionClicked = false;
        options.GetComponent<Animator>().SetBool("OptionsClicked", false);
        StartCoroutine(optionsCoroutine());
        foreach (Button option in optionList)
        {
            option.gameObject.SetActive(false);
        }
    }

    IEnumerator optionsCoroutine()
    {
        yield return new WaitForSeconds(1f);
        startGame.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);


        if (Application.platform == RuntimePlatform.Android)
        {
            androidText.gameObject.SetActive(false);
        }
        else
        {
            pcText.gameObject.SetActive(false);
        }

    }

    void optionsClick()
    {
        optionClicked = true;
        startGame.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);

        options.GetComponent<Animator>().SetBool("OptionsClicked", true);
        foreach(Button option in optionList)
        {
            option.gameObject.SetActive(true);
            //option.GetComponentInChildren<Text>().text = option.gameObject.name;
            if(option.gameObject.name.Equals("Mute"))
            {
                option.GetComponent<Button>().onClick.AddListener(muteonClick);
                if (Options.mute)
                    option.GetComponent<Button>().GetComponent<Image>().color = Color.red;
                else
                    option.GetComponent<Button>().GetComponent<Image>().color = Color.yellow;
            }
            else if (option.gameObject.name.Equals("Back"))
            {
                option.GetComponent<Button>().onClick.AddListener(optionsBack);
            }
            else if(option.gameObject.name.Equals("How to play"))
            {
            }
            else if (option.gameObject.name.Equals("quit2"))
            {
                option.GetComponent<Button>().onClick.AddListener(quitGame);
            }
        }

        if (Application.platform == RuntimePlatform.Android)
        {
            androidText.gameObject.SetActive(true);
        }
        else
        {
            pcText.gameObject.SetActive(true);
        }

    }

    void muteonClick()
    {
        mute = !mute;
        Options.mute = mute;
        GameObject but = GameObject.Find("Mute");
        if(mute)
            but.GetComponent<Button>().GetComponent<Image>().color = Color.red;
        else
            but.GetComponent<Button>().GetComponent<Image>().color = Color.yellow;

    }
   

    void Credits()
    {
        
        SceneManager.LoadScene("Credits");


    }
}
