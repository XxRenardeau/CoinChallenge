using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Rigidbody rigidbody;
    public Animator animator;
    public float JumpForce = 1;
    public bool isCameraPaning;
    public float gravite; 
    public float maxFallSpeed = -1000;
    float MousePosX;
    public float maxVitesse = 500f;
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
        //Cursor.lockState = CursorLockMode.Locked;


    }


    IEnumerator CheckInputCorout()
    {
        while (!GameOverCtrl.instance.IsGameOver)
        {
            CheckInput();
            animator.SetBool("IsJumping", !isGrounded);
            yield return null;
        }
    }
    IEnumerator Gravity()
    {
        yield return new WaitForSeconds(0.35f);
        Vector3 Velocity;
        while (!isGrounded)
        {
            Debug.Log("gravité");
            Velocity = rigidbody.velocity;
            Velocity.y -= gravite *Time.deltaTime;
            if (Velocity.y <maxFallSpeed) Velocity.y = maxFallSpeed;
            rigidbody.velocity = Velocity;


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
        //if (Input.GetKey(KeyCode.X)) { MoveSprint(); }
        if (Input.GetMouseButtonUp(1)) { animator.SetBool("IsTapping", false); }
        if (Input.anyKey == false) { animator.SetBool("IsWalking", false); /*animator.SetBool("IsTapping", false);*/ animator.SetBool("IsJumping", false); }




    }
    void MoveForward()
    {
        animator.SetBool("IsWalking", true);
        Vector3 Velocity = rigidbody.velocity;
        if (rigidbody.velocity.magnitude > maxVitesse)
        {
            rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxVitesse);
        }
        else
            Velocity += transform.forward * AccelerationSpeed * Time.deltaTime;
        rigidbody.velocity = Velocity;


    }
    void MoveRight()
    {
        animator.SetBool("IsWalking", true);
        Vector3 Velocity = rigidbody.velocity;
        if (rigidbody.velocity.magnitude > maxVitesse)
        {
            rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxVitesse);
        }
        else
            Velocity += transform.right * AccelerationSpeed * Time.deltaTime;
        rigidbody.velocity = Velocity;
    }
    void MoveLeft()
    {
        animator.SetBool("IsWalking", true);
        Vector3 Velocity = rigidbody.velocity;
        if (rigidbody.velocity.magnitude > maxVitesse)
        {
            rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxVitesse);
        }
        else
            Velocity -= transform.right * AccelerationSpeed * Time.deltaTime;
        rigidbody.velocity = Velocity;
    }
    void MoveBack()
    {
        animator.SetBool("IsWalking", true);
        Vector3 Velocity = rigidbody.velocity;
        if (rigidbody.velocity.magnitude > maxVitesse)
        {
            rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxVitesse);
        }
        else
            Velocity -= transform.forward * AccelerationSpeed * Time.deltaTime;
        rigidbody.velocity = Velocity;
    }
    void MoveJump()
    {
        if (isGrounded)
        {
            rigidbody.AddForce(Vector3.up * JumpForce);
            StartCoroutine(Gravity());

        }

    }
    /* void MoveSprint()
     {
         if (Input.GetKeyUp(KeyCode.X))
         {
             AccelerationSpeed = 10;
             maxVitesse = 500;
             animator.SetBool("IsSprinting", false);
         }
         if (Input.GetKeyDown(KeyCode.X))
         {
             AccelerationSpeed = 15;
             maxVitesse = 650;
             animator.SetBool("IsSprinting", true);
         }

     }*/

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
        Turn(Delta * 12500 * Time.deltaTime);
        isCameraPaning = false;
    }
}
//physic.spherecast 
