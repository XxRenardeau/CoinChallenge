using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Rigidbody rigidbody;
    public Animator animator;
    public float JumpForce = 1;

    public float AccelerationSpeed = 1;
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Confined;
        

    }


    void Update()
    {
        CheckInput();
        Cursor.visible = false;
    }
    void CheckInput() //sers a gerer les input utilisateurs via des commandes
    {
        if (Input.GetKey(KeyCode.Z)) { MoveForward(); }
        if (Input.GetMouseButtonDown(0)) { StartCoroutine(MousePanCorout()); }
        if (Input.GetKey(KeyCode.D)) { MoveRight(); }
        if (Input.GetKey(KeyCode.S)) { MoveBack(); }
        if (Input.GetKey(KeyCode.Q)) { MoveLeft(); }
        if (Input.GetKeyDown(KeyCode.Space)) { MoveJump(); }
        if (Input.GetMouseButtonDown(1)) { Tapper(); }
        if (Input.GetMouseButtonUp(1)) { animator.SetBool("IsTapping", false); }
        if (Input.anyKey == false) { animator.SetBool("IsWalking", false); /*animator.SetBool("IsTapping", false);*/ animator.SetBool("IsJumping", false); }




    }
    void MoveForward()
    {
        animator.SetBool("IsWalking", true);
        Vector3 Velocity = rigidbody.velocity;
        Velocity += transform.forward * AccelerationSpeed * Time.deltaTime;
        rigidbody.velocity = Velocity;


    }
    void MoveRight()
    {
        animator.SetBool("IsWalking", true);
        Vector3 Velocity = rigidbody.velocity;
        Velocity += transform.right * AccelerationSpeed * Time.deltaTime;
        rigidbody.velocity = Velocity;
    }
    void MoveLeft()
    {
        animator.SetBool("IsWalking", true);
        Vector3 Velocity = rigidbody.velocity;
        Velocity -= transform.right * AccelerationSpeed * Time.deltaTime;
        rigidbody.velocity = Velocity;
    }
    void MoveBack()
    {
        animator.SetBool("IsWalking", true);
        Vector3 Velocity = rigidbody.velocity;
        Velocity -= transform.forward * AccelerationSpeed * Time.deltaTime;
        rigidbody.velocity = Velocity;
    }
    void MoveJump()
    {
        /*animator.SetBool("IsWalking", true);
        Vector3 Velocity = rigidbody.velocity;
        Velocity += transform.up * JumpForce * Time.deltaTime;
        rigidbody.velocity = Velocity;*/
        rigidbody.AddForce(Vector3.up * JumpForce);
        animator.SetBool("IsJumping", true);

    }
    void Tapper()
    {
        animator.SetBool("IsTapping", true);
    }

    void Turn(float Direction)
    {
        transform.Rotate(new Vector3(0, Direction * Time.deltaTime, 0));

    }
    IEnumerator MousePanCorout()
    {
        float MousePosX = Input.mousePosition.x;

        while (Input.GetMouseButton(0))
        {
            float Delta = Input.mousePosition.x - MousePosX;
            MousePosX = Input.mousePosition.x;

            //Debug.Log(Delta);


            Turn(Delta * 5000 * Time.deltaTime);

            yield return null;


        }
    }
}
//physic.spherecast 
