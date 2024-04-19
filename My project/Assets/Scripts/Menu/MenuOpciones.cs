using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOpciones : MonoBehaviour
{
    /*public void PantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
        FullScreenMode X = default;
        Screen.SetResolution(Screen.width, Screen.height, X);
    }*/
    public void PantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;

        FullScreenMode modoPantalla = pantallaCompleta ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
        Screen.SetResolution(Screen.width, Screen.height, modoPantalla);
    }
}
