using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject player;
    public AudioClip park_ambient;// for start
    public AudioClip park_beats; // once we get rolling
    private int changeIndex = 0;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = park_ambient;
        audioSource.Play();
    }
    void Update()
    {
        if (player.GetComponent<PlayerLevelling>().playerLevel >= 2 && changeIndex < 1)  // we want to change when the rock drops and then loop the track. 
        {
            ChangeMusic();
            changeIndex++;
        }
    }
    public void ChangeMusic()
    {
        audioSource.clip = park_beats;
        audioSource.Play();
    }
}
