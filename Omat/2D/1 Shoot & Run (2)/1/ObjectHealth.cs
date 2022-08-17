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

    private void OnCollisionEnter2D(Collision2D collision) //OnCollsionEnter"D kutsutaan kun jokin t�rm�� johonkin
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

    public void DestroyMeteor() //T�t� metodi voidaan kutsua muualta t�ss� tapauksessa PowerUp-koodissa. T�ll�in objektien tuhouduttua tapahtuu r�j�hdys effecti
    {
        explosion.ShowExplosion();
        Destroy(gameObject);
    }
}