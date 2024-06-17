using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager _instance;
    public static MusicManager Instance => _instance;

    public AudioSource backgroundMusicSource;  // Assign in the Inspector
    public AudioSource victoryMusicSource;  // Assign in the Inspector
    public AudioSource WrongSoundEffect; //Assign in the inspector

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            backgroundMusicSource.Play();  // Ensure the background music starts playing
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlayVictoryMusic()
    {
        backgroundMusicSource.Pause();  // Pause the background music
        victoryMusicSource.Play();  // Play the victory music
    }

    public void StopVictoryMusic()
    {
        if (victoryMusicSource.isPlaying)
        {
            victoryMusicSource.Stop(); // Stop the victory music immediately
        }
    }


    public void ResumeBackgroundMusic()
    {
        if (!backgroundMusicSource.isPlaying)
        {
            backgroundMusicSource.UnPause();  // Resume the background music
        }
    }

    public void PlayWrongSoundEffect()
    {
        WrongSoundEffect.Play();
    }
}


