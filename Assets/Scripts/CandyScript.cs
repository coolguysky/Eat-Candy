using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyScript : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            GameManager.instance.incrementScore();
            Destroy(gameObject);
        } 
        else if(collider.gameObject.tag == "Boundary")
        {
            GameManager.instance.decrementLives();
            Destroy(gameObject);
        }

        
    }
}
