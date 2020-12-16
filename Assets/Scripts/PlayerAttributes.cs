using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public int playerLevel = 0;
    public bool alive = true;
    public float jumpHeight = 5f;
    public float moveSpeed = 5f;
    
    Rigidbody2D rb;
    public GameObject prefab;
    public int breakStrength = 100;
    bool onGround = false;
    float dirX;
    bool dblJump = false;
    bool sideCollision = false;
  

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //check if on ground
        if (rb.velocity.y == 0 & sideCollision == false)
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
        FlipSprite(dirX);
        if (rb.velocity.y <= 0.01 && rb.velocity.y >= -0.01 && rb.velocity.x <= 0.01 && rb.velocity.x >= -0.01)
        {
            rb.velocity = Vector2.zero;
        }
    }


    //below is physics functions
    void FlipSprite(float directionX)
    {
        if (directionX > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (directionX < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }


    public void CollisionDetectedCircle(CircleCol circleCollision)
    {
        sideCollision = true;
    }

    public void CollisionDetectedBox(BoxCol BoxCollision)
    {
        sideCollision = false;
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

    //Below is player interaction functions

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


    public void becomeDead()
    {
        alive = false;
        playerLevel++;
        Debug.Log("yay you died");
        Instantiate(prefab, GetComponent<Transform>().position, GetComponent<Transform>().rotation);
        prefab.GetComponent<SpriteRenderer>().flipX = GetComponent<SpriteRenderer>().flipX;
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
