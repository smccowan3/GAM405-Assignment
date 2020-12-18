using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerRespawn : MonoBehaviour
{
    public bool alive = true;
    public GameObject prefab;
    public GameObject rock;
    private GameObject spawnedPrefab;
    public Vector3 startingPosition;
    public bool respawning = false; // we will use this to reset other object
    public int [] usedDeaths = new int [5];  // stores unique deaths already used
    public GameObject textObject; //for tab to respawn spawner
    public TextMeshProUGUI text;

    void Awake()
    {
        text= textObject.GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        startingPosition = GetComponent<Transform>().position;
    }
    void Update()
    {
        if (alive == false && GetComponent<PlayerLevelling>().playerLevel <=5)
        {
            TextDisplay(); // display gui for tab to respawn
            Respawn();
            StartCoroutine(WaitRespawn());
        }
        else if (alive && GetComponent<PlayerLevelling>().playerLevel <= 5)
        {
            TextHide();
        }
    }
    public void becomeDead(int deathID)
    {
        checkDeath(deathID);
        alive = false;
        Vector3 currPosition = GetComponent<Transform>().position;
        Quaternion currRotation = GetComponent<Transform>().rotation;
        spawnedPrefab = Instantiate(prefab, currPosition, currRotation); // dead body
        prefab.GetComponent<SpriteRenderer>().flipX = GetComponent<SpriteRenderer>().flipX;
        GetComponent<SpriteRenderer>().enabled = false; // alive body goes invisible
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll; // and doesnt move
    }

    public void checkDeath(int deathID)
    {
        bool isUsed = false;
        for (int i = 0; i< 5; i++)
        {
            int CurrID = usedDeaths[i];
            if (CurrID == deathID)
            {
                isUsed = true;
            }
        }
        if (isUsed == false)
        {
            GetComponent<PlayerLevelling>().playerLevel++;
            usedDeaths[deathID-1] = deathID;
        }
    }

    public void Respawn()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) // space to continue
        {
            respawning = true;
            StartCoroutine(WaitpreFab()); // wait and destroy
            GetComponent<Transform>().position = startingPosition + new Vector3(0, 4, 0); // initial spawn position
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation; // set player obj static and invisible
            alive = true; // player is now reset
        }
    }

    IEnumerator WaitpreFab()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(spawnedPrefab);
    }
    IEnumerator WaitRespawn()
    {
        yield return new WaitForSeconds(1); // wait is required for other objects to reset
        respawning = false;
    }
    void TextDisplay()
    {
        textObject.SetActive(true);
    }
    void TextHide()
    {
        textObject.SetActive(false);
    }

}
