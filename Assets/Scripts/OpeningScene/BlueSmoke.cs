using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSmoke : MonoBehaviour
{
    public static BlueSmoke blueSmoke;

    public static BlueSmoke blue;

    private void Awake()
    {
        if (blueSmoke == null)
        {
            blueSmoke = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
