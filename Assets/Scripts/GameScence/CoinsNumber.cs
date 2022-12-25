using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinsNumber : MonoBehaviour
{
    GameObject textGameObject;
    public int NumberofCoins;
    GameObject canvas;

    private void Start()
    {
        canvas = GameObject.Find("CoinsCanvas");

        textGameObject = GameObject.Find("CoinsScore");
    }

    private void Update()
    {
        // textGameObject.GetComponent<Text>().text means that this textGameObject is a gameobject that gets a component of text and in the text this line is written "Coins : " + NumberofCoins = number of the coins collected
        textGameObject.GetComponent<Text>().text = "Coins : " + NumberofCoins;     

        if (SceneManager.GetSceneByName("OpeningScene").isLoaded)
        {
            Destroy(gameObject);
        }

        else if (SceneManager.GetSceneByName("Level01").isLoaded)
        {
            DontDestroyOnLoad(gameObject);

            canvas.GetComponent<Canvas>().enabled = true;
        }

        else if (SceneManager.GetSceneByName("Level1Passed").isLoaded)
        {
            DontDestroyOnLoad(gameObject);

            canvas.GetComponent<Canvas>().enabled = false;
        }
    }
}
