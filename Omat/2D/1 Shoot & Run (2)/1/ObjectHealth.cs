using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : MonoBehaviour
{

    [SerializeField]
    private int health = 5;
    private Explosion explosion;

    // Start is called before the first frame update
    void Start()
    {
        explosion = GetComponent<Explosion>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision) //OnCollsionEnter"D kutsutaan kun jokin törmää johonkin
    {

        //       if (collision.transform.tag == "Bullet")
        if (collision.transform.CompareTag("Bullet"))
        {
            health -= 1;
            if (health < 0)
            {
                DestroyMeteor();
            }
        }
    }

    public void DestroyMeteor() //Tätä metodi voidaan kutsua muualta tässä tapauksessa PowerUp-koodissa. Tällöin objektien tuhouduttua tapahtuu räjähdys effecti
    {
        explosion.ShowExplosion();
        Destroy(gameObject);
    }
}