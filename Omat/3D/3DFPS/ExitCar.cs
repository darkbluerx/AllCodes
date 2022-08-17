using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCar : MonoBehaviour
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





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakePlayerFromCar();
            MainCameraOn();
        }
    }

    private void MainCameraOn()
    {
        player.transform.parent = null;
        player.SetActive(true);
        //mainCamera.SetActive(false);
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
