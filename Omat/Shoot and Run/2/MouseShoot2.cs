using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseShoot2 : MonoBehaviour
{
    //private GameObject barrel;
    [SerializeField]
    private Transform firepoint;
    [SerializeField]
    private GameObject bullet;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        //(Input.GetMouseButtonDown(0))
        {
            GameObject go = Instantiate(bullet, firepoint.transform.position, Quaternion.identity);
            go.GetComponent<Rigidbody2D>().AddForce(firepoint.transform.up * 25, ForceMode2D.Impulse);
            Destroy(go, 5);
        }
    }
}
