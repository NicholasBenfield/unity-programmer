using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ExitGame : MonoBehaviour
{
    private void Start()
    {
       Button tempButton = GameObject.FindObjectOfType<Button>();
        tempButton.onClick.AddListener(EndGame);
    }

    void EndGame()
    {

        Application.Quit();
    }
}

