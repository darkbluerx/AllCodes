using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private GameObject particleEffect;

    public void ShowExplosion()
    {
        GameObject go = Instantiate(particleEffect, transform.position, transform.rotation);
        Destroy(go, 5);

    }

}