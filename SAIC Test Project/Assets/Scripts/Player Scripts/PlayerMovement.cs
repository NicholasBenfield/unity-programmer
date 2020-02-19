using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;

    public float speed = 6.0f;

    private Vector3 moveDirection = Vector3.zero;
    private bool movmentScene;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            Debug.Log("Movement Scene");
            movmentScene = true;
        }
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movmentScene == true)
        {
            

        }
        Debug.Log("Movment Scene started");
            Debug.Log("Horizontal Value: " + Input.GetAxis("Horizontal"));
            Debug.Log("Vertical Value: " + Input.GetAxis("Vertical"));
            //moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Verticle"));
            //moveDirection *= speed;

            Vector3 Movement = new Vector3(Input.GetAxis("Horizonta"), 0, Input.GetAxis("Vertical"));

            controller.Move(Movement * Time.deltaTime * speed);
    }
}
