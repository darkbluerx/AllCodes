using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    [SerializeField]
    private int damageAmount = 20;
    [SerializeField]
    private float interval = 1;

    private bool cooldown;
    private float timer;
    private SpriteRenderer sr; //muutetan v‰ri‰

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown == true)
        {
            timer += Time.deltaTime;
            if (timer > interval)
            {
                cooldown = false;
                timer = 0;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision) // el‰m‰‰ menee jatkuvasti osuessa ansaan
    {
        if (collision.gameObject.CompareTag("Player")&& cooldown == false)
        {
            cooldown = true;
            PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();
            health.TakeDamage(damageAmount);
        }
    }
}
