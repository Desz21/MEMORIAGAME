using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl3 : MonoBehaviour
{
    public static GameControl3 Instance;
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
