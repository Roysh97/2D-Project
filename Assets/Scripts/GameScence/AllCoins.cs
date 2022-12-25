using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AllCoins : MonoBehaviour
{
    //this script is created for the purpose of the player to see in the level1 end scene the total sum of the coins that has been collected

    public Text coinsScore;
    GameObject coinsNumber;

    // Start is called before the first frame update
    void Start()
    {
        coinsNumber = GameObject.Find("CoinsCanvas");
    }

    // Update is called once per frame
    void Update()
    {
        // textGameObject.GetComponent<Text>().text means that this textGameObject is a gameobject that gets a component of text and in the text this line is written "Coins : " + NumberofCoins = number of the coins collected
        // this code gets the number of coins from the variable NumberofCoins in script CoinsNumber
        coinsScore.text = "Coins : " + coinsNumber.GetComponent<CoinsNumber>().NumberofCoins;  
    }
}
