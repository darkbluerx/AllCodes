using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed = 1f;
    [SerializeField]
    private float lifeTime = 0.5f;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private int damage =40;
    [SerializeField]
    private LayerMask whatIsSolid; // luodille valitaan layereihin viholliset ja ympäristö, eli tuhoutuu näihin osuessaan. tämä voidaan tehdä Bullet2 inpektorissa "WhaisIsSolid"

    [SerializeField]
    private GameObject impactEffect;

    private void Start()
    {
        Invoke("DestroyBullet", lifeTime);
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<EnemyHealth>().TakeDamage(damage);
            }
            DestroyBullet();
        }


        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime); // luoti lähtee Vector2.right eli oikealle
    }

    private void DestroyBullet() // tuhoaa luodin sekä efektin impactEffet
    {
        Instantiate(impactEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
