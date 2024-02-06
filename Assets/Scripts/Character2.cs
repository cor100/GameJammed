using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2 : Character1
{
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    // void Update()
    // {
        
    // }

    protected override void UpdateVelChange()
    {
        if (Input.GetKey(KeyCode.W))
        {
            velChange.y = jumpSpeed;
            Animate("jump");
        }
        if (Input.GetKey(KeyCode.A))
        {
            velChange.x = -playerSpeed;
            _playerSpriteRenderer.flipX = true;
            Animate("run");
        }
        if (Input.GetKey(KeyCode.D))
        {
            velChange.x = playerSpeed;
            _playerSpriteRenderer.flipX = false;
            Animate("run");
        }
    }

    protected override void Attack()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(AnimateAttack());
            Collider2D attackedLeft = Physics2D.OverlapBox(centreLeft, new Vector2(1.5f, 2), 0, hitboxLayer);  
            Collider2D attackedRight = Physics2D.OverlapBox(centreRight, new Vector2(1.5f, 2), 0, hitboxLayer);
            if(attackedLeft != null){
                Debug.Log("left");
            }
            if (attackedLeft != null && attackedLeft.gameObject.GetComponent<Hitbox1>() != null){
                Debug.Log("2left");
                attackedLeft.gameObject.GetComponent<Hitbox1>().hit();
            }
            if (attackedRight != null && attackedRight.gameObject.GetComponent<Hitbox1>() != null){
                Debug.Log("2right");
                attackedRight.gameObject.GetComponent<Hitbox1>().hit();
            }
        }

        //LayerMask hello = gameObject.GetComponent<Hitbox1>().LayerMask();
    }


}
