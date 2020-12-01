using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public int playerLevel = 1;
    public bool alive = true;
    public float jumpHeight = 5;
    public int breakStrength = 100;

    void becomeDead()
    {
        alive = false;
        playerLevel++;
    }

    void breakSomething(int something)
    {
        if (breakStrength >= something)
        {
            Debug.Log("wow you broke something");
        }
        else if (breakStrength < something)
        {
            Debug.Log("darn you didnt break something");
        }
    }

    void Jump()
    {
        GetComponent<Rigidbody>().velocity = Vector2.up * jumpHeight; 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }
}
