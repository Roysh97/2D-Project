using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscGameButton : MonoBehaviour
{
    public GameObject escPanel;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            escPanel.SetActive(!escPanel.activeSelf);    //if player press Escape button once the escape options opens and pressing the Escape button again closes the escape options
        }
    }

    public void NoExitButton()
    {
        escPanel.SetActive(false);
    }

    public void YesExitButton()
    {
        SceneManager.LoadScene("OpeningScene");
    }
}
