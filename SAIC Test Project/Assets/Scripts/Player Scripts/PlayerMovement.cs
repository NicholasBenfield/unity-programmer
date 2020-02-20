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
            movmentScene = true;
        }
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
            Vector3 Movement = new Vector3(Input.GetAxis("Horizonta"), 0, Input.GetAxis("Vertical"));

            controller.Move(Movement * Time.deltaTime * speed);
    }
}
