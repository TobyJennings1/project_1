using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform target;      // Object to orbit around
    public float distance = 5f;   // Distance from the object
    public float rotationSpeed = 10f;   // Speed of rotation

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // DELETE THIS FUCKING SHITE

        // Calculate desired position
        Vector3 desiredPosition = target.position - transform.forward * distance;

        // Smoothly move the camera to the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, rotationSpeed * Time.deltaTime);

        // Rotate the camera around the target object
        transform.LookAt(target);
        transform.RotateAround(target.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
