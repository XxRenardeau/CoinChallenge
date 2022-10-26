using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    public static TimeController ControlTemps;
    public float tempsrestant = 300;
    public TextMeshProUGUI tempsTXT;
    public bool isTimeRunOut;
    void Awake(){
        ControlTemps = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Temps();
        if (tempsrestant<=0){ Debug.Log("TEMPS ECOULE");isTimeRunOut = true;}      

    }
    public void Temps()
    {
        float minutes = Mathf.FloorToInt(tempsrestant / 60);
        float secondes = Mathf.FloorToInt(tempsrestant % 60);
        if (tempsrestant >= 0)
        {
            tempsrestant -= Time.deltaTime;
            tempsTXT.text = "Temps restant : " + minutes +" : " + secondes;

        }
    }

}
