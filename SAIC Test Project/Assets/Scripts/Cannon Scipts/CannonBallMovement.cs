using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallMovement : MonoBehaviour
{

    public GameObject cannonBall;
    public Transform spawner;

    public GameObject clone;

    public float secondsBetweenSpawn;
    public float elapsedTime = 0.0f;

    void Start()
    {
        secondsBetweenSpawn = 3;
    }

    void Update()
    {
        Spawn();

        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                ObjectChange(hit.collider.gameObject);
            }
        }
    }

    void ObjectChange(GameObject other)
    {
        if (other != null && other.tag == "Item")
        {
            other.GetComponent<Rigidbody>().useGravity = true;
            ObjectMovement movementSpeed = other.GetComponent<ObjectMovement>();
            movementSpeed.speed = 0;
        }
    }

    void Spawn()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > secondsBetweenSpawn)
        {
            elapsedTime = 0;
            Vector3 spawn = new Vector3(spawner.transform.position.x, spawner.transform.position.y, spawner.transform.position.z);

            clone = (GameObject)Instantiate(cannonBall, spawn, Quaternion.identity);
        }
        
    }
}
