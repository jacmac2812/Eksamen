using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadCrystal : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}
