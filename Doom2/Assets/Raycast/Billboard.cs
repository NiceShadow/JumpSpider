using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    Vector3 lookDirection;
    void Update()
    {
        lookDirection = transform.forward = Camera.main.transform.position - transform.position;
        lookDirection.y = 0;
        transform.forward = lookDirection;
    }
}
