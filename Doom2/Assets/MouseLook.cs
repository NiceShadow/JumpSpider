using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //stroing the vertical rotation in a variable to allow for clamping
    float verticalRotation = 0f;
    public float mouseSensitivity = 120f;  

    //Reference to the player character for horizontal rotation
    public Transform playerBody;

    //This locks the cursor in the middle of the screen.
    //Escape using ESC or CTRL + P
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        verticalRotation = verticalRotation - mouseY; 
        //Inverted Controls: verticalRotation = verticalRotation + mouseY;

        //Clamp it to avoid full rotation
        verticalRotation = Mathf.Clamp(verticalRotation, -80f, 80f);

        transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        playerBody.Rotate(Vector3.up, mouseX);
    }
}
