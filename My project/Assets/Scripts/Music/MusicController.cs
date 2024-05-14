using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private static MusicController instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Makes the GameObject persistent across scenes
        }
        else if (instance != this)
        {
            Destroy(gameObject); // Ensures only one instance of the music player exists
        }
    }
}
