using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Smoke : MonoBehaviour
{
    public static Smoke smoke;

    // If the function came to a new scene and the game object not exists, dont destroy on load. if it is exists, destroy it.
    private void Awake()
    {
        if (smoke == null)
        {
            smoke = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (smoke != null)
        {
            Destroy(gameObject);
        }
    }

    
}
