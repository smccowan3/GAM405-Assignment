using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magpie : killingObject
{
    public int multip = 1;
    void Awake()
    {
        deathCode = 2;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "PlayerObject")
        {
            player.GetComponent<PlayerRespawn>().becomeDead(deathCode); 
        }
        else
        {
            multip = multip * -1; // move in opposite direction
        }
    }
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(8 * multip, 0); // move left and right
        if (multip == 1)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (multip == -1)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

}
