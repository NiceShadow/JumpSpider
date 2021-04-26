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

    public static int cpIndex;


    public static Player spider;

    public static UI_Script ui;


    //sounds
    public AudioSource[] sounds;
    public static AudioSource a1;
    public static AudioSource a2;
    public static AudioSource a3;
    public static AudioSource a4;
    public static AudioSource a5;
    public static AudioSource a6;
    public static AudioSource a7;
    public static AudioSource a8;
    public static AudioSource a9;
    public static AudioSource a10;
    public static AudioSource a11;
    public static AudioSource a12;
    public static AudioSource a13;
    public static AudioSource a14;
    public static AudioSource a15;


    // Start is called before the first frame update
    void Start()
    {
        spiderRef = GameObject.Find("spiderTest");
        ui = uiRef.GetComponent<UI_Script>();
        spider = spiderRef.GetComponent<Player>();
        SetRatio(9, 16);

        sounds = GetComponents<AudioSource>();
        a1 = sounds[0];
        a2 = sounds[1];
        a3 = sounds[2];
        a4 = sounds[3];
        a5 = sounds[4];
        a6 = sounds[5];
        a7 = sounds[6];
        a8 = sounds[7];
        a9 = sounds[8];
        a10 = sounds[9];
        a11 = sounds[10];
        a12 = sounds[11];
        a13 = sounds[12];
        a14 = sounds[13];
        a15 = sounds[14];

    }





    // Update is called once per frame
    void Update()
    {
        
    }

    void SetRatio(float w, float h)
    {
        if ((((float)Screen.width) / ((float)Screen.height)) > w / h)
        {
            Screen.SetResolution((int)(((float)Screen.height) * (w / h)), Screen.height, true);
        }
        else
        {
            Screen.SetResolution(Screen.width, (int)(((float)Screen.width) * (h / w)), true);
        }
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

    public static void play_a1()
    {
        a1.Play();
    }
    public static void play_a2()
    {
        a2.Play();
    }
    public static void play_a3()
    {
        a3.Play();
    }
    public static void play_a4()
    {
        a4.Play();
    }
    public static void play_a5()
    {
        a5.Play();
    }
    public static void play_a6()
    {
        a6.Play();
    }
    public static void play_a7()
    {
        a7.Play();
    }
    public static void play_a8()
    {
        a8.Play();
    }
    public static void play_a9()
    {
        a9.Play();
    }
    public static void play_a10()
    {
        a10.Play();
    }
    public static void play_a11()
    {
        a11.Play();
    }
    public static void play_a12()
    {
        a12.Play();
    }
    public static void play_a13()
    {
        a13.Play();
    }
    public static void play_a14()
    {
        a14.Play();
    }
    public static void play_a15()
    {
        a15.Play();
    }



}
