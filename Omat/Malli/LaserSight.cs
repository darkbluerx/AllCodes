using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSight : MonoBehaviour
{
    private LineRenderer lr;
    [SerializeField]
    private Transform pointA; // l‰htee piipusta
    [SerializeField]

    private Vector3 pointB; // p‰‰ttyy laaseri

    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }


    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(pointA.position, pointA.up, 10); // raycast l‰htee piipuun suuntaan (vihre‰ nuoli)
        if (hit)
        {
            pointB = hit.point;// jos s‰de osuu
        }
        else
        {
            pointB = pointA.transform.position + pointA.up * 10; // s‰teen pituus on piipusta l‰htien
        }


        lr.SetPosition(0, pointA.position);
        lr.SetPosition(1, pointB);
    }
}