using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Rigidbody rigidbody;
    public Animator animator;
    public float JumpForce = 1;
    public bool isCameraPaning;
    float MousePosX;
    bool isGrounded
    {
        get
        {
            return groundDetection.isGrounded;
        }
    }
    public GroundDetection groundDetection;
    //public Collider sol;


    public float AccelerationSpeed = 1;
    void Start()
    {
        MousePosX = Input.mousePosition.x;
        StartCoroutine(CheckInputCorout());
        
        Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Confined;


    }


    IEnumerator CheckInputCorout(){
        while(!GameOverCtrl.instance.IsGameOver){
            CheckInput();
            animator.SetBool("IsJumping", !isGrounded);
            yield return null;            
        }
    }
    void CheckInput() //sers a gerer les input utilisateurs via des commandes
    {
        MousePan();
        if (Input.GetKey(KeyCode.Z)) { MoveForward(); }
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
        if (isGrounded)
        {
            rigidbody.AddForce(Vector3.up * JumpForce);
            
        }

    }
    void Tapper()
    {
        animator.SetBool("IsTapping", true);
    }

    void Turn(float Direction)
    {
        transform.Rotate(new Vector3(0, Direction * Time.deltaTime, 0));

    }
    /*void OnTriggerEnter()
    {
       if (!sol.CompareTag("Ground")){isGrounded = true; Debug.Log("JE TOUCHE LE SOL");}
       else {isGrounded = false; Debug.Log("CA MARSH PA");}
        
    }*/
    void MousePan()
    {
        isCameraPaning = true;
        
        float Delta = Input.mousePosition.x - MousePosX;
        MousePosX = Input.mousePosition.x;
        Turn(Delta * 5000 * Time.deltaTime);
        isCameraPaning = false;
    }
}
//physic.spherecast 
