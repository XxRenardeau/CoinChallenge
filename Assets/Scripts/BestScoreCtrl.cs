using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestScoreCtrl : MonoBehaviour
{
    public static BestScoreCtrl Instance;
    void Awake(){
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    public List<int>scores;
public static void AddScore(int score){
    Instance.scores.Add(score);
    Instance.scores.Sort();
    Instance.scores.Reverse();
}
}
