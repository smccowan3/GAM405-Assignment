using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLevelling : MonoBehaviour
{
    public int playerLevel = 1;
    public GameObject LevelTextObject;
    public TextMeshProUGUI LevelText;
    public GameObject nxtPowerUpObject;
    public GameObject victoryScreen;
    public TextMeshProUGUI nxtPowerUp;
    

    private void Awake()
    {
        LevelText = LevelTextObject.GetComponent<TextMeshProUGUI>(); // bottom right text
        nxtPowerUp = nxtPowerUpObject.GetComponent<TextMeshProUGUI>(); // middle text
    }

    void Update()
    {
        LevelUpAbilities(); // this is the new abilities you gain
        DisplayAbilities();
        if (playerLevel >= 6)
        {
            victoryScreen.SetActive(true); // for the win
        }

    }

    void LevelUpAbilities()
    {
        if (playerLevel >= 2)
        {
            
            GetComponent<PlayerAttributes>().jumpStatus = true;
        }   
        if (playerLevel >= 5)
        {
            GetComponent<PlayerAttributes>().breakStatus = true;
        }
    }
    void DisplayAbilities()
    {
        LevelText.SetText("Unique Deaths: " + (playerLevel -1));
        if(playerLevel == 1)
        {
            nxtPowerUp.SetText("Current Power Ups: None" + "\n" + "Next: 1 Unique Death (Jumping)");
        }
           
        else if (playerLevel >= 2 && playerLevel < 4)
        {
            nxtPowerUp.SetText("Current Power Ups: Jumping. Press Space" + "\n" + "Next: 4 Unique Deaths (Break Walls)");
        }
        else if (playerLevel >=5)
        {
            nxtPowerUp.SetText("Current Power Ups: Jumping and Breaking" + "\n" + "Press E to break");
        }
    }
}
