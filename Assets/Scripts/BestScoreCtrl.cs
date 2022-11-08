using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestScoreCtrl : MonoBehaviour
{
    public static BestScoreCtrl Instance;
    //public int highscore = 0;
    void Awake(){
        DontDestroyOnLoad(this.gameObject);
        if (Instance== null) {
         Instance = this;
     } else {
         //DestroyObject(gameObject)
         Object.Destroy(gameObject);
     }
    }
    public List<int>scores;
public static void AddScore(int score){
    Instance.scores.Add(score);
    Instance.scores.Sort();
    Instance.scores.Reverse();
    //Instance.highscore = Instance.scores[0];
}
public void testScore(){
    int testScore = 0;
    testScore= CoinCollector.Instance.score;
    AddScore(testScore);
    testScore = 0;
}
}
