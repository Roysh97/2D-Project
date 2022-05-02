using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager sound;

    // If the function came to a new scene and the game object not exists, dont destroy on load. if it is exists, destroy it.
    private void Awake()
    {
        if (sound == null)
        {
            sound = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (sound != null)
        {
            Destroy(gameObject);
        }
    }
}
