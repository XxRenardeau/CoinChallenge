using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{

    public LayerMask ground;
    public bool isGrounded;
    public RaycastHit raycastHit;
    Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        //ray = new Ray(transform.position,Vector3.down);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(transform.position , 0.5f,ground);
        /*Physics.Raycast(ray,out raycastHit,0.15f,ground);
        Debug.DrawRay(transform.position,Vector3.down,Color.yellow,0.15f);
        isGrounded = raycastHit.collider!=null;*/
       //Debug.Log(raycastHit.collider.name);
        
        
    }
}
