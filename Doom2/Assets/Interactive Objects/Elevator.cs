using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    bool onGround = true;
    public float targetHeight;
    float defaultHeight;
    public float speed = 2f;

    private void Start()
    {
        defaultHeight = transform.position.y;
    }

    private void Update()
    {
        if (onGround == true && transform.position.y > defaultHeight)
        {
            transform.position = transform.position - new Vector3(0, speed * Time.deltaTime, 0);
            if (transform.position.y < defaultHeight)
            {
                transform.position = new Vector3(transform.position.x, defaultHeight, transform.position.z);
            }
        }

        else if (onGround == false && transform.position.y < targetHeight)
        {
            transform.position = transform.position + new Vector3(0, speed * Time.deltaTime, 0);
            if (transform.position.y > targetHeight)
            {
                transform.position = new Vector3(transform.position.x, targetHeight, transform.position.z);
            }
        }
    }

    public void SetElevatorState(bool newState)
    {
        onGround = newState;
    }
}
