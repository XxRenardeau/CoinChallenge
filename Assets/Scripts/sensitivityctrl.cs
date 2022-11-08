using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sensitivityctrl : MonoBehaviour
{
    public static sensitivityctrl Instance;
    public TMP_InputField inputfield;

    public int sentivity;
    public bool result;

    void Awake(){
        DontDestroyOnLoad(this.gameObject);
        if (Instance== null) {
         Instance = this;
     } else {
         Object.Destroy(gameObject);
     }
    }
   public static void onchangevalue(){
    Instance.IsNumeric();
    if(!Instance.result){Instance.sentivity = 0;}
    if(Instance.inputfield.text == null){Instance.sentivity = 0;}
    else
   // Debug.Log(Instance.sentivity);
   // Debug.Log(Instance.inputfield.text);
    Instance.sentivity = int.Parse(Instance.inputfield.text);
    //Debug.Log(Instance.sentivity);
    //Debug.Log(Instance.inputfield.text);

   }
   public void IsNumeric()
    {
        int number;
        result = int.TryParse(Instance.inputfield.text, out number);
    }
    
}
