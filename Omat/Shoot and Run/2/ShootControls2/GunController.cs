using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    //[SerializeField]
    //private float offset= -90;

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject shotEffect;
    [SerializeField]
    private Transform firepoint;

    private float targetAngle;
  
    //private Animator camAnim;

    private float timeBtwShots;
    [SerializeField]
    private float cooldown = 0.35f;
    //public Animator gunAnimator;

    private void Start()
    {
        //ShootAnimator();
    }

    private void Update()
    {
        // Handles the weapon rotation, muista laittaa kameran tac = maincamera, jotta ase liikkuu hiiren mukaan
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        targetAngle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg; //suunta vektori saadaan Atan2 (x,y), mutta t‰m‰ antaa suunnan radiaaneina, joten muutetaan se asteiksi * Math.Rad2Deg
        transform.rotation = Quaternion.Euler(0f, 0f, targetAngle); //k‰‰nnet‰‰n asetta ainoastaa z.vektorissa + offset (offset lis‰‰ kulmaa)

        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(shotEffect, firepoint.position, Quaternion.identity); //valitaan ampumis effekti  -  /shotEffect = aseen liekki
                //camAnim.SetTrigger("shake");
                Instantiate(bullet, firepoint.position, transform.rotation); //m‰‰ritell‰‰n luodin liikerata, luoti tulee firepoint suunnasta (piipusta)
                timeBtwShots = cooldown;
                //gunAnimator.SetTrigger("Input.GetMouseButton(0)");
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    } 
    //void ShootAnimator()
    //{

    //}

}

