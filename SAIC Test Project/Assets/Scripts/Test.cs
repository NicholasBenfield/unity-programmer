using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    CharacterController controller;
    public float gravity = 20.0f;


    private Vector3 moveDirection = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(0, -1, 0);

        move.y -= gravity * Time.deltaTime;

        controller.Move(move * Time.deltaTime);
    }
}
