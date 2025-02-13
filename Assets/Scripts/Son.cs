﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Son : killingObject
{
    public GameObject speechBubble;
    public GameObject textObject;
    public TextMeshProUGUI text;
    public Rigidbody2D rb;
    void Awake()
    {
        deathCode = 3;
        speechBubble = GameObject.Find("speech bubble"); // set up objects at runtime
        speechBubble.GetComponent<SpriteRenderer>().enabled = false;
        textObject = GameObject.Find("Son words");
        text = textObject.GetComponent<TextMeshProUGUI>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        DetectRespawn();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "PlayerObject")
        {
            speechBubble.GetComponent<SpriteRenderer>().enabled = true;
            if (collision.gameObject.GetComponent<Finances>().financialStatus == "ambiguous")
            {
                text.SetText("I hate you dad");
                player.GetComponent<PlayerRespawn>().becomeDead(deathCode); // kill
            }
            else if (collision.gameObject.GetComponent<Finances>().financialStatus == "poor")
            {
                text.SetText("I still hate you dad");
                player.GetComponent<PlayerRespawn>().becomeDead(deathCode + 1); // kill 
            }
            else if (collision.gameObject.GetComponent<Finances>().financialStatus == "wealthy")
            {
                text.SetText("I love you dad");
                DisableBody();
            }
                
        }
    }

    void DetectRespawn()
    {
        if (player.GetComponent<PlayerRespawn>().respawning)
        {
            speechBubble.GetComponent<SpriteRenderer>().enabled = false;
            text.SetText("");
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            rb.isKinematic = false;
        }
    }
    void DisableBody()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

}
