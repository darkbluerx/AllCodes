using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth1 : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip hit;

    public static PlayerHealth1 singleton;
    public float currentHealth;
    public float maxhealth = 100f;

    private void Awake()
    {
        singleton = this;
    }

    private void Start()
    {
        currentHealth = maxhealth;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {

    }

    public void PlayerDamage(float damage)
    {
        
        currentHealth -= damage;
        audioSource.PlayOneShot(hit, 1);
        //Invoke("GameOverScene", 1);
    }

    //public void GameOverScene()
    //{
    //    SceneManager.LoadScene("GameOver2");

    //}
}