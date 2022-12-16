using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class powerupcontroller : MonoBehaviour
{
    public static powerupcontroller Instance;

    public int TempsMax = 60;
    public Collider colette;
    public TextMeshProUGUI powerTxt;
    public GameObject BgPowerup;

    void Awake()
    {
        Instance = this;
    }
    void OnTriggerEnter(Collider col)
    {
        colette.enabled = false;
        if (!col.CompareTag("Player")) return;
        //Debug.Log("collision avec" + col.gameObject.name);

        Powerup();
    }
    void Powerup()
    {   //gameObject.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(false);
        Multiplicateur();
    }
    void Multiplicateur()
    {
        StartCoroutine(TempsMultiplicateur());

    }
    IEnumerator TempsMultiplicateur()
    {
        float TempsMulti = 0;
        CoinCollector.Instance.multiplicateur = 2;
        float previousecond = -1;
        BgPowerup.SetActive(true);
        while (TempsMulti < TempsMax)
        {
            float secondes = Mathf.FloorToInt((TempsMax - TempsMulti) % 60);
            TempsMulti += Time.deltaTime;
            if (secondes != previousecond)
            {
                powerTxt.text = "POWER UP! : " + secondes;
                previousecond = secondes;
            }

            yield return null;

        }
        powerTxt.text = ""; CoinCollector.Instance.multiplicateur = 1;BgPowerup.SetActive(false);
    }
    /*public void Multiscore(int coinValue)
    {
        CoinCollector.Instance.AddScore(coinValue * multiplicateurvalue);
    }*/
}
