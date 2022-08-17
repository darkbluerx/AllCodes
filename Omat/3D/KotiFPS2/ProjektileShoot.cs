using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjektileShoot : MonoBehaviour
{
    [SerializeField]
    private Transform barrel;//piipun p‰‰
    [SerializeField]
    private Rigidbody bullet; //panos

    void Start()
    {
        
    }
 
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           Rigidbody projectile = Instantiate(bullet, barrel.position, barrel.rotation * Quaternion.Euler(0, 0, 0));
            //panokselle m‰‰ritelty rigibody
            // m‰‰ritell‰‰n panos bullet ja mist‰ se l‰htee, lis‰t‰‰n kulma barrel.rotation * Quaternion.Euler(0, 0, 0)
            projectile.AddForce(barrel.forward * 20, ForceMode.Impulse); //annotaan panokselle suunta ja voima
        }
        
    }
}
