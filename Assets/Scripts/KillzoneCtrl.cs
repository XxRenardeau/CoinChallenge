using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillzoneCtrl : MonoBehaviour
{
    public Transform respawn;
    public GameObject hero;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider col)
    {
        if (!col.CompareTag("Player")) return;
        Debug.Log("collision avec" + col.gameObject.name);
        hero.transform.position = respawn.position;
    }
}
