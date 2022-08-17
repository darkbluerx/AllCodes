using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
public class Timer : MonoBehaviour
{

    private float timer;

    [SerializeField]
    private bool bool1;

    [SerializeField]
    private Renderer rd;

    [SerializeField]
    private float interval;

    [SerializeField]
    private Color32 color;

    void Start()
    {
        rd = GetComponent<Renderer>();

    }


    void Update()
    {
        Time.timeScale = 0.5f; //määrittää nopeuden ajan ja pelin fysiikat (esim asiat tippuvat nopeammin)

        timer += Time.deltaTime;
        Debug.Log(timer);

        if (timer >= interval * 2) timer = 0;
        if (timer >= interval) bool1 = true;
        if (timer <= interval) bool1 = false;

        if (bool1) rd.material.color = Color.red;
        else rd.material.color = Color.white;

    }
}
