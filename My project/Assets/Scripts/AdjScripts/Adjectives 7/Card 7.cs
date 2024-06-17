using UnityEngine;
using UnityEngine.UI; // Asegúrate de incluir este espacio de nombres

public class Card7 : MonoBehaviour
{
    public bool isCorrectCard; // Define si esta es la carta correcta para la pregunta o desafío

    private void Start()
    {
        // Añade un listener al evento onClick del componente Button.
        // Esto asegura que cuando se haga clic en la carta, se llame a la función OnCardSelected.
        GetComponent<Button>().onClick.AddListener(OnCardSelected);
    }

    private void OnCardSelected()
    {
        // Esta función se llama cuando el jugador hace clic en la carta.
        if (isCorrectCard)
        {
            // Si la carta es la correcta, llama a la función para mostrar la pantalla de victoria.
            GameControl.Instance.ShowVictoryScreen();
        }
        else
        {
            // Aquí puedes manejar lo que sucede cuando se selecciona la carta incorrecta.
            // Por ejemplo, podrías mostrar un mensaje de error o realizar alguna animación.
        }
    }
}
