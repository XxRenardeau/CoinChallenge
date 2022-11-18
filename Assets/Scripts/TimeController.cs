using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    public TimeController ControlTemps;
    public float tempsrestant = 300;
    public TextMeshProUGUI tempsTXT;
    public bool isTimeRunOut;
    public System.Action OnTimeRunOut;
    void Awake()
    {
        ControlTemps = this;
    }
    void Start()
    {
        StartCoroutine(ChronoCorout());

    }
    IEnumerator ChronoCorout()
    {
        while (tempsrestant >= 0)
        {
            float minutes = Mathf.FloorToInt(tempsrestant / 60);
            float secondes = Mathf.FloorToInt(tempsrestant % 60);
            if (tempsrestant >= 0)
            {
                tempsrestant -= Time.deltaTime;
                tempsTXT.text = "Temps restant " + minutes + ":" + secondes;

            }
            yield return null;
        }
        Debug.Log("TEMPS ECOULE"); 
        GameOverCtrl.SetGameOver();
    }

}
