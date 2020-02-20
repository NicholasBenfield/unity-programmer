using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private CharacterController _controller;
    private GameObject inventoryDisplay;
    private bool inventoryActive;
    public GameManagers gameManager;

    public int Speed;
    public float gravity = 20.0f;
    
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        inventoryDisplay = GameObject.FindGameObjectWithTag("Inventory");
        inventoryActive = false;
        
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
            inventoryDisplay.SetActive(false);
            inventoryActive = false;
        }
        else if (Input.GetButtonDown("Inventory") && inventoryActive == false)
        {
            inventoryDisplay.SetActive(true);
            inventoryActive = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Barrell(Clone)")
        {
            Object.Destroy(other.gameObject);
            gameManager.barrelCount++;
        }
        else if (other.name == "Shooter Item(Clone)")
        {
            Object.Destroy(other.gameObject);
            gameManager.shooterItemCount++;
        }
        else if (other.name == "Cannon Ball(Clone)")
        {
            Object.Destroy(other.gameObject);
            gameManager.cannonBallCount++;
        }
    }

}
