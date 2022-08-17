using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Movement Values")]
    [SerializeField] [Range(1,30)]
    private float moveSpeed = 15;
    [SerializeField] [Range(1, 30)]
    private float jumpVelocity = 11;
    

    [SerializeField] private LayerMask Platforms2;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2d;

    //private bool IsGrounded;
    private bool m_FacingRight = true; //m‰‰ritell‰‰n sprite suunta

    private void Awake()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }


    // Hyppiminen
    private void Update()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            
            rb.velocity = Vector2.up * jumpVelocity;
        }
        HandleMovement();
    }

    //Lattian tunnistus (hyppy toimii vain kerran), pelaajasta l‰htee s‰detunnistus joka tonnistaa kaikki Layer "Platforms2"
    //BoxCast(Verctor2 origin_ s‰teen l‰htˆkohta, Vector2 Size_koko, float_angle_kulma lukuna, Vector2 direction_vektorin suunta, float distance_ et‰isyys lukuna, int layerMask) 7 lis‰arvoa
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, 1f, Platforms2);
        Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null; //Tunnistus toimii pelaajan ollessa ilmassa ja != null est‰ lis‰hypyt
    }


    //Liikkuminen oikealle ja vasemmalle
    private void HandleMovement()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y); // k‰‰nnyt‰‰n vasemmalle
            m_FacingRight = false;                                //Sprite suunta v‰‰rin
            transform.localScale = new Vector3(-1, 1, 1);         //k‰‰nt‰‰ pelaajan spriten suunnan vasemmalle
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y); // k‰‰nnyt‰‰n oikealle
                m_FacingRight = true;
                transform.localScale = new Vector3(1, 1, 1);         //k‰‰nt‰‰ pelaajan spriten suunnan oikealla
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);        // rigipodin suunta on voiman/velocitun mukainen y-suunnassa (hahmo putoaa)
            }
        }


        //Move the character by finding the target velocity
        //Vector3 targetVelocity = new Vector2(moveSpeed * 10f, rb.velocity.y);
        //And then smoothing it out and applying it to the character

        //rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

        //If the input is moving the player right and the player is facing left...
        //if (moveSpeed > 0 && !m_FacingRight)
        //{
        //    //... flip the player.
        //    Flip();
        //}
        ////Otherwise if the input is moving the player left and the player is facing right...
        //else if (moveSpeed < 0 && m_FacingRight)
        //{
        //    //... flip the player.
        //    Flip();
        //}


    }

    //private void Flip()
    //{
    //    m_FacingRight = !m_FacingRight;
    //    transform.Rotate(0f, 180f, 0f);
    //}

}
