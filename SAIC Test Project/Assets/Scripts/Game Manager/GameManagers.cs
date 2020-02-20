using System.Collections;
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
    public Text barrelCountText;
    public Text cannonBallCountText;
    public Text shooterItemCountText;

    private float minutes;
    private float seconds;
    private int currentSceneNum;
    private GameObject[] respawners;
    


    void Start()
    {
        respawners = GameObject.FindGameObjectsWithTag("Respawn");
        currentSceneNum = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneNum == 2)
        {
            for (int i = 0; i < respawners.Length; i++)
            {
                respawners[i].transform.gameObject.SetActive(false);
            }
        }   
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSceneNum == 1)
        {
            timer -= Time.deltaTime;
            minutes = Mathf.Floor(timer / 60);
            seconds = Mathf.RoundToInt(timer % 60);

            timerText.text = "Time left: " + minutes.ToString("00") + ":" + seconds.ToString("00");

            if (minutes.ToString("00") == "00" && seconds.ToString("00") == "00")
            {
                GameOver(currentSceneNum);
            }
            
        }

        if(currentSceneNum == 2)
        {
            timer -= Time.deltaTime;
            minutes = Mathf.Floor(timer / 60);
            seconds = Mathf.RoundToInt(timer % 60);

            timerText.text = "Time left: " + minutes.ToString("00") + ":" + seconds.ToString("00");

            if (minutes.ToString("00") == "00" && seconds.ToString("00") == "00")
            {
                GameOver(currentSceneNum);
            }
        }

        if (currentSceneNum == 3)
        {
            timer = 0;
        }


    }

    private void FixedUpdate()
    {
         barrelCountText.text = "Barrel Count: " + barrelCount;
        cannonBallCountText.text = "Cannon Ball Count: " + cannonBallCount;
        shooterItemCountText.text = "Shooter Item Count: " + shooterItemCount;
    }

    void GameOver(int num)
    {
        if (num == 1)
        {
            for (int i = 0; i < respawners.Length; i++)
            {
                respawners[i].transform.gameObject.SetActive(false);
            }
            SceneManager.LoadScene(2);
        }
        else if (num == 2)
        {
            DontDestroyOnLoad(this);
            SceneManager.LoadScene(3);
        }

    }
}
