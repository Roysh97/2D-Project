using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    private void Start()
    {
        // Find all relevant objects
        GameObject.Find("SoundManager");
        GameObject.Find("Smoke");
        GameObject.Find("BlueSmoke");
    }

    public void OnClickButton()
    {
        // When the function load level01, destroy all relevant objects (smoke effect and the music background)
        SceneManager.LoadScene("Level01");

        if (Smoke.smoke != null)
        {
            Destroy(Smoke.smoke.gameObject);
        }

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
