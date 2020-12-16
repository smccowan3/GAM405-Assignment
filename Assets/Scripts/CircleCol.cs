using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCol : Collider
{
    void Awake()
    {
        groundStatus = true;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        transform.parent.GetComponent<PlayerAttributes>().CollisionDetectedCircle(this);
    }
}
