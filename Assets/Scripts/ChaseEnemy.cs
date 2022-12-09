using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseEnemy : MonoBehaviour
{
    public damagable damagable;
    public Rigidbody rb;
    public float speed = 10;
    float playerdist
    {
        get
        {
            return Vector3.SqrMagnitude(Player.transform.position - transform.position);
        }
    }
    GameObject Player;
    public void OnTriggerEnter(Collider col)
    {
        if (!col.CompareTag("Player")) return;
        Player = col.transform.root.gameObject;
        StartCoroutine(ChaseCorout());

    }
    IEnumerator ChaseCorout()
    {
        Vector3 postemp;
        while (playerdist<250f&& damagable.isAlive)
        {
            yield return null;
            postemp = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
            postemp.y = transform.position.y;
            rb.MovePosition(postemp);
            postemp = Player.transform.position;
            postemp.y = transform.position.y;
            transform.LookAt(postemp);
            //Debug.Log(playerdist);
            //if (playerdist<10f){damagable.SetDamage(2);}
        }


    }
}

