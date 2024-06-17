using UnityEngine;
using UnityEngine.UI; // Asegúrate de incluir este espacio de nombres

public class Card : MonoBehaviour
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
            MusicManager.Instance.PlayVictoryMusic();
        }
        else
        {
            MusicManager.Instance.PlayWrongSoundEffect();
            GameControl.Instance.IncreaseMistakeCount();
        }
    }
}
