using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField]
    public int coinCount;

    private bool collectedCoin;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin") && collectedCoin == false)
        {
            collectedCoin = true;
            Destroy(collision.gameObject);
            coinCount += 1;
            ScoreManager.intance.AddPoint();
            //Debug.Log(coinCount);
        }
    }


    private void LateUpdate()
    {
        collectedCoin = false;
    }

}
