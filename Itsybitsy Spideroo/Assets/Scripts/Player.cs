using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public
    public float MovementSpeed;
    public float AirSpeed;
    public float JumpHeight;
    public float TrampoJumpHeight = 12;
    public SpriteRenderer spiderRef;
    public GameObject heightRef;
    public float borderLeft = -3.5f;
    public float borderRight = 3.5f;

    //privat
    Rigidbody2D myRigidbody;
    Vector2 initialScale;
    bool LandedAlready;
    bool spacePressed = false;

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
        if (!(transform.position.x > borderRight && movement > 0) && !(transform.position.x < borderLeft && movement < 0))
        {
            if (LandedAlready)
                transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
            else
                transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * AirSpeed;
        }


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

        if (Input.GetButtonDown("Jump")) spacePressed = true;
        if (Input.GetButtonUp("Jump")) spacePressed = false;

        Debug.Log(myRigidbody.velocity.y);

        if (spacePressed &&  Mathf.Abs(myRigidbody.velocity.y) < 0.001f)
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

    public void JumpOnTrampoline()
    {
        myRigidbody.velocity = Vector2.zero;
        myRigidbody.AddForce(new Vector2(0, TrampoJumpHeight), ForceMode2D.Impulse);
    }

}
