using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Get mouse position and make character rotate towards mouse cursor.
public class MouseMovement : MonoBehaviour
{
    public float rotateSpeed = 15.0f;
    private float hitDist;
    void Update()
    {
        rotatePlayer();
    }
    void rotatePlayer() {
        // Creates a ray and forces the character's look rotation towawrds the mouse cursor.
        // Turning the rotate speed down will make the character feel slow and sluggish. Possible way 
        // to add inertia.
        Plane playerplane = new Plane(Vector3.up, transform.position);
        // If the line below thros an NullReferenceException error make sure the camera is tagged as MainCamera
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(playerplane.Raycast(ray, out hitDist)) {
            Vector3 targetpoint = ray.GetPoint(hitDist);
            Quaternion targetrotation = Quaternion.LookRotation(targetpoint - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetrotation, rotateSpeed * Time.deltaTime);
        }
    }
}
