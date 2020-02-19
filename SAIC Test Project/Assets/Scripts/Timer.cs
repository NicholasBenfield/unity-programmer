using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text text;

    private float timer;
    private float minutes;
    private float seconds;

    void Start()
    {
        timer = 121;
        minutes = (timer / 60);
    }
    void Update()
    {
        timer -= Time.deltaTime;
        minutes = Mathf.Floor(timer / 60);
        seconds = Mathf.RoundToInt(timer % 60);

        if (seconds == 60)
        {
            text.text = "Time left: " + minutes + ":00";
        }
        text.text = "Time left: " + minutes + ":" + seconds;

        if(timer < 0)
        {

            GameOver();
        }
    }

    void GameOver()
    {

    }
}
