using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPassed : MonoBehaviour
{

    // If player win the game
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Level1Passed");
        }
    }

    public void NextLevel02()
    {
        SceneManager.LoadScene("Level02");
    }

}
