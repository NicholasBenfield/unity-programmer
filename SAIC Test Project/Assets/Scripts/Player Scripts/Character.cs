using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private CharacterController _controller;

    public GameManagers gameManager;

    public int Speed;
    public float gravity = 20.0f;
    public float Jumpheight = 21;
    
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        
    }

    void Update()
    {
        Vector3 move = new Vector3(-Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
        

        if(move != Vector3.zero)
        {
            transform.forward = move;
        }

        move.y -= gravity * Time.deltaTime;

        _controller.Move(move * Time.deltaTime * Speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Objects Name: " + other.name);
        if(other.name == "Barrell(Clone)")
        {
            Object.Destroy(other.gameObject);
            gameManager.cannonBallCount++;
        }
        else if (other.name == "Shooter Item(Clone)")
        {
            Object.Destroy(other.gameObject);
            gameManager.barrelCount++;
        }
        else if (other.name == "Cannon Ball(Clone)")
        {
            Object.Destroy(other.gameObject);
            gameManager.shooterItemCount++;
        }
    }

}
