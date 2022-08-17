using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheesePickup : MonoBehaviour
{
    //private Timer timer;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField] private AudioClip collectCheese;

    void Start()
    {
       // timer = FindObjectOfType<Timer>();
       
    }

    private void OnTriggerEnter(Collider other)
    {
      //  timer.timeValue += 10;
        audioSource.PlayOneShot(collectCheese, 1);
        Destroy(gameObject);
    }
}
