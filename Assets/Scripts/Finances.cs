using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Finances : MonoBehaviour
{
    public string financialStatus = "ambiguous" ;
    public GameObject lifeInsurance;
    public GameObject Tax;
    public GameObject textObject;

    private void Update()
    {
       if (GetComponent<PlayerRespawn>().respawning)
       {
            financialStatus = "ambiguous";
            EnablePowerUps();
            textObject.GetComponent<TextMeshProUGUI>().SetText("Financially Ambiguous"); // this is base financial state
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Life Insurance")
        {
            financialStatus = "wealthy";
            textObject.GetComponent<TextMeshProUGUI>().SetText("Insured"); // this will pass through son
            DisablePowerUps();

        }
        if (collision.gameObject.name == "Tax")
        {
            financialStatus = "poor";
            textObject.GetComponent<TextMeshProUGUI>().SetText("Taxed to Oblivion"); // fourth hidden death condition
            DisablePowerUps();
        }
    }

    void DisablePowerUps()
    {
        lifeInsurance.SetActive(false);
        Tax.SetActive(false);
    }
    void EnablePowerUps()
    {
        lifeInsurance.SetActive(true);
        Tax.SetActive(true);
    }
}
