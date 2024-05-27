using UnityEngine;
using UnityEngine.UI; // Aseg�rate de incluir este espacio de nombres

public class Card7 : MonoBehaviour
{
    public bool isCorrectCard; // Define si esta es la carta correcta para la pregunta o desaf�o

    private void Start()
    {
        // A�ade un listener al evento onClick del componente Button.
        // Esto asegura que cuando se haga clic en la carta, se llame a la funci�n OnCardSelected.
        GetComponent<Button>().onClick.AddListener(OnCardSelected);
    }

    private void OnCardSelected()
    {
        // Esta funci�n se llama cuando el jugador hace clic en la carta.
        if (isCorrectCard)
        {
            // Si la carta es la correcta, llama a la funci�n para mostrar la pantalla de victoria.
            GameControl.Instance.ShowVictoryScreen();
        }
        else
        {
            // Aqu� puedes manejar lo que sucede cuando se selecciona la carta incorrecta.
            // Por ejemplo, podr�as mostrar un mensaje de error o realizar alguna animaci�n.
        }
    }
}
