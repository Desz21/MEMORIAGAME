using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl9 : MonoBehaviour
{
    public static GameControl9 Instance;
    public GameObject victoryScreen; // Asigna esto en el inspector

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
}

