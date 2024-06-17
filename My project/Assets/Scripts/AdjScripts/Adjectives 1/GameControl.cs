using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl Instance;
    public GameObject victoryScreen; // Asigna esto en el inspector
    public GameObject defeatScreen; // Assign this in the inspector
    [SerializeField] private TextMeshProUGUI LivesText;
    private int LivesCount = 5;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void ShowVictoryScreen()
    {
        victoryScreen.SetActive(true); // Muestra la pantalla de victoria
    }

    public void IncreaseMistakeCount()
    {
        LivesCount--;
        LivesText.text = "Lives: " + LivesCount;
        if (LivesCount == 0)
        {
            ShowDefeatScreen();
        }
    }

    public void ShowDefeatScreen()
    {
        defeatScreen.SetActive(true); // Muestra la pantalla de derrota
    }
}

