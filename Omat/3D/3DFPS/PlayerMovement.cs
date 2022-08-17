using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController characterController; //viitataan CharacterController, jotta saadaan sen ominaiset k‰yttˆˆn
    private Vector2 movementDirection;//m‰‰ritell‰‰n liikkuminen, halutaan liikku vain x- ja y-suunnassa

    [SerializeField]
    private Vector3 velocity; // m‰‰riteltiin painovoima
    [SerializeField]
    private float gravity = -9.8f; 
  
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized; // liikutaan sivuille, eteen ja taakse
        Vector3 move = transform.right * movementDirection.x + transform.forward * movementDirection.y; //liikutaan sivuttain x-suunta, kun k‰ytet‰‰n transform.right * movementDirection.x
        // t‰ll‰ transform.forward * movementDirection.y liikutaan z-suuntaan eteen ja takkse

        velocity.y += gravity * Time.deltaTime; //tehd‰‰n hyppyvoima johon vaikuttaa gravitaatio
      
        if(characterController.isGrounded == true && velocity.y < 0) //jos ollaan maassa, nollataan velocity (painovoiman vaikutus)
        {
            velocity.y = -2;
        }

        if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded == true)// && characterController.isGrounded == true) tehd‰‰n hyppy
        {
            velocity.y = 4;
        }
        characterController.Move(move * 10 * Time.deltaTime + (velocity * Time.deltaTime)); //m‰‰ritell‰‰n mihin kohti ollaan liikkumassa, ja Time.deltatime liikkuu tasaisesti
        // (velocity * Time.deltaTime) tehtiin painovoima pelaajalle
    }
}
