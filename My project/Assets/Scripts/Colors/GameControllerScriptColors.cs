using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameControllerScriptColors : MonoBehaviour
{
    public const int columns = 6;
    public const int rows = 2;
    public const int scoremmax = (columns * rows) / 2;

    public const float Xspace = 2.5f;
    public const float Yspace = -3f;

    [SerializeField] private Image victoryImage;
    [SerializeField] private MainImageScriptColors startObject;
    [SerializeField] private Sprite[] images;
    [SerializeField] private Button nextButton;  // Reference to the 'next' button
    [SerializeField] private Button backButton;  // Reference to the 'back' button 
    [SerializeField] private Button mainMenuButton;  // Reference to the 'back' button

    private int[] Randomiser(int[] locations)
    {
        int[] array = locations.Clone() as int[];
        for (int i = 0; i < array.Length; i++)
        {
            int newArray = array[i];
            int j = Random.Range(i, array.Length);
            array[i] = array[j];
            array[j] = newArray;
        }
        return array;
    }

    private void Start()
    {
        int[] locations = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 };

        locations = Randomiser(locations);

        Vector3 startPosition = startObject.transform.position;

        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                MainImageScriptColors gameImage;
                if (i == 0 && j == 0)
                {
                    gameImage = startObject;
                }
                else
                {
                    gameImage = Instantiate(startObject) as MainImageScriptColors;
                }

                int index = j * columns + i;
                int id = locations[index];
                gameImage.ChangeSprite(id, images[id]);

                float positionX = (Xspace * i) + startPosition.x;
                float positionY = (Yspace * j) + startPosition.y;

                gameImage.transform.position = new Vector3(positionX, positionY, startPosition.z);
            }
        }
        victoryImage.gameObject.SetActive(false); //New change for images for victory
        nextButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(true);  // Show 'back' button
    }

    private MainImageScriptColors firstOpen;
    private MainImageScriptColors secondOpen;

    private int score = 0;
    private int attempts = 0;

    [SerializeField] private TextMesh scoreText;
    [SerializeField] private TextMesh attemptsText;

    public bool canOpen
    {
        get
        {
            return secondOpen == null;
        }
    }
    public void imageOpened(MainImageScriptColors startObject)
    {
        if(firstOpen == null)
        {
            firstOpen = startObject;
        }
        else
        {
            secondOpen = startObject;
            StartCoroutine(CheckGuessed());
        }
    }

    private IEnumerator CheckGuessed()
    {
        if(firstOpen.spriteId == secondOpen.spriteId) //Compares the two objects
        {
            score++; //Add score
            scoreText.text = "Score: " + score;

            if (score == scoremmax)
            {
                victoryImage.gameObject.SetActive(true); // New change for images
                //victoryText.gameObject.SetActive(true);
                nextButton.gameObject.SetActive(true);  // Show 'next' button
            }
        }
        else
        {
            yield return new WaitForSeconds(0.5f); //Start timer

            firstOpen.Close();
            secondOpen.Close();
        }

        attempts++;
        attemptsText.text = "Attempts: " + attempts;

        firstOpen = null;
        secondOpen = null;
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(5); // Change to the actual name of your next level scene
    }

    public void LoadPreviousLevel()
    {
        SceneManager.LoadScene(3); // Change to the actual name of your previous level scene
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(1); // Change to the actual name of your previous level scene
    }

    void Awake()
    {
        nextButton.onClick.AddListener(LoadNextLevel);  // Attach event listener for 'next'
        backButton.onClick.AddListener(LoadPreviousLevel);  // Attach event listener for 'back'
        mainMenuButton.onClick.AddListener(ReturnToMainMenu);  // Attach event listener for 'Return to Main Menu'
    }
    public void Restart()
    {
        SceneManager.LoadScene("Colors");
    }
}
