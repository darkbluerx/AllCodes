using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField]
    public int coinCount;
    private bool collectedCoin;

    private AudioSource audioSource;
    [SerializeField]
    private AudioClip coinSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin") && collectedCoin == false)
        {
            audioSource.PlayOneShot(coinSound, 1);
            collectedCoin = true;
            Destroy(collision.gameObject);
            coinCount += 1;
            //Debug.Log(coinCount);
        }
    }

    private void LateUpdate()
    {
        collectedCoin = false;
    }
}
