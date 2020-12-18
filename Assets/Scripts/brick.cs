using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick : MonoBehaviour
{
    public GameObject player;
    public GameObject brick1;
    void Update()
    {
        if (player.GetComponent<PlayerRespawn>().respawning)
        {
            brick1.SetActive(true); // reset on respawn
        }
    }
}
