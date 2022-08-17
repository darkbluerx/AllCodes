using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) //ker‰‰ 3 kolikkoa "ovi" tuhoutuu osuessasi siihen
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInventory inventory = collision.gameObject.GetComponent<PlayerInventory>();
            if (inventory.coinCount >= 3)
            {
                Destroy(gameObject);
            }
        }
    }
}
