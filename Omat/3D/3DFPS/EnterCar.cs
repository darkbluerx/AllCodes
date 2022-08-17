using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterCar : MonoBehaviour
{

    [SerializeField]
    private Transform mainCamera; // tarvitaan raycast

    [SerializeField]
    private GameObject carCamera;

    [SerializeField]
    public GameObject player;

    //[SerializeField]
    //private GameObject ExitTrigger;

    [SerializeField]
    private GameObject car;

    private bool playerInCar;

    Vector3 direction; //pelaajan liikkuminen
    Vector3 movement;


    private float speed = 5.0f;
    private float turnSpeed = 25.0f;
    private float horizontalInput;
    private float forwardInput;





    void Start()
    {
        
    }
 
    void Update()
    {


        RaycastHit hitInfo;
        if (Physics.Raycast(mainCamera.position, mainCamera.forward, out hitInfo, 4f))
        {
            if (hitInfo.transform.CompareTag("Car") && Input.GetKeyDown(KeyCode.E))
            {
                playerInCar = !playerInCar;
                if (playerInCar) PutPlayerToCar();        
                //else TakePlayerFromCar();
            }
            if (playerInCar) PlayerInput();          
        }  
    }


    void PlayerInput()
    {

        {
            horizontalInput = Input.GetAxis("Horizontal");
            forwardInput = Input.GetAxis("Vertical");

            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        }






        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");
        //direction = new Vector2(movement.x, movement.y).normalized;
        
    }


    private void PutPlayerToCar()
    {
        player.transform.SetParent(this.transform);
        player.SetActive(false);

        //mainCamera.SetActive(false);
        carCamera.SetActive(true);       
    }

    //private void TakePlayerFromCar()
    //{
    //    player.transform.parent = null;
    //    player.SetActive(true);
    //    direction = Vector3.zero;
    //    movement = Vector3.zero;

    //    carCamera.SetActive(false);
    //}

}
