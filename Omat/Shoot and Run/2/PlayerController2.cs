using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    [SerializeField]
    private float movementSpeed = 6;

    [SerializeField]
    private Vector2 directions;

    private Vector2 refVelocity;

    [SerializeField]
    private Transform circleOrigin;

    [SerializeField]
    private float circleRadius = 0.2f;

    [SerializeField]
    private bool isGrounded;

    [SerializeField]
    private bool isFacingRight;
    private bool isSliding;

    private float desireAngle;

    private float currentVel;

    private Vector3 originalScale; // jos pelaaja scaalaa on muutettu, t‰m‰ est‰‰ ett‰ se ei muutu pieneksi
                                   // muutettu skaalausta varten


    private Camera mainCamera;
    private float targetAngle;


    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(circleOrigin.position, circleRadius);
    }

    private void GroundCheck()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(circleOrigin.position, circleRadius);
        isGrounded = false;
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != this.gameObject)
            {
                isGrounded = true;
            }
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        originalScale = transform.localScale;// muutettu skaalausta varten
    }

    private void Update()
    {
        Controls();
        GroundCheck();
        AnimationControls();
        FlipSprite();
        //MouseControls();
    }

    private void Controls()
    {
        directions.x = Input.GetAxis("Horizontal");
        directions.y = Input.GetAxis("Vertical");
        directions.Normalize();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            Jump();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (rb.velocity.y > -1) rb.velocity = new Vector2(rb.velocity.x, -1);
        }
    }




    private void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(directions.x * movementSpeed, rb.velocity.y);
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref refVelocity, 0.3f);
        rb.rotation = Mathf.SmoothDamp(0, desireAngle, ref currentVel, 0.1f);
    }

    //private void MouseControls()
    //{
    //    Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
    //    Vector3 mouseDirection = mousePosition - transform.position;
    //    targetAngle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg;
    //}

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 10);
    }

    private void FlipSprite()
    {
        if (directions.x > 0) // && !isFacingRight)
        {
            //transform.localScale = new Vector3(1, 1, 1);
            transform.localScale = originalScale;// muutettu skaalausta varten
            isFacingRight = true;// muutettu skaalausta varten    
            //Flip()  
        }

        if (directions.x < 0) // && isFacingRight)
        {
            //transform.localScale = new Vector3(-1, 1, 1);
            transform.localScale = new Vector3(-originalScale.x, transform.localScale.y, transform.localScale.z);// muutettu skaalausta varten
            isFacingRight = false;  // muutettu skaalausta varten  
            //Flip(); 
        }
    }

    private void AnimationControls()
    {
        if (rb.velocity.x != 0 && directions.x == 0 && isGrounded == true) isSliding = true;
        else isSliding = false;

        //if (isSliding && isFacingRight) rb.rotation = 45;
        //if (isGrounded &&  !isFacingRight) rb.rotation = -45;
        if (isSliding && isFacingRight) desireAngle = 45;
        if (isGrounded && !isFacingRight) desireAngle = -45;
        //if (isSliding) rb.rotation = 0;

        if (isGrounded == false)
        {
            animator.SetBool("IsIdling", false);
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsJumping", true);
        }

        else if (directions.x == 0 && directions.y == 0)
        {
            animator.SetBool("IsIdling", true);
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsJumping", false);
        }

        else
        {
            animator.SetBool("IsIdling", false);
            animator.SetBool("IsRunning", true);
            animator.SetBool("IsJumping", false);
        }
    }
}
