using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLevels3 : MonoBehaviour
{
    [SerializeField] private Button nextButton;  // Reference to the 'next' button
    [SerializeField] private Button backButton;  // Reference to the 'back' button
    [SerializeField] private Button mainMenuButton;  // Reference to the 'mainMenu' button
    [SerializeField] private Button RestartButtonV;  // Reference to the 'Restart' button
    [SerializeField] private Button RestartButtonD;  // Reference to the 'Restart' button
    [SerializeField] private Button backButtonV;  // Reference to the 'Second back' button
    [SerializeField] private Button mainMenuButtonV; // Reference to the  'Second Main Menu' button
    [SerializeField] private Button backButtonD;  // Reference to the 'Third back' button
    [SerializeField] private Button mainMenuButtonD; // Reference to the  'Thid main menu' button

    public void LoadNextLevel()
    {
        MusicManager.Instance.StopVictoryMusic();
        MusicManager.Instance.ResumeBackgroundMusic();
        SceneManager.LoadScene(16); // Change to the actual name of your next level scene
    }

    public void LoadPreviousLevel()
    {
        MusicManager.Instance.StopVictoryMusic();
        MusicManager.Instance.ResumeBackgroundMusic();
        SceneManager.LoadScene(14); // Change to the actual name of your previous level scene
    }

    public void ReturnToMainMenu()
    {
        MusicManager.Instance.StopVictoryMusic();
        MusicManager.Instance.ResumeBackgroundMusic();
        SceneManager.LoadScene(1); // Change to the actual name of your previous level scene
    }

    public void RestartLevel()
    {
        MusicManager.Instance.StopVictoryMusic();
        MusicManager.Instance.ResumeBackgroundMusic();
        SceneManager.LoadScene(15); // Change to the actual name of your next level scene
    }

    void Awake()
    {
        nextButton.onClick.AddListener(LoadNextLevel);
        backButton.onClick.AddListener(LoadPreviousLevel);
        mainMenuButton.onClick.AddListener(ReturnToMainMenu);
        RestartButtonV.onClick.AddListener(RestartLevel);
        RestartButtonD.onClick.AddListener(RestartLevel);
        backButtonV.onClick.AddListener(LoadPreviousLevel);
        mainMenuButtonV.onClick.AddListener(ReturnToMainMenu);
        backButtonD.onClick.AddListener(LoadPreviousLevel);
        mainMenuButtonD.onClick.AddListener(ReturnToMainMenu);
    }
}
