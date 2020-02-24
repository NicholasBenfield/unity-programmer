using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroductionManager : MonoBehaviour
{

    public Button exitButton;
    public Button nextButton;
    public Button previousButton;

    public Text leftPanelText;
    public Text rightPanelText;
    public Text leftPanelTitle;
    public Text rightPanelTitle;

    public int currentText;

    private void Start()
    {
        currentText = 0;
        PartOne();
    }

    private void Update()
    {
         if (currentText <= 0)
        {
            PartOne();
            currentText = 0;
        }
        else if (currentText == 1)
        {
            PartTwo();
        }
        else if (currentText == 2)
        {
            PartThree();
        }
        else if(currentText == 3)
        {
            ParthFour();
        }
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void NextText()
    {
        if (currentText < 3)
        {
            currentText++;
        }
        else if (currentText == 3)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void PreviousText()
    {
        currentText--;
    }

    void PartOne()
    {
        leftPanelTitle.text = "Project Introduction";
        leftPanelText.text = "Welcome to the SAIC Project Test! This project is designed and developer by Nicholas Benfield.\n\n"
            +
            "The goal of this project was to demonstrate my Unity3D skills along with my programming skills.\n\n"
            +
            "This first scene that you are seeing, will be the introduction and a brief tutorial.\n\n"
            +
            "After the introduction, the game begins, so read through to start it!";

        rightPanelTitle.text = "Button Controls";
        rightPanelText.text = "There are three buttons below, from left to right they are as follows: Exit, Previous and Next.\n\n"
            +
            "The Exit button will close the game and stop it.\n\n"
            +
            "The Previous button will take you back a page to the previous instructions.\n\n"
            +
            "The Next Button will take you to the next page of instructions, it will also change into Play, once all the instructions have been read.";
    }

    void PartTwo()
    {
        leftPanelTitle.text = "Tutorial!";
        leftPanelText.text = "When the game begins, you will have 60 seconds to click on as many items that move across the screen.\n\n"
            +
            "Beware that each item spawns at differnet intervals and moves at differnet speeds.\n\n"
            +
            "Once clicked the object will fall the ground and be unclickable.";

        rightPanelTitle.text = "Items";
        rightPanelText.text = "The game has the following items that move accross the screne.\n\n"+
            "1.A Red Barrel that is worth 3 points.\n\n" 
            + 
            "2.A Green Shooter Item that is worth 2 points.\n\n"
            +
            "3.A Blue Cannon Ball that is worth 1 point.\n\n"
            +
            "Each item will randomly spawn and start moving across the screen.\n\n Good luck hitting them all!";
       
    }

    void PartThree()
    {
        leftPanelTitle.text = "Tutorial!";
        leftPanelText.text = "After you've attempted to click as many items as possible, the next stage requires you to gather the fallen items.\n\n"
            +
            "However, unlike the last stage you only have 30 seconds to grab as many items as possible!"
            +
            "An inventory will be displayed on the right side of the screen.";

        rightPanelTitle.text = "Movement";
        rightPanelText.text = "In order to collect the items you are required to use either the WASD keys or the arrow keys on the keyboard.\n\n"
            +
            "As you move, a camera will follow behind you. When you move into an item, that item will get added to your inventory and your score.\n\n"
            +
            "To display your current inventory, press E for it to appear and press it again to make it disappear.\n\n"
            +
            "Once the timer hits 0, your final score will be displayed along with the count of items you've clicked and the amount that wasn't picked up.";
     
    }
    void ParthFour()
    {
        nextButton.GetComponentInChildren<Text>().text = "Play!";
        leftPanelTitle.text = "Are you ready to begin??";
        rightPanelTitle.text = "Are you ready to begin??";

        leftPanelText.text = "Click play to start the game!";
        rightPanelText.text = "Click play to star thte game!";
    }

}
