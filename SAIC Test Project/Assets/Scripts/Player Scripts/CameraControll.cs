using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public GameObject player;
    public float damping = 1;
    public int rotationSpeed = 5;
    Vector3 offset;
    private float yaw;
    private void Start()
    {
        offset = player.transform.position - transform.position;
    }

    private void LateUpdate()
    {
        yaw += rotationSpeed * Input.GetAxis("Mouse X");
 
        Vector3 desiredPosition = player.transform.position - offset;
        Vector3 position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);
        transform.position = desiredPosition;

        transform.eulerAngles = new Vector3(0, yaw, 0.0f);
        Quaternion target = Quaternion.Euler(yaw, 0, 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * damping);
        transform.LookAt(player.transform.position);
    }

}
