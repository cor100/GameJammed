using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character1 : MonoBehaviour
{
    public float playerSpeed = 1;
    private Rigidbody2D myRb2D;
    protected Vector2 velChange = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        myRb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateVelChange();
        myRb2D.velocity = velChange;
        ResetVelChange();
    }

    // update velocity and also animate sprite
    protected virtual void UpdateVelChange()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            velChange.y = playerSpeed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            velChange.x = -playerSpeed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            velChange.x = playerSpeed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            velChange.y = -playerSpeed;
        }
    }

    protected void ResetVelChange()
    {
        velChange = Vector2.zero;
    }


}
