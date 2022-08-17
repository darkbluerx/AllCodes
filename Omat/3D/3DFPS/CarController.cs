using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    //private float speed = 5.0f;
    //private float turnSpeed = 25.0f;
    //private float horizontalInput;
    //private float forwardInput;

    //void Start()
    //{

    //}
    //void Update()
    //{
    //    horizontalInput = Input.GetAxis("Horizontal");
    //    forwardInput = Input.GetAxis("Vertical");

    //    transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
    //    transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

    //}


    [SerializeField]
    private GameObject carCamera;

    Vector3 direction;
    Vector3 movement;
    Rigidbody2D rb;
    [SerializeField]
    private bool playerInCar;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

       




        if (Input.GetKeyDown(KeyCode.KeypadEnter) && Vector3.Distance(player.transform.position, transform.position) < 10)
        {
            playerInCar = !playerInCar;
            if (playerInCar) PutPlayerToCar();
            else TakePlayerFromCar();
        }

        if (playerInCar) PlayerInput();
    }

    void PlayerInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        direction = new Vector2(movement.x, movement.y).normalized;
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.up * movement.y * 80000);
        if (direction.y != 0) rb.AddTorque(-direction.x * 80000);
        
    }

    private void PutPlayerToCar()
    {
        player.transform.SetParent(this.transform);
        player.SetActive(false);
        
        carCamera.SetActive(true);
        
    }

    private void TakePlayerFromCar()
    {
        player.transform.parent = null;
        player.SetActive(true);
        direction = Vector3.zero;
        movement = Vector3.zero;

        carCamera.SetActive(false);
    }

}