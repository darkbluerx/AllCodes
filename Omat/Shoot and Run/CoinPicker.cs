using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPicker : MonoBehaviour
{

    private float coin = 0;

    private void Update()
    {
        transform.Rotate(0.0f, 1.0f, 0.0f, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Coin")
        {
            Destroy(other.gameObject);
        }
    }
}
