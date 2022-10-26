using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverCtrl : MonoBehaviour
{
    public static GameOverCtrl instance;
    public bool IsGameOver = false;
    public delegate void OnGameOverDel();
    public OnGameOverDel onGameOverDel;

    void Awake()
    {

        instance = this;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(TimeController.ControlTemps.isTimeRunOut);
    }
    public void GameOverRestart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public static void SetGameOver(){
        if(instance.IsGameOver) return;
        instance.IsGameOver = true;
         instance.gameObject.SetActive(true);
            for (int i = 0; i < instance.transform.childCount; i++)
            {
                instance.transform.GetChild(i).gameObject.SetActive(true);
                
            }
            Cursor.visible = true;
          if (instance.onGameOverDel != null) instance.onGameOverDel();




    }

}

