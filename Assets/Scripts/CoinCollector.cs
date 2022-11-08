using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollector : MonoBehaviour
{
    public static CoinCollector Instance;
    public int score = 0;
    public int multiplicateur = 1;
    public float tempspowerup = 0;
    public TextMeshProUGUI scoreTxt;

    void Awake()
    {
        Instance = this;
    }
    void Start(){
        UpdateScoreValue();
    }
    public void AddScore(int coinValue)
    {
        score += (coinValue * multiplicateur);
        Debug.Log(score);
        UpdateScoreValue();
    }
    void UpdateScoreValue()
    {
        scoreTxt.text = "Score : " + score;

    }
   public void AddHighscoreded(){
        
        BestScoreCtrl.Instance.testScore();
    }
    

}
