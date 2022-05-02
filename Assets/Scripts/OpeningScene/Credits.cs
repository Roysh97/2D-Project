using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    // Go to new scene
    public void OnClickButton()
    {
        SceneManager.LoadScene("Credits");
    }
}
