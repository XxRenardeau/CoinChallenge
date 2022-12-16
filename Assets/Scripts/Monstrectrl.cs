using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Monstrectrl : MonoBehaviour
{
    public damagable damagable;
    public Rigidbody rb;
    public int Knockback;
    public void Start(){
        rb = GetComponent<Rigidbody>();
        damagable.onkill = onkill;
        damagable.ondamage = ondamage;
    }
    public void onkill(damagable damagable){
        gameObject.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        //Debug.Log("je suis mort");

    }
    public void ondamage(damagable damagable){
        Vector3 dir = -transform.forward;
        dir.y = 2;
        rb.AddForce(dir*Knockback,ForceMode.Impulse); 
    }

}
