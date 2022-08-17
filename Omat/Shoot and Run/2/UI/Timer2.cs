using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer2 : MonoBehaviour
{

    // https://www.youtube.com/watch?v=HmHPJL-OcQE&ab_channel=GameDevBeginner

    private float destroyer;

    [SerializeField]
    public float timer22 = 100;
    public string timeText1;

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
        if (timer22 > 0)
        {
            timer22 -= Time.deltaTime;
        }
        else
        {
            timer22 = 0;
        }
        DisplayTime(timer22);

        //destroyer -= Time.deltaTime;
        //if (destroyer <= 5) Destroy(gameObject);

        //Time.timeScale = 100;
        //timer1 -= Time.deltaTime;
        //Debug.Log(timer1);

        //if (timer >= interval * 2) timer = 0;
        //if (timer >= interval * 2) bool1 = true;
        //if (timer >= interval * 2) bool1 = false;

        //if (bool1) rd.material.color = Color.red;
        //else rd.material.color = Color.white;

        void  DisplayTime(float timeToDisplay)
        {
            if (timeToDisplay < 0)
            {
                timeToDisplay = 0;
            }

            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);

            timeText1 = string.Format("{0:00}: {1:00}", minutes, seconds);
            
        }
    }
}