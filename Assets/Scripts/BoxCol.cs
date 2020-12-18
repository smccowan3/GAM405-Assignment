using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCol : Collider
{
    void Awake()
    {
        groundStatus = true;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        transform.parent.GetComponent<PlayerAttributes>().CollisionDetectedBox(this); // passes to parent
    }
}
