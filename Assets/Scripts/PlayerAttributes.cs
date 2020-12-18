using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public bool jumpStatus = false;
    public bool breakStatus = false;
    public float jumpHeight = 5f;
    public float moveSpeed = 5f;
    public bool currentlyBreaking = false;
    public GameObject brickBreakable;
    
    Rigidbody2D rb;
    
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
        //y movement
        if (rb.velocity.y == 0 & sideCollision == false)
            onGround = true;
        else
            onGround = false;

        if (onGround)
            dblJump = true;

        if (onGround && Input.GetButtonDown("Jump") && jumpStatus) // check on ground and if jump level reached
        {
            Jump();
        }
        else if (dblJump && Input.GetButtonDown("Jump") && jumpStatus) // check for double jump and if jump level reached
        {
            Jump();
            dblJump = false;
        }

        // x movement
        dirX = Input.GetAxis("Horizontal") * moveSpeed; // x axis movement
        FlipSprite(dirX);
        if (rb.velocity.y <= 0.01 && rb.velocity.y >= -0.01 && rb.velocity.x <= 0.01 && rb.velocity.x >= -0.01) //smooth gravity a bit and enable other scripts
        {
            rb.velocity = Vector2.zero;
        }

        //breaking
        if (Input.GetKeyDown(KeyCode.E) && breakStatus)
        {
            breakSomething();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (currentlyBreaking)
        {
            if (collision.gameObject.name == "brickBreakable")
            {
                collision.gameObject.SetActive(false);
            }
        }
    }

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
        sideCollision = true; // collider will pass to this
        
    }

    public void CollisionDetectedBox(BoxCol BoxCollision)
    {
        sideCollision = false; // collider will pass to this
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

    void breakSomething() // used when break is gained. tilts model forward and breaks
    {
        float breakMultip = -1;
        if (GetComponent<SpriteRenderer>().flipX)
        {
            breakMultip = 1;
        }
        GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, -45* breakMultip);
        GetComponent<Transform>().position += new Vector3(0.2f * breakMultip, 0.01f * breakMultip, 0);
        currentlyBreaking = true;
        StartCoroutine(WaitBreak());
    }

    IEnumerator WaitBreak()
    {
        yield return new WaitForSeconds(0.3f);
        currentlyBreaking = false;
        GetComponent<Transform>().rotation = new Quaternion(0, 0, 0, 0); // reset
    }
 
}
