using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Get mouse position and make character rotate towards mouse cursor.
public class RotateCamera : MonoBehaviour
{
    public float rotateSpeed = 1.0f;
    private float rotationY;
    public Transform target;
    public int degrees = 0;
    // Update is called once per frame
    void Update()
    {
        rotateCamera();
    }
    void rotateCamera() {
        // // Get mouse position and multiply it by rotation speed.
        // rotationY += Input.GetAxis("Mouse X") * rotateSpeed;
        // // Add rotation to Players transform rotation Y value
        // if (Input.GetMouseButtonDown(1)) {
        //     GameObject.FindWithTag("MainCamera").transform.rotation = Quaternion.Euler(0, rotationY,0);
        // }
        rotationY += Input.GetAxis("Mouse X") * rotateSpeed;
        if (Input.GetKeyDown("space")) {
           GameObject.FindWithTag("MainCamera").transform.rotation = Quaternion.Euler(0,rotationY,0);
        }
    }
}
