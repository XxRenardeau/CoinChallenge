using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverCtrl : MonoBehaviour
{
    public bool IsGameOver = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TimeGameOver();
        //Debug.Log(TimeController.ControlTemps.isTimeRunOut);
    }
    public void OnGameOver()
    {
        if (IsGameOver)
        {
            gameObject.SetActive(true);
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
                Debug.Log("boucle");
            } //PROBLEME DE BOUCLE INFINIE TROUVER SOLUTION
            Debug.Log("TEST DE LA FONCTION");
            Cursor.visible = true;
        }
         


    }
    public void TimeGameOver()
    {
        if (TimeController.ControlTemps.isTimeRunOut)
        {
            IsGameOver = true;
            OnGameOver();
        }
    }
    public void GameOverRestart()
    {
    }
    public void Quit()
    {
        Application.Quit();
    }

    public Collider col;

    void OnTriggerEnter(Collider col)
    {
        if (!col.CompareTag("Player")) return;
        Debug.Log("collision avec" + col.gameObject.name);
        IsGameOver = true;
        OnGameOver();
    }
}

