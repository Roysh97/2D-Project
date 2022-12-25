using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    BlueSmoke bluerSmoke;

    private void Start()
    {
        // Find all irrelevant objects according to level01 
        GameObject.Find("SoundManager");
        GameObject.Find("Smoke");
        GameObject.Find("BlueSmoke");
    }

    public void OnClickButton()
    {
        // When the function load level01, destroy all irrelevant objects (smoke effect and the music background)
        SceneManager.LoadScene("Level01");

        if (Smoke.smoke != null)
        {
            Destroy(Smoke.smoke.gameObject);
        }

        //BlueSmoke.blue = null;      example for getting a static variable.
        //bluerSmoke.    example for not getting the static variable , the static variable is not accessible.

        if (BlueSmoke.blueSmoke != null)
        {
            Destroy(BlueSmoke.blueSmoke.gameObject);
        }

        if (SoundManager.sound != null)
        {
            Destroy(SoundManager.sound.gameObject);
        }
    }
}
