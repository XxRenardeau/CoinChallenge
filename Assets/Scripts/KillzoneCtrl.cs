using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillzoneCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider col)
    {
        if (!col.CompareTag("Player")) return;
        Debug.Log("collision avec" + col.gameObject.name);
        GameOverCtrl.SetGameOver();
    }
}
