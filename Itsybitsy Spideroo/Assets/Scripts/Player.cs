using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public
    public float MovementSpeed;
    public float JumpHeight;
    public SpriteRenderer spiderRef;
    public GameObject heightRef;

    //privat
    Rigidbody2D myRigidbody;
    Vector2 initialScale;
    bool LandedAlready;


    void Start()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 144;
        myRigidbody = GetComponent<Rigidbody2D>();
        initialScale = transform.localScale;

    }

    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
        //myRigidbody.transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
        //Vector3 dis = 
        //myRigidbody.MovePosition(myRigidbody.transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed);

        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = initialScale.x;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = -initialScale.x;

        }

        transform.localScale = characterScale;
        
        if (Input.GetButtonDown("Jump") &&  Mathf.Abs(myRigidbody.velocity.y) < 0.001f)
        {
            myRigidbody.AddForce(new Vector2(0, JumpHeight), ForceMode2D.Impulse);
            heightRef.GetComponent<Animator>().SetTrigger("stretch");
        }
        if (Mathf.Abs(myRigidbody.velocity.y) > 0.15f)
        {
            LandedAlready = false;
        }

        if (Mathf.Abs(myRigidbody.velocity.y) < 0.01f && !LandedAlready)
        {
            playLanding();
            LandedAlready = true;
        }

    }

    void playLanding()
    {
        heightRef.GetComponent<Animator>().SetTrigger("squash");
    }

}
