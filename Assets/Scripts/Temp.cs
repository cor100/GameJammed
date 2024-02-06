using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    /// <summary>
    /// This is called by Unity when the object enters the area of another object's trigger collider. It is only called when both objects have any 2D Collider attached,
    /// one of them is a trigger and at least of the two colliding GameObjects has a Rigidbody2D attached. 
    /// If none of the two 2D Colliders is a trigger, OnCollisionEnter2D(...) is called instead. </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if the other object has the asteroid tag, the destroy the ship and restard the game
        if (collision.gameObject.CompareTag("Platform"))
        {
            Destroy(GetComponent<SpriteRenderer>());
        }
    }
}
