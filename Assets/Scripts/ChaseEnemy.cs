using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseEnemy : MonoBehaviour
{
    public damagable damagable;
    public Rigidbody rb;
    public float speed = 10;
    public Transform tete;
    float playerdist
    {
        get
        {
            return Vector3.SqrMagnitude(Player.transform.position - transform.position);
        }
    }
    [SerializeField]private NavMeshAgent agent;
    GameObject Player;
    public void OnTriggerEnter(Collider col)
    {
        if (!col.CompareTag("Player")) return;
        Player = col.transform.root.gameObject;
        
        StartCoroutine(ChaseCorout());

    }
    IEnumerator ChaseCorout()
    {   agent.SetDestination(Player.transform.position);
        while ( damagable.isAlive)
        {
            yield return null;
            Vector3 playerpostemp = Player.transform.position;
            playerpostemp.y = tete.position.y;
            tete.LookAt(playerpostemp);
            agent.SetDestination(Player.transform.position);
        }


    }
}

