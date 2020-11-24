using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public delegate void OnTimeCompleted();

    public static event OnTimeCompleted onTimeCompleted;

    public float timer;

    public Text text;

    public void SetTimer(float timee)
    {
        timer = timee;
    }

    void Update()
    {
        if(timer > 0f)
        {
            timer -= Time.deltaTime;
            text.text = "Time: " + timer.ToString("0.0");

            if (isCompleted())
            {
                timer = 0f;
                onTimeCompleted();
            }
        }
    }

    public bool isCompleted()
    {
        return timer <= 0;
    }
}
