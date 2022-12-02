using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstrectrl : MonoBehaviour
{
    public damagable damagable;
    public void Start(){
        damagable.onkill = onkill;
    }
    public void onkill(damagable damagable){
        Debug.Log("je suis mort");

    }
}
