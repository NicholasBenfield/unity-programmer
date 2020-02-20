using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControl : MonoBehaviour
{
    public GameObject item;

    private GameObject keepAlive;
    private CharacterController objectCharacterController;
    private int randomNumber;

    private void Start()
    {
        keepAlive = GameObject.Find("Dropped Items");
        DontDestroyOnLoad(keepAlive);
    }

    private void Update()
    {
        OnClick();
    }

    private void OnClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                ModifyObjects(hit.collider.gameObject);
            }
        }
    }

    private void ModifyObjects(GameObject other)
    {
        if(other != null && other.tag == "Item" && !other.transform.IsChildOf(keepAlive.transform))
        {
 
            ObjectMovement movementSpeed = other.GetComponent<ObjectMovement>();
            movementSpeed.speed = 0;
            other.GetComponent<Rigidbody>().useGravity = true;

            randomNumber = Random.Range(-2, 2);

            if (randomNumber != 0)
            {
                other.transform.position = other.transform.position + new Vector3(randomNumber, 0, 0);
                other.transform.parent = keepAlive.transform;
            }
            else if (randomNumber == 0)
            {
                other.transform.position = other.transform.position + new Vector3(randomNumber + 1, 0, 0);
                other.transform.parent = keepAlive.transform;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Plane")
        {
            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
