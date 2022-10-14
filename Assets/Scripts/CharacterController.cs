using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Rigidbody rigidbody;
    public Animator animator;

    public float AccelerationSpeed = 1;
    void Start()
    {
        
    }

    
    void Update()
    {
        CheckInput();

    }
    void CheckInput(){
        if(Input.GetKey(KeyCode.Z)){

            //Debug.Log("Avancer");
            MoveForward();
        }
        else{animator.SetBool("IsWalking",false);}
        if(Input.GetMouseButtonDown(0)){
            StartCoroutine(MousePanCorout());
           
        }
        
    
    }
    void MoveForward(){
        animator.SetBool("IsWalking",true);
        Vector3 Velocity = rigidbody.velocity;
        Velocity += transform.forward * AccelerationSpeed * Time.deltaTime;
        rigidbody.velocity = Velocity;


    }
    void Turn(float Direction){
        transform.Rotate(new Vector3(0,Direction * Time.deltaTime,0));

    }
    IEnumerator MousePanCorout(){
            float MousePosX = Input.mousePosition.x;

        while(Input.GetMouseButton(0)){
            float Delta = Input.mousePosition.x - MousePosX;
            MousePosX = Input.mousePosition.x;
             
            Debug.Log(Delta);


            Turn(Delta * 5000 *Time.deltaTime);

            yield return null;


        }
    }
}
