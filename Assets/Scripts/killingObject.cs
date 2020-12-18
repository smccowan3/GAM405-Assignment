using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killingObject : MonoBehaviour
{
    // all five of the death conditions will use this class, though the oncollision2d method will be overloaded (polymorphism)
    public int deathCode;
    public GameObject player;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "PlayerObject")
        {
            player.GetComponent<PlayerRespawn>().becomeDead(deathCode);
        }
    }
}
