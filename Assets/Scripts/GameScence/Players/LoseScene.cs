using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScene : MonoBehaviour
{
    // If the player is dead. Yes for reload scene level01, No for main menu.
    public void TryAgainYes()
    {
        SceneManager.LoadScene("Level01");
    }

    public void NoButton()
    {
        SceneManager.LoadScene("OpeningScene");
    }
}
