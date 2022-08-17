using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerMouse : MonoBehaviour
{
    private Animator animator;
    private CharacterController characterController;
    [SerializeField] private float playerSpeed = 1.5f;
    [SerializeField] private float movementTime = 0.2f;
    [SerializeField] private float yAngle;

    [SerializeField] private float jumpHeight = 1;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private float gravity = -9.8f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
        {           
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            Animator();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("PlayerDeath");
        }

        Debug.Log(Input.GetAxisRaw("Mouse X")); //n�ytt�� hiiren sijainnin x suunnassa (konsolissa)
        yAngle += Input.GetAxisRaw("Mouse X"); //n�ytt�� asteina (inspectorissa)
        transform.rotation = Quaternion.Euler(0, yAngle, 0); //k��ntyminen muutetaan asteiksi ja hiirell� k��nnet��n hahmoa

        //Vector2 mD = tehd��n muistiviite, m��ritet��n liikkuminen ainoastaa vektori2 eli tarvitaan vain 2 vektoria. Input.GetAxisRaw("Horizontal") = lukee n�pp�imist�n arvoja -1,0,1 eli m��ritet��n liikkumisen
        //n�pp�imet
        Vector2 movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        animator.SetFloat("X", movementDirection.x, movementTime, Time.deltaTime); // m��ritell��n animaatiot x suuntaan. kun x =1 ->k�velee eteenp�in, kun x =-1 -> k�velee taaksep�in
        animator.SetFloat("Y", movementDirection.y, movementTime, Time.deltaTime); //strafe/liikutaan sivuille

        Vector3 move = transform.forward * movementDirection.y + transform.right * movementDirection.x;
        characterController.Move(move * playerSpeed * Time.deltaTime); // hahmo liikkuu sivuille hiiren mukaan, x ja y suuntia liikuteen arvoiolla 0-1

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        if (characterController.isGrounded && velocity.y < -2)
        {
            velocity.y = -2;
        }     
    }

    private void Animator()
    {
        animator.SetBool("Jump", true);
    }
}
