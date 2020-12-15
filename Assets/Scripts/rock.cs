using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rockbody;
    public Transform rocktransform;
    private int framecount = 0;
    // Start is called before the first frame update
    void Awake()
    {
        rockbody = GetComponent<Rigidbody2D>();
        rocktransform = GetComponent<Transform>();
    }


    void Update()
    {
        Debug.Log(framecount);
        if (isStationary())
        {
            framecount++;
        }
        else if (isStationary() == false)
        {
            framecount = 0;
        }
        if (framecount > 6000)
        {
            Debug.Log("condition fulfilled");
            rockbody.velocity = Vector2.down;
        }
    }

    bool isStationary()
    {
        bool stationary = false;
        if (player.GetComponent<Rigidbody2D>().velocity.y == 0 && player.GetComponent<Rigidbody2D>().velocity.x == 0) //initially stationary
        {
            stationary = true;
        }
            return stationary;
    }

    void OnCollisionEnter(Collision collision)
    {
        player.GetComponent<PlayerAttributes>().becomeDead();
    }
}
