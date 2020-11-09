using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public Button pause;

    public Button flip;

    public Button toggleCamera;
    


    void Start()
    {
        pause.GetComponentInChildren<Text>().text = "Pause";
        flip.GetComponentInChildren<Text>().text = "flip";
        toggleCamera.GetComponentInChildren<Text>().text = "Toggle Camera";

        Button btn1 = pause.GetComponent<Button>();
        btn1.onClick.AddListener(PauseGame);

        Button btn2 = flip.GetComponent<Button>();
        btn2.onClick.AddListener(Flip);

        Button btn3 = toggleCamera.GetComponent<Button>();
        btn3.onClick.AddListener(ToggleCamera);

       
    }
    

    void PauseGame()
    {
        Debug.Log("Pause");
        PauseMenu.isPaused = !PauseMenu.isPaused;

    }

    void Flip()
    {
        HandleInput.switchPlatform = true;
    }

    void ToggleCamera()
    {
        HandleInput.switchCamera = true;
    }
}
