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
    public float borderLeft = -5f;
    public float borderRight = 5f;
    public bool hasGlide;
    public float glideSpeed = 1.5f;
    public SpriteRenderer parachute;
    public GameObject spiderAni;
    public SpriteRenderer helmet;
    public bool finalJumping;
    public bool jumpAlwaysOnSpace;
    public int JumpsUsed;
    public bool dead;
    public Sprite deadSpider;
    public Sprite aliveSpider;

    public GameObject Web1;
    public GameObject Web2;
    public GameObject Web3;
    public GameObject Web4;
    public GameObject Web5;

    public GameObject CheckPoint1;
    public GameObject CheckPoint2;
    public GameObject CheckPoint3;
    public GameObject CheckPoint4;

    public GameObject Platform1;
    public GameObject Platform2;
    public GameObject Platform3;
    public GameObject Platform4;
    public GameObject Platform5;

    public GameObject Glider1;
    public GameObject Glider2;
    public GameObject Trampoline1;
    public GameObject Trampoline2;

    //privat
    public Rigidbody2D myRigidbody;
    Vector2 initialScale;
    bool LandedAlready;
    bool spacePressed = false;
    bool shiftPressed;
    bool canJump = true;
    bool AimForFirstTarget;
    bool AimForFirstTarget2;
    bool waitForLanding;



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
        if (!(transform.position.x > borderRight && movement > 0) && !(transform.position.x < borderLeft && movement < 0) && !finalJumping && !waitForLanding && !dead)
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

        if(!finalJumping && !waitForLanding && !dead)
            transform.localScale = characterScale;

        if (Input.GetButtonDown("Jump")) spacePressed = true;
        if (Input.GetButtonUp("Jump")) spacePressed = false;

        if (Input.GetKeyDown(KeyCode.LeftShift)) shiftPressed = true;
        if (Input.GetKeyUp(KeyCode.LeftShift)) shiftPressed = false;


        if (jumpAlwaysOnSpace)
        {
            if (spacePressed && Mathf.Abs(myRigidbody.velocity.y) < 0.001f && canJump && !finalJumping && !waitForLanding && !dead)
            {
                myRigidbody.AddForce(new Vector2(0, JumpHeight), ForceMode2D.Impulse);
                heightRef.GetComponent<Animator>().SetTrigger("stretch");
                JumpsUsed++;
                GameManager.play_a4();
                GameManager.updateUI();
            }
        }
        else
        {
            if (Input.GetButtonDown("Jump") && Mathf.Abs(myRigidbody.velocity.y) < 0.001f && canJump && !finalJumping && !waitForLanding && !dead)
            {
                myRigidbody.AddForce(new Vector2(0, JumpHeight), ForceMode2D.Impulse);
                heightRef.GetComponent<Animator>().SetTrigger("stretch");
                JumpsUsed++;
                GameManager.play_a4();
                GameManager.updateUI();
            }
        }


        if (Mathf.Abs(myRigidbody.velocity.y) > 0.15f)
        {
            LandedAlready = false;
        }

        if (Mathf.Abs(myRigidbody.velocity.y) < 0.01f && !LandedAlready)
        {
            playLanding();
            LandedAlready = true;
            if (waitForLanding)
            {
                waitForLanding = false;
            }
        }




        if (shiftPressed && myRigidbody.velocity.y < 0 && hasGlide)
        {
            myRigidbody.gravityScale = 0.5f;
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, -glideSpeed);
            parachute.enabled = true;
            parachute.material.color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            if (shiftPressed && hasGlide)
            {
                parachute.enabled = true;
                parachute.material.color = new Color(1f, 1f, 1f, 0.3f);
            }
            else
            {
                parachute.enabled = false;
            }
            myRigidbody.gravityScale = 1f;
        }


        if (myRigidbody.velocity.y < 0)
        {
            myRigidbody.interpolation = RigidbodyInterpolation2D.Extrapolate;
        }
        else
            myRigidbody.interpolation = RigidbodyInterpolation2D.None;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (GameManager.onFinalPlatfrom)
            {
                spiderAni.GetComponent<Animator>().SetTrigger("jump");
                finalJumping = true;
                AimForFirstTarget = true;
                GameManager.currentFinalPlat.GetComponent<FinalPlat>().SetUsed();
                helmet.enabled = true;
                anim1();
                JumpsUsed++;
                GameManager.updateUI();
                GameManager.cpIndex = GameManager.currentlyOnPlatNumber;
            }
        }
        if (finalJumping)
        {
            if (AimForFirstTarget)
            {
                myRigidbody.gravityScale = 0f;
              transform.position = new Vector2(Mathf.Lerp(transform.position.x, GameManager.Target.x, 6f * Time.deltaTime), Mathf.Lerp(transform.position.y, GameManager.Target.y, 6f * Time.deltaTime));
             if(Mathf.Abs(transform.position.x - GameManager.Target.x) < 0.1f && Mathf.Abs(transform.position.y - GameManager.Target.y) < 0.2f)
               {
                   AimForFirstTarget = false;
               }
           }
           else
           {
                   myRigidbody.gravityScale = 2f;
           }



        }
    }

    void anim1()
    {
        GetComponent<Animator>().SetTrigger("jump");
        //myRigidbody.gravityScale = 0f;
    }

    public void ResetEverythin()
    {
        JumpsUsed = 0;
    }

    public void destroyMyHelmet(bool des)
    {
        if(des)
        {
            helmet.enabled = false;
            spiderAni.GetComponent<Animator>().SetTrigger("reset");
            finalJumping = false;
            waitForLanding = true;
        }
    }

    public void setGlideEffect(bool pGlide)
    {
        hasGlide = pGlide;
    }


    void playLanding()
    {
        heightRef.GetComponent<Animator>().SetTrigger("squash");
    }

    public void JumpOnTrampoline()
    {
        myRigidbody.velocity = Vector2.zero;
        //canJump = false;
        myRigidbody.AddForce(new Vector2(0, TrampoJumpHeight), ForceMode2D.Impulse);
        heightRef.GetComponent<Animator>().SetTrigger("stretch");
        JumpsUsed++;
        GameManager.updateUI();
        GameManager.play_a9();
        //Invoke("unblockJump", 0.1f);
    }
    public void unblockJump()
    {
        canJump = true;
    }

    public void die(bool pDead)
    {
        dead = pDead;
        if (dead)
        {
            spiderRef.sprite = deadSpider;
            spiderRef.size = new Vector3(1.08032f, 1.058973f, 1f);
            hasGlide = false;
            GameManager.p_glide = false;
            GameManager.p_trampoline = false;
            GameManager.play_a5();
        }
        else
        {
            spiderRef.sprite = aliveSpider;
            spiderRef.size = new Vector3(1.08032f, 1.058973f, 1f);
        }

    }

    public void ResetWebs()
    {
        if (GameManager.cpIndex == 1)
        {
            transform.position = CheckPoint1.transform.position;
        }

        if (GameManager.cpIndex == 2)
        {
            transform.position = CheckPoint2.transform.position;
            Platform1.GetComponent<fplatform2>().fp.SetUnUsed();
            Glider1.GetComponent<glider2>().trig.GetComponent<pu_glide>().reactivate();
        }

        if (GameManager.cpIndex == 3)
        {
            transform.position = CheckPoint3.transform.position;
            Glider1.GetComponent<trampo2>().trig.GetComponent<pu_trampo>().reactivate();
        }

        if (GameManager.cpIndex == 4)
        {
            transform.position = CheckPoint4.transform.position;
            Glider1.GetComponent<trampo2>().trig.GetComponent<pu_trampo>().reactivate();
            ///Web1.GetComponent<BigWeb2>().reset1();

        }

    }


}
