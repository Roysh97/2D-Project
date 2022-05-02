using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBack : MonoBehaviour
{
    // Go to new scene
    public void OnClickButton()
    {
        SceneManager.LoadScene("OpeningScene");
    }
}
