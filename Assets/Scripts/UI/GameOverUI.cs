using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI recipesDeliveredText;
    [SerializeField] private Button playAgainButton;




    private void Awake()
    {
        playAgainButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.Shutdown();
            Loder.Load(Loder.Scene.MainMenuScene);
        });
    }


    private void Start()
    {
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;

        Hide();
    }



    private void KitchenGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (KitchenGameManager.Instance.IsGameOver())
        {
            Show();

            recipesDeliveredText.text = DeliveryManager.Instance.GetSuccessfulRecipesAmount().ToString();
        }
        else
        {
            Hide();
        }
    }

   

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}