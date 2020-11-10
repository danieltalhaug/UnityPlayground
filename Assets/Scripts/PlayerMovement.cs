using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Move player. Make speed adjustable by scrolling.
public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 4.0f;
    public float defaultSpeed = 4.0f;
    private float minimumSpeed = 0.5f;
    public float adjustSpeednumber = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayerVertical();
        MovePlayerHorizontal();
        AdjustMovementSpeed();
    }
    void MovePlayerVertical() {
        // GetAxis allows the player to slide a little to simulate inertia. Use GetAxisRaw to remove it.
        float movement = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        transform.Translate(0, 0, movement);
        //transform.Rotate(0, movement, 0);
    }
    void MovePlayerHorizontal() {
        // GetAxis allows the player to slide a little to simulate inertia. Use GetAxisRaw to remove it.
        float movement = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        transform.Translate(movement, 0, 0);
    }
    void AdjustMovementSpeed() {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f && movementSpeed < defaultSpeed) // forward
            movementSpeed += adjustSpeednumber;
        {
        if (Input.GetAxis("Mouse ScrollWheel") < 0f && movementSpeed > minimumSpeed) // backwards
            movementSpeed -= adjustSpeednumber;
        }
    }
}
