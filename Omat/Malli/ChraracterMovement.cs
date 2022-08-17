using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChraracterMovement : MonoBehaviour
{

    private Animator animator;
    private CharacterController characterController;

    [SerializeField] private float playerSpeed = 1.5f;
    [SerializeField] private float movementTime = 0.2f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        animator.SetFloat("X", movementDirection.x, movementTime, Time.deltaTime); // m‰‰ritell‰‰n animaatiot x suuntaan
        animator.SetFloat("Y", movementDirection.y, movementTime, Time.deltaTime);
        characterController.Move(new Vector3(movementDirection.x, 0, movementDirection.y).normalized * Time.deltaTime * playerSpeed); // tehd‰‰n liikkuminen n‰pp‰imistˆll‰
    }
}
