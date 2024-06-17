using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLevels1 : MonoBehaviour
{
    [SerializeField] private Button nextButton;  // Reference to the 'next' button
    //[SerializeField] private Button backButton;  // Reference to the 'back' button
    [SerializeField] private Button mainMenuButton;  // Reference to the 'back' button
    [SerializeField] private Button SecondmainMenuButton; // Reference to the  'Main back' button
    [SerializeField] private Button RestartButton; // Reference to the  'Main back' button
    [SerializeField] private Button ThirdmainMenuButton; // Reference to the  'Main back' button

    public void LoadNextLevel()
    {
        MusicManager.Instance.StopVictoryMusic();
        MusicManager.Instance.ResumeBackgroundMusic();
        SceneManager.LoadScene(14); // Change to the actual name of your next level scene
    }

    public void RestartLevel()
    {
        MusicManager.Instance.StopVictoryMusic();
        MusicManager.Instance.ResumeBackgroundMusic();
        SceneManager.LoadScene(13); // Change to the actual name of your next level scene
    }

    public void ReturnToMainMenu()
    {
        MusicManager.Instance.StopVictoryMusic();
        MusicManager.Instance.ResumeBackgroundMusic();
        SceneManager.LoadScene(1); // Change to the actual name of your previous level scene
    }

    void Awake()
    {
        nextButton.onClick.AddListener(LoadNextLevel);  // Attach event listener for 'next'
        //backButton.onClick.AddListener(LoadPreviousLevel);  // Attach event listener for 'back'
        mainMenuButton.onClick.AddListener(ReturnToMainMenu);  // Attach event listener for 'Return to Main Menu'
        SecondmainMenuButton.onClick.AddListener(ReturnToMainMenu); // Attach event listener for 'Return to Main Menu'
        RestartButton.onClick.AddListener(RestartLevel);
        ThirdmainMenuButton.onClick.AddListener(ReturnToMainMenu);
    }
}