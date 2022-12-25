using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPassed : MonoBehaviour
{

    // If player win the game
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player") //if there is a collision with the player load scene level1Passed
        {
            SceneManager.LoadScene("Level1Passed");
        }
    }
    public void NextLevel02()  // on click button loads level02 the button is next level
    {
        SceneManager.LoadScene("Level02");
    }

}
