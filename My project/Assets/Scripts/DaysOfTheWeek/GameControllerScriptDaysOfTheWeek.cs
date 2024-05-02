using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScriptDaysOfTheWeek : MonoBehaviour
{
    public const int columns = 7;
    public const int rows = 2;
    public const int scoremmax = (columns * rows) / 2;

    public const float Xspace = 2.5f;
    public const float Yspace = -3.2f;

    [SerializeField] private MainImageScriptDaysOfTheWeek startObject;
    [SerializeField] private Sprite[] images;

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
        int[] locations = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6 };

        locations = Randomiser(locations);

        Vector3 startPosition = startObject.transform.position;

        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                MainImageScriptDaysOfTheWeek gameImage;
                if (i == 0 && j == 0)
                {
                    gameImage = startObject;
                }
                else
                {
                    gameImage = Instantiate(startObject) as MainImageScriptDaysOfTheWeek;
                }

                int index = j * columns + i;
                int id = locations[index];
                gameImage.ChangeSprite(id, images[id]);

                float positionX = (Xspace * i) + startPosition.x;
                float positionY = (Yspace * j) + startPosition.y;

                gameImage.transform.position = new Vector3(positionX, positionY, startPosition.z);
            }
        }
    }

    private MainImageScriptDaysOfTheWeek firstOpen;
    private MainImageScriptDaysOfTheWeek secondOpen;

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
    public void imageOpened(MainImageScriptDaysOfTheWeek startObject)
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

    public void Restart()
    {
        SceneManager.LoadScene("DaysOfTheWeek");
    }
}
