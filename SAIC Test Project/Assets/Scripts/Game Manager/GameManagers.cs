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
    public int itemsClickedCount;
    public int itemsPickedUpCount;
    public int itemsMissedCount;
    public Text timerText;
    public Text barrelCountText;
    public Text cannonBallCountText;
    public Text shooterItemCountText;
    public Text finalScoreText;
    public Text itemsClickedText;
    public Text itemsMissedText;

    private float minutes;
    private float seconds;
    private int currentSceneNum;
    private int finalScore;
    private GameObject[] respawners;
    private GameObject droppedItems;
    private bool sceneLoaded = false;

    void Start()
    {
        respawners = GameObject.FindGameObjectsWithTag("Respawn");
        currentSceneNum = SceneManager.GetActiveScene().buildIndex;

        droppedItems = GameObject.FindGameObjectWithTag("Dropped");

        Object.DontDestroyOnLoad(this);
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

        if (currentSceneNum == 2)
        {

            GameObject barrelText = GameObject.Find("Barrell Count");
            barrelCountText = barrelText.GetComponent<Text>();
         
            GameObject cannonBallText = GameObject.Find("Cannon Ball Count");
            cannonBallCountText = cannonBallText.GetComponent<Text>();

            GameObject shooterItemText = GameObject.Find("Shooter Items");
            shooterItemCountText = shooterItemText.GetComponent<Text>();

            GameObject timers = GameObject.Find("Timer Text");
            timerText = timers.GetComponent<Text>();

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

            FinalScore();
        }



    }

    private void FixedUpdate()
    {
        if (currentSceneNum == 2)
        {
            barrelCountText.text = "Barrel Count: " + barrelCount;
            cannonBallCountText.text = "Cannon Ball Count: " + cannonBallCount;
            shooterItemCountText.text = "Shooter Item Count: " + shooterItemCount;
        }
    }

    void GameOver(int num)
    {
        if (num == 1)
        {
            timer = 30;
            SceneManager.LoadScene(2);
            currentSceneNum++;
        }
        if (num == 2)
        {
            DontDestroyOnLoad(this);
            Object.Destroy(droppedItems);
            currentSceneNum++;
            SceneManager.LoadScene(3);
        }

    }

    void FinalScore()
    {
        if(sceneLoaded == false)
        {
            GameObject barrelText = GameObject.Find("Barrell Score");
            barrelCountText = barrelText.GetComponent<Text>();

            GameObject cannonBallText = GameObject.Find("Cannon Ball Score");
            cannonBallCountText = cannonBallText.GetComponent<Text>();

            GameObject shooterItemText = GameObject.Find("Shooter Item Score");
            shooterItemCountText = shooterItemText.GetComponent<Text>();

            GameObject scoreText = GameObject.Find("Total Score");
            finalScoreText = scoreText.GetComponent<Text>();

            GameObject clickedText = GameObject.Find("Total Clicked");
            itemsClickedText = clickedText.GetComponent<Text>();

            GameObject missedText = GameObject.Find("Total Missed");
            itemsMissedText = missedText.GetComponent<Text>();

            sceneLoaded = true;
        }
        else if (sceneLoaded == true)
        {
            finalScore = (cannonBallCount * 1) + (barrelCount * 3) + (shooterItemCount *2);

            finalScoreText.text = "Total Score: " + finalScore;

            barrelCountText.text = "Barrell Score: " + barrelCount + " * 3 = " + (barrelCount*3);
            cannonBallCountText.text = "Cannon Ball Score: " + cannonBallCount + " * 1 = " + (cannonBallCount*1);
            shooterItemCountText.text = "Shooter Item Score: " + shooterItemCount + " * 2 = " + (shooterItemCount*2);

            itemsClickedText.text = "Total Items Clicked: " + itemsClickedCount;
            itemsMissedCount = itemsClickedCount - itemsPickedUpCount;
            itemsMissedText.text = "Total Items Not Picked Up:" + itemsMissedCount;
    

        }

    }
}
