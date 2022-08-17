using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip jump;

    private Animator animator;

    [SerializeField]
    private float jumpHeight = 5.0f;

    //First person movement

    private Vector2 moveDirection;
    private Vector3 velocity;
    [SerializeField]
    private float gravity = -9.81f;
    private CharacterController controller;
    [SerializeField]
    private float speed;
    private CameraSwitch camScript;

    private float targetAngle;

    //Third person movement

    public Transform cam;
    private Vector3 moveDir;
    private bool crouching;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    private Vector3 direction;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        camScript = FindObjectOfType<CameraSwitch>();

        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Sprint();
        Crouch();
        AnimationControls();
        TPSControls();
        //if (camScript.camSwitch)
        //{
        //    FPSControls();
        //}
        //else
        //{
        //    TPSControls();
        //}
    }

    private void FPSControls()
    {
        moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        Vector3 move = transform.right * moveDirection.x + transform.forward * moveDirection.y;

        velocity.y += gravity * Time.deltaTime;

        if (controller.isGrounded  && velocity.y < 0)
        {
            velocity.y = 0f;        
        }

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            audioSource.PlayOneShot(jump, 1);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move((move * speed * Time.deltaTime) + (velocity * Time.deltaTime));
    }

    private void TPSControls()
    {
        velocity.y += gravity * Time.deltaTime;

        if (controller.isGrounded && velocity.y < 2)
        {
            velocity.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            audioSource.PlayOneShot(jump, 1);
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, 0f, Vertical).normalized;

        //if (direction.magnitude >= 0.1f)
        //{
            targetAngle += direction.x* 200*Time.deltaTime;//Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg; //+ cam.eulerAngles.y;
            //float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            //transform.rotation = Quaternion.Euler(0f, angle, 0f);

           transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);



            //moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        //}

        //velocity.y += gravity * Time.deltaTime;
        moveDir = cam.transform.forward * direction.z; //+ cam.transform.right * direction.x;
        controller.Move(moveDir.normalized * speed * Time.deltaTime + velocity * Time.deltaTime);
    }

    private void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (crouching)
            {
                crouching = false;
            }
            else
            {
                crouching = true;
            }
        }

        if (crouching)
        {
            controller.height = 1f;
            speed = 4f;
        }
        else
        {
            controller.height = 2.0f;
            
        }
    }

    private void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift) && crouching == false)
        {
            speed = 20f;
            
        }
        else
        {
            speed = 10f;
        }
    }





    /*private void FPSControls()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * speed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }*/



    private void AnimationControls()
    {
        //if (rb.velocity.x != 0 && directions.x == 0 && isGrounded == true) isSliding = true;
        //else isSliding = false;

        //if (isSliding && isFacingRight) desireAngle = 45;
        //if (isGrounded && !isFacingRight) desireAngle = -45;

        //if (isGrounded == false)

        //if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)

        if (Input.GetKey(KeyCode.Space))          //jump
        {
            animator.SetBool("isIdling", false);
            //animator.SetBool("if crouching", false);
            animator.SetBool("if speed <= 8f", false);
            animator.SetBool("if speed >= 16f", false);
            animator.SetBool("if jumping", true);
        }

        if (direction.x == 0 && direction.z == 0 && controller.isGrounded) // idle
        {
            animator.SetBool("isIdling", true);
            //animator.SetBool("if crouching", true);
            animator.SetBool("if speed <= 8f", false);
            animator.SetBool("if speed >= 16f", false);
            animator.SetBool("if jumping", false);
        }

        if (direction.x != 0 || direction.z != 0 && controller.isGrounded) //walk ei toimiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii
        {
            animator.SetBool("isIdling", false);
            animator.SetBool("if crouching", false);
            animator.SetBool("if speed <= 8f", true);
            animator.SetBool("if speed >= 16f", false);
            animator.SetBool("if jumping", false);
        }

        if ((Input.GetKey(KeyCode.LeftShift) && crouching == false && (direction.x != 0 || direction.z != 0 && controller.isGrounded))) //run
        {
            animator.SetBool("isIdling", false);
            //animator.SetBool("if crouching", false);
            animator.SetBool("if speed <= 8f", false);
            animator.SetBool("if speed >= 16f", true);
            animator.SetBool("if jumping", false);
        }
    }
}
