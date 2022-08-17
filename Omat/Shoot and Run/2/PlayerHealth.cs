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

    private void Start()
    {
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
