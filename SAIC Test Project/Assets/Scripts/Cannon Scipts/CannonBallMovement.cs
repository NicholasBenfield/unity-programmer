using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallMovement : MonoBehaviour
{
    public GameObject cannonBall;
    public GameObject barrell;
    public GameObject shooterItem;
    public GameObject keepAlive;
    public Transform spawner;

    private GameObject clone;
    private int randomNumber;

    public float secondsBetweenSpawn;
    public float elapsedTime = 0.0f;

    void Start()
    {
        secondsBetweenSpawn = 3;
        keepAlive = GameObject.Find("Dropped Items");
        DontDestroyOnLoad(keepAlive);

    }

    void Update()
    {
        Spawn(Random.Range(0, 3));

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                ObjectChange(hit.collider.gameObject);
            }
        }
    }

    void ObjectChange(GameObject other)
    {
        if (other != null && other.tag == "Item" && !other.transform.IsChildOf(keepAlive.transform))
        {
            other.GetComponent<Rigidbody>().useGravity = true;
            adjustCollider(other);

            ObjectMovement movementSpeed = other.GetComponent<ObjectMovement>();
            movementSpeed.speed = 0;

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

    void Spawn(int num)
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > secondsBetweenSpawn)
        {
            elapsedTime = 0;
            Vector3 spawn = new Vector3(spawner.transform.position.x, spawner.transform.position.y, spawner.transform.position.z + 1);

            switch (num)
            {
                case 0:
                    clone = (GameObject)Instantiate(barrell, spawn, Quaternion.identity);
                    break;
                case 1:
                    clone = (GameObject)Instantiate(shooterItem, spawn, Quaternion.identity);
                    break;
                case 2:
                    clone = (GameObject)Instantiate(cannonBall, spawn, Quaternion.identity);
                    break;

            }

        }

    }

    void adjustCollider(GameObject collisionObject)
    {
        if(collisionObject.GetComponent<CapsuleCollider>())
        {
            collisionObject.GetComponent<CapsuleCollider>().isTrigger = false;
        }
        else if (collisionObject.GetComponent<BoxCollider>())
        {
             collisionObject.GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}

