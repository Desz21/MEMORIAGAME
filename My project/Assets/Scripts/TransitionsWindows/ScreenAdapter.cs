using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private int lastScreenWidth;
    private int lastScreenHeight;

    void Start()
    {
        lastScreenWidth = Screen.width;
        lastScreenHeight = Screen.height;
        AdjustUIBasedOnResolution();
    }

    void Update()
    {
        if (Screen.width != lastScreenWidth || Screen.height != lastScreenHeight)
        {
            // Se detecta un cambio en el tamaño de la ventana, se ajusta la UI
            AdjustUIBasedOnResolution();
            lastScreenWidth = Screen.width;
            lastScreenHeight = Screen.height;
        }
    }

    private void AdjustUIBasedOnResolution()
    {
        // Lógica para ajustar elementos de la UI
        if (Screen.width < 800) // Ejemplo para pantallas pequeñas
        {
            // Ajustes específicos, por ejemplo, cambiar el tamaño de los botones o el espaciado
        }
        else
        {
            // Ajustes para pantallas más grandes
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject); // Asegura que este objeto no se destruya al cargar una nueva escena.
    }

}