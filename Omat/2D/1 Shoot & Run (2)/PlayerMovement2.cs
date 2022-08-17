using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerMovent : MonoBehaviour
{
    private Rigidbody2D body;
    private float horizontal;
    private float vertical;

    public float runSpeed = 10.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixeUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

}
