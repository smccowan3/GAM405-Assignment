using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public int playerLevel = 1;
    public bool alive = true;

    [SerializeField]
    public float jumpHeight = 5f;
    public float moveSpeed = 5f;

    Rigidbody2D rb;
    public int breakStrength = 100;
    bool onGround = false;
    float dirX;
    bool dblJump = false;

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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rb.velocity.y);
        //check if on ground
        if (rb.velocity.y == 0)
            onGround = true;
        else
            onGround = false;

        if (onGround)
            dblJump = true;

        if (onGround && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        else if (dblJump && Input.GetButtonDown("Jump"))
        {
            Jump();
            dblJump = false;
        }
        dirX = Input.GetAxis("Horizontal") * moveSpeed;
        if (rb.velocity.y <= 0.01 && rb.velocity.y >= -0.01)
        {
            rb.velocity = Vector2.zero;
        }

    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }


    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.velocity = Vector2.up * jumpHeight;
    }
}
