﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagers : MonoBehaviour
{
    public float timer;
    public int cannonBallCount;
    public int barrelCount;
    public int shooterItemCount;
    public Text timerText;

    private float minutes;
    private float seconds;
    private GameObject[] respawners;
    private GameObject respawn;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] timers;
        
        minutes = (timer / 60);

        respawners = GameObject.FindGameObjectsWithTag("Respawn");
        timers = GameObject.FindGameObjectsWithTag("UI Text");
      

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            for (int i = 0; i < respawners.Length; i++)
            {
                respawners[i].transform.gameObject.SetActive(false);
            }

            timers[0].transform.gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        minutes = Mathf.Floor(timer / 60);
        seconds = Mathf.RoundToInt(timer % 60);

        if (seconds == 60)
        {
            timerText.text = "Time left: " + minutes + ":00";
        }

        timerText.text = "Time left: " + minutes + ":" + seconds;

        if (timer < 0 )
        {
            GameOver();
        }
    }

    void GameOver()
    {
        for (int i = 0; i < respawners.Length; i++)
        {
            respawners[i].transform.gameObject.SetActive(false);
        }

        SceneManager.LoadScene(2);
    }
}
