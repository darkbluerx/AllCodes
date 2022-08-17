using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float destroyer;

    [SerializeField]
    public float timer1 = 100;
    
    //private bool bool1;
    //[SerializeField]
    //private Renderer rd;
    //[SerializeField]
    //private float interval;
    //[SerializeField]
    //private Color32 color;

    void Start()
    {
        //rd = GetComponent<Renderer>();
    }

    void Update()
    {

        //destroyer -= Time.deltaTime;
        //if (destroyer <= 5) Destroy(gameObject);

        //Time.timeScale = 100;
        timer1 -= Time.deltaTime;
        Debug.Log(timer1);

        //if (timer >= interval * 2) timer = 0;
        //if (timer >= interval * 2) bool1 = true;
        //if (timer >= interval * 2) bool1 = false;

        //if (bool1) rd.material.color = Color.red;
        //else rd.material.color = Color.white;
    }
}
