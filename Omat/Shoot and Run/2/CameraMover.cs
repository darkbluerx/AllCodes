using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;
    private Vector3 velocity = Vector3.zero;

    [SerializeField]
    private float smoothNumber = 0.35f;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    void Update()
    {
        Vector3 targetPosition = new Vector3(playerTransform.position.x+3, playerTransform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothNumber);
    }
}
