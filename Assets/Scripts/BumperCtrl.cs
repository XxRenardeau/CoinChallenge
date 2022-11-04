using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperCtrl : MonoBehaviour
{
    public AudioSource audioSource;
    public float force = 1000;
    //void Awake(){ BumperRigidbody = CharacterController.rigidbody;}

    void OnTriggerEnter(Collider col)
    {
        if (!col.CompareTag("Player")) return;
        Bump(col);
        Debug.Log("collision champignon avec" + col.gameObject.name);


    }
    void Bump(Collider col)
    {
        audioSource.Play();
        Rigidbody playerrigidbody = col.transform.root.GetComponent<Rigidbody>();
        playerrigidbody.AddForce(0f, force, 0f);
    }


}
