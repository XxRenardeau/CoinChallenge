/*using System.Collections;
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
    public AudioSource audioSource;
    public int sentivité = 6400;
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
    /*void Awake()
    {

    }
    void Start()
    {

        if (Application.systemLanguage == SystemLanguage.French) { StartCoroutine(CheckInputCoroutFR()); }
        else
        {
            StartCoroutine(CheckInputCoroutUS());

        }
        MousePosX = Input.mousePosition.x;


        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;


    }


    IEnumerator CheckInputCoroutUS()
    {
        while (!GameOverCtrl.instance.IsGameOver)
        {
            CheckInputUs();
            animator.SetBool("IsJumping", !isGrounded);
            yield return null;
        }
    }
    IEnumerator CheckInputCoroutFR()
    {
        while (!GameOverCtrl.instance.IsGameOver)
        {
            CheckInputFr();
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
            //Debug.Log("gravité");
            Velocity = rigidbody.velocity;
            Velocity.y -= gravite * Time.deltaTime;
            if (Velocity.y < maxFallSpeed) Velocity.y = maxFallSpeed;
            rigidbody.velocity = Velocity;


            yield return null;
        }
    }
    void CheckInputFr() //sers a gerer les input utilisateurs via des commandes
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
        if (Input.anyKey == false) { animator.SetBool("IsWalking", false); animator.SetBool("IsJumping", false); }




    }
    void CheckInputUs() //sers a gerer les input utilisateurs via des commandes
    {
        MousePan();
        if (Input.GetKey(KeyCode.W)) { MoveForward(); }
        if (Input.GetKey(KeyCode.D)) { MoveRight(); }
        if (Input.GetKey(KeyCode.S)) { MoveBack(); }
        if (Input.GetKey(KeyCode.A)) { MoveLeft(); }
        if (Input.GetKeyDown(KeyCode.Space)) { MoveJump(); }
        if (Input.GetMouseButtonDown(1)) { Tapper(); }
        //if (Input.GetKey(KeyCode.X)) { MoveSprint(); }
        if (Input.GetMouseButtonUp(1)) { animator.SetBool("IsTapping", false); }
        if (Input.anyKey == false) { animator.SetBool("IsWalking", false);  animator.SetBool("IsJumping", false); }




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
            audioSource.Play();
            StartCoroutine(Gravity());

        }

    }

    void Tapper()
    {
        animator.SetBool("IsTapping", true);
    }

    void Turn(float Direction)
    {
        transform.Rotate(new Vector3(0, Direction * Time.deltaTime, 0));

    

    void MousePan()
    {
        isCameraPaning = true;

        float Delta = Input.mousePosition.x - MousePosX;
        MousePosX = Input.mousePosition.x;
        //sentivité = sensitivityctrl.Instance.sentivity * 100;

        Turn(Delta * sentivité * Time.deltaTime);
        isCameraPaning = false;
    }
}*/
//physic.spherecast 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    Vector3 playerMvtInput;
    Vector3 playerMouseInput;

    [SerializeField] Rigidbody rb;
    [SerializeField] Transform _pied;
    [SerializeField] LayerMask _mask = 8;

    [SerializeField] float speed = 10;
    //[SerializeField] float sensivity = 3;
    float sensivity
    {
        get
        {
            if (sensitivityctrl.Instance != null) { return sensitivityctrl.Instance.sentivity; }
            return 3f;
        }
    }
    [SerializeField] float jumpforce = 250;
    [SerializeField] Animator animator;
    public AudioSource audioSource;
    float xRot;
    public bool playercontrol = true;
    public int damage = 1;
    public Transform epee;
    public LayerMask Ennemies;
    Coroutine attaquecorout;

    private void Start()
    {


        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        Vector3 _gravity = Physics.gravity;
        _gravity.y = -9.81f * 3;
        Physics.gravity = _gravity;
    }

    // Start is called before the first frame update
    void Update()
    {

        playerMvtInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        playerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        MovePlayer();
        MovePlayerCamera();
    }

    void MovePlayer()
    {
        Vector3 moveVector = transform.TransformDirection(playerMvtInput * speed);
        rb.velocity = new Vector3(moveVector.x, rb.velocity.y, moveVector.z);

        animator.SetBool("IsRunning", moveVector != Vector3.zero);

        bool _isGrounded = IsGrounded();

        animator.SetBool("IsJumping", !_isGrounded);
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {

            if (!animator.GetBool("Attack") && attaquecorout == null)
            {
                animator.SetBool("Attack", true);
                attaquecorout = StartCoroutine(attaqueepee());

            }




        }


        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            audioSource.Play();
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }





    }

    void MovePlayerCamera()
    {
        xRot -= playerMouseInput.y * sensivity;
        transform.Rotate(0f, playerMouseInput.x * sensivity, 0f);

    }

    bool IsGrounded()
    {
        return Physics.Raycast(_pied.position, Vector3.down, 1, _mask);
    }
    IEnumerator attaqueepee()
    {
        yield return new WaitForSeconds(0.15f);
        int number = Physics.OverlapSphereNonAlloc(epee.position, 0.4f, colliders, Ennemies);
        damagable dam;
        for (int i = 0; i < number; i++)
        {
            dam = colliders[i].transform.parent.GetComponent<damagable>();
            if (dam == null)
            {
                continue;
            }
            dam.SetDamage(damage);

        }
        attaquecorout = null;

    }
    Collider[] colliders = new Collider[10];

}
