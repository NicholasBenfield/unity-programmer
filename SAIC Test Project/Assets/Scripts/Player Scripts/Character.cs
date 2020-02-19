using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private CharacterController _controller;

    public int Speed;
    public float gravity = 20.0f;
    public float Jumpheight = 21;
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
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
}
