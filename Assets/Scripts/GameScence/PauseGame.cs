using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    GameObject escActive;

    // Start is called before the first frame update
    void Start()
    {
        escActive = GameObject.Find("SceneManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(escActive.GetComponent<EscGameButton>().escPanel.activeInHierarchy == true)
        {
            PauseGameFunction();
        }

        else if (escActive.GetComponent<EscGameButton>().escPanel.activeInHierarchy == false)
        {
            ResumeGameFunction();
        }
    }

    void PauseGameFunction()
    {
        Time.timeScale = 0;
    }
    void ResumeGameFunction()
    {
        Time.timeScale = 1;
    }
}
