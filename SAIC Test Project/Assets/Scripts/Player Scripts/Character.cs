using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    private CharacterController _controller;
    private bool inventoryActive;

    public int Speed;
    public float gravity = 20.0f;
    
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        inventoryActive = false;
        TurnedOff();
        
    }

    void Update()
    {
        Vector3 move = new Vector3(-Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));

        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

        move.y -= gravity * Time.deltaTime;

        _controller.Move(move * Time.deltaTime * Speed);

        if (Input.GetButtonDown("Inventory") && inventoryActive == true)
        {
            TurnedOff();
            inventoryActive = false;
        }
        else if (Input.GetButtonDown("Inventory") && inventoryActive == false)
        {
            TurnedOn();
            inventoryActive = true;
        }
    }

    void TurnedOff()
    {
        GameObject panel = GameObject.Find("Panel");
        panel.GetComponent<Image>().enabled = false;

        GameObject inventoryTitle = GameObject.Find("Inventory");
        inventoryTitle.GetComponent<Text>().enabled = false;

        GameObject ballText = GameObject.Find("Barrell Count");
        ballText.GetComponent<Text>().enabled = false;

        GameObject cannonText = GameObject.Find("Cannon Ball Count");
        cannonText.GetComponent<Text>().enabled = false;

        GameObject shooterText = GameObject.Find("Shooter Items");
        shooterText.GetComponent<Text>().enabled = false;
    }

    void TurnedOn()
    {
        GameObject panel = GameObject.Find("Panel");
        panel.GetComponent<Image>().enabled = true;

        GameObject inventoryTitle = GameObject.Find("Inventory");
        inventoryTitle.GetComponent<Text>().enabled = true;

        GameObject ballText = GameObject.Find("Barrell Count");
        ballText.GetComponent<Text>().enabled = true;

        GameObject cannonText = GameObject.Find("Cannon Ball Count");
        cannonText.GetComponent<Text>().enabled = true;

        GameObject shooterText = GameObject.Find("Shooter Items");
        shooterText.GetComponent<Text>().enabled = true;
    }
 
    private void OnTriggerEnter(Collider other)
    {
        GameObject gameManager = GameObject.Find("Game Manager");
        GameManagers gameManagers = gameManager.GetComponent<GameManagers>();

        if(other.name == "Barrell(Clone)")
        {
            Object.Destroy(other.gameObject);
            gameManagers.barrelCount++;
            gameManagers.itemsPickedUpCount++;
        }
        else if (other.name == "Shooter Item(Clone)")
        {
            Object.Destroy(other.gameObject);
            gameManagers.shooterItemCount++;
            gameManagers.itemsPickedUpCount++;
        }
        else if (other.name == "Cannon Ball(Clone)")
        {
            Object.Destroy(other.gameObject);
            gameManagers.cannonBallCount++;
            gameManagers.itemsPickedUpCount++;
        }
    }

}
