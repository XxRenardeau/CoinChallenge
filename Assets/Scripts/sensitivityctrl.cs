using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class sensitivityctrl : MonoBehaviour
{
    public static sensitivityctrl Instance;
    public Slider lautreslider;

    public float sentivity;
    public bool result;

    void Awake(){
        DontDestroyOnLoad(this.gameObject);
        if (Instance== null) {
         Instance = this;
     } else {
         Object.Destroy(gameObject);
     }
     Instance.sentivity = Instance.lautreslider.value;
    }
   public static void onchangevalue(){
    Instance.sentivity = Instance.lautreslider.value;
   }
}
