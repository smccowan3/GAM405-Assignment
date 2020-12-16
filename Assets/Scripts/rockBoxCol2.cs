using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockBoxCol2 : MonoBehaviour
{
    public GameObject player;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "PlayerObject")
        {
            player.GetComponent<PlayerAttributes>().becomeDead();
        }
    }
}
