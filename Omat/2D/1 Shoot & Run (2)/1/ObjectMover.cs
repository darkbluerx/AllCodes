using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{

    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Random.insideUnitCircle * 1500, ForceMode2D.Impulse); //Planeetat liikkuvat randomi suuntaan(käsky toimii ympyrä objektilla)
        rb.AddTorque(Random.Range(-4000f, 4000f), ForceMode2D.Impulse);   //Planeetta liikkuu myös


    }


    void Update()
    {

    }
}
