using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWindEffect : MonoBehaviour
{
    public Vector2 windMultiplier = Vector2.one;
    float finalCoeffcient = 1f;
    Rigidbody2D playerRb;

    void Start()
    {
        playerRb = this.GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var windForce = WindController.currentWindAmount
            * windMultiplier
            * Time.deltaTime
            * finalCoeffcient;

        playerRb.position += windForce;

        //Debug.Log($"The wind force is {windForce}");
    }


    const string tagName = "WindShelter";

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");
        if(collision.tag == tagName)
        {
            finalCoeffcient = 0;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("OnTriggerExit2D");
        if (collision.tag == tagName)
        {
            finalCoeffcient = 1f;
        }
    }
}
