using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 100;
    [SerializeField]
    public int health = 100;
    [SerializeField]
    public int lives = 3;

    private SpriteRenderer sr;
    private Vector3 originalPos;

    private AudioSource audioSource;
    [SerializeField]
    private AudioClip damageSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
        health = maxHealth;
        originalPos = transform.position;
    }

    public void Checkpoint(Vector3 point)
    {
        originalPos = point;
    }

    public void TakeDamage(int amount)
    {
        if (health < 80) audioSource.pitch = 1.2f; //äänen muokkaus
        if (health < 60) audioSource.pitch = 1.4f;
        if (health < 40) audioSource.pitch = 1.6f;
        if (health < 20) audioSource.pitch = 1.8f;
        if (health < 5) audioSource.pitch = 0.5f;
        audioSource.PlayOneShot(damageSound, 1);

        sr.color = Color.red;
        health -= amount;
        Invoke("ChangeColorBack", 0.2f);
        if (health <= 0) PlayerDead();
    }

    private void ChangeColorBack()
    {
        sr.color = Color.white;
    }
    private void PlayerDead()
    {
        lives -= 1;
        health = maxHealth;
        transform.position = originalPos;
    }
}
