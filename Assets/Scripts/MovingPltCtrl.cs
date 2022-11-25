using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPltCtrl : MonoBehaviour, ITriggerCtrl
{
    public bool IsLooping;
    public int NmbrLoop; //0 is error
    public float Endpointx;
    public float Endpointz;
    public float Endpointy;
    bool collided = false;
    public Transform depart;
    public Transform arrivee;
    public Transform plateforme;
    float elapsedTime;
    public float speed;
    float t = 0f;
    void FixedUpdate()
    {
        MovingPlatform();
    }
    void OnTriggerEnter(Collider col)
    {
    }
    void OnTriggerExit(Collider col)
    {

    }
    void MovingPlatform()
    {
        if (!collided) return;
        elapsedTime += Time.deltaTime * speed;
        float sin = Mathf.Abs(Mathf.Sin(elapsedTime));
        plateforme.position = Vector3.Lerp(depart.position, arrivee.position, sin);

    }

    public void OnTriggerCtrlEnter(Collider _col)
    {
        if (!_col.CompareTag("Player")) return;
        Debug.Log("collision nuage avec" + _col.gameObject.name);
        _col.transform.root.SetParent(plateforme);
        collided = true;

    }

    public void OnTriggerCtrlStay(Collider _col)
    {

    }

    public void OnTriggerCtrlExit(Collider _col)
    {
        if (!_col.CompareTag("Player")) return;
        Debug.Log("je suis parti");
        _col.transform.SetParent(null);

    }
}
