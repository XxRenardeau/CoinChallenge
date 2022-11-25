/*Property of Mining Studio (All Rights Reserved)*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCtrl : MonoBehaviour
{

    public MonoBehaviour _mono;
    public ITriggerCtrl _ITriggerCtrl;
    public Collider _collider;

    public void OnEnable()
    {

        if (_mono == null)
        {
            Debug.LogError("Mono not set on TriggerCtrl on " + this.transform.parent.gameObject.name);
            return;
        }

        _ITriggerCtrl = _mono.gameObject.GetComponent<ITriggerCtrl>();
        if (_collider == null) _collider = GetComponent<Collider>();
    }

    public void Awake() { }

    public void Start() { }


    void OnTriggerEnter(Collider _col)
    {
        if (_ITriggerCtrl == null) return;
        _ITriggerCtrl.OnTriggerCtrlEnter(_col);
    }

    void OnTriggerStay(Collider _col)
    {
        if (_ITriggerCtrl == null) return;
        _ITriggerCtrl.OnTriggerCtrlStay(_col);
    }

    void OnTriggerExit(Collider _col)
    {
        if (_ITriggerCtrl == null) return;
        _ITriggerCtrl.OnTriggerCtrlExit(_col);
    }


}

public interface ITriggerCtrl
{
    void OnTriggerCtrlEnter(Collider _col);

    void OnTriggerCtrlStay(Collider _col);

    void OnTriggerCtrlExit(Collider _col);
}
