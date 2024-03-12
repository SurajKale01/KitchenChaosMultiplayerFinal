using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{

    [SerializeField] private Button playMultiplayerButton;
    [SerializeField] private Button playSingleplayerButton;
    [SerializeField] private Button quitButton; 

    private void Awake()
    {
        playSingleplayerButton.onClick.AddListener(() =>
        {
            Debug.Log("Clicked!!");
            KitchenGameMultiplayer.playMultiplayer = false;
            Loder.Load(Loder.Scene.LobbyScene);
        });
         
        playMultiplayerButton.onClick.AddListener(() =>
        {
            KitchenGameMultiplayer.playMultiplayer = true;
            Loder.Load(Loder.Scene.LobbyScene);
            Debug.Log("Multiplayer!");

        });

        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });

        Time.timeScale = 1.0f;
    }

}
