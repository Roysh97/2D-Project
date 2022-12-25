using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    // Quit game function
    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
