using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidDrown : MonoBehaviour
{
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {

            transform.Translate(0, -speed * Time.deltaTime, 0);

    }

}
