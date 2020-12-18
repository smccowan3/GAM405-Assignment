using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magpie : MonoBehaviour
{
    public int multip = 1;
    public GameObject player;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "PlayerObject")
        {
            player.GetComponent<PlayerRespawn>().becomeDead(2);
        }
        else
        {
            multip = multip * -1;
        }
    }
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(10 * multip, 0);
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
