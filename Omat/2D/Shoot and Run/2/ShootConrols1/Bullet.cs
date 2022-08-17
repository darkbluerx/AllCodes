using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 20f;
	public int bulletDamage = 40;
	public Rigidbody2D bulletRb;
	public GameObject impactEffect;

	// Use this for initialization
	void Start () {
		bulletRb.velocity = transform.right * speed;
	}

	void OnTriggerEnter2D (Collider2D hitInfo)
	{
		EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
		if (enemy != null)
		{
			enemy.TakeDamage(bulletDamage);
		}

		Instantiate(impactEffect, transform.position, transform.rotation);

		Destroy(gameObject);
	}
	
}
