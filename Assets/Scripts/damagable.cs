using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagable : MonoBehaviour
{
    public delegate void Onkill(damagable damagable);
    public bool isAlive{
        get{
            return currentHealth>0;
        }
    }
    public Onkill onkill;
    public int maxhHealth;
    int currentHealth;
    public void Start(){
        currentHealth = maxhHealth;
    }
    public void SetDamage(int damage){
        currentHealth -=damage;
        if (currentHealth<0)currentHealth=0;
        if (onkill!=null){
            onkill(this);
        }

    }

}
