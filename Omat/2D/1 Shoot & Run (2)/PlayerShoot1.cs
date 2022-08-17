using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot1 : MonoBehaviour
{
    //private GameObject barrel;
    [SerializeField]
    private Transform barrell;     //asee piippu, paokset tulee t‰‰lt‰
    [SerializeField]
    private GameObject projectile; //Ammo

    void Start()
    {

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            GameObject go = Instantiate(projectile, barrell.transform.position, Quaternion.identity); // Ammo l‰htee piipun suunnasta
            go.GetComponent<Rigidbody2D>().AddForce(transform.localScale.x * barrell.transform.right * 25, ForceMode2D.Impulse); // Ammo l‰htee oikealle impulssi voimalla
            //Panokset l‰htev‰t piipun osoittamaan suuntaan

            //go.GetComponent<Rigidbody2D>().AddForce(barrell.transform.right * 25, ForceMode2D.Impulse); 
            //Debug.Log("Shoot");
        }
    }
}