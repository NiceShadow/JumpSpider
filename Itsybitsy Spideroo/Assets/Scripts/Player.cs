using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public
    public float MovementSpeed;
    public float JumpHeight;


    //privat
    private Rigidbody2D myRigidbody;



    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(myRigidbody.velocity.y) < 0.001f)
        {
            myRigidbody.AddForce(new Vector2(0, JumpHeight), ForceMode2D.Impulse);
        }
    }

}
