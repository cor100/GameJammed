using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox2 : Hitbox1
{

    public Character2 character2;

    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
    public override void hit(){
        character2.getHit();
        // gameObject.GetComponentInParent<Character2>().getHit();
    }
}
