using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsNumber : MonoBehaviour
{
    public Text coinsScore;
    int NumberofCoins;

    // Start is called before the first frame update
    void Start()
    {

        NumberofCoins = 0;
        coinsScore.text = "Coins : " + NumberofCoins;

    }

    //Coins text number
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            NumberofCoins += 1;
            coinsScore.text = "Coins : " + NumberofCoins;
            Destroy(collision.gameObject);

        }
    }
}
