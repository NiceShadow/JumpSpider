using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameObject spiderRef;
    public static bool p_trampoline = false;
    public static bool p_glide = false;
    public static bool onFinalPlatfrom = false;
    public static Vector2 Target;
    public static GameObject currentFinalPlat;
    public Canvas uiRef;
    public GameObject Web1;


    public static Player spider;

    public static UI_Script ui;

    // Start is called before the first frame update
    void Start()
    {
        spiderRef = GameObject.Find("spiderTest");
        ui = uiRef.GetComponent<UI_Script>();
        spider = spiderRef.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static GameObject getSpiderRef()
    {
        return spiderRef;
    }

    public static void AcitvateTrampo()
    {
        p_trampoline = true;
        p_glide = false;
        spiderRef.GetComponent<Player>().setGlideEffect(p_glide);
    }
    public static void AcitvateGlide()
    {
        p_trampoline = false;
        p_glide = true;
        spiderRef.GetComponent<Player>().setGlideEffect(p_glide);
    }

    public static float velocitySize()
    {

        return spiderRef.GetComponent<Player>().myRigidbody.velocity.y;
    }

    public static void bremsen(bool destroyHelmet)
    {
        spiderRef.GetComponent<Player>().myRigidbody.velocity = new Vector2(0f, -1.5f);
        spiderRef.GetComponent<Player>().destroyMyHelmet(destroyHelmet);
    }

    public static void updateUI()
    {
        ui.jumpCounter.text = spider.JumpsUsed.ToString();
    }

    public static void showGameOver()
    {
        ui.deathScreen1.SetActive(true);
    }

    public static void hideGameOverRetry()
    {
        ui.deathScreen1.SetActive(false);
        spider.ResetWebs();
        spider.die(false);
    }



}
