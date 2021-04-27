using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenScript : MonoBehaviour
{
    public float StampMinSec = 7f;
    public float StampMaxSec = 12f;

    public GameObject b1;
    public GameObject b2;
    public GameObject b3;
    public GameObject b4;
    public GameObject b5;
    int rand;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("doStuff", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void doStuff()
    {
        if (GameManager.cpIndex == 4)
        {
        GameManager.spider.hasGlide = false;
        GameManager.p_trampoline = false;
        GameManager.p_glide = false;
        GameManager.spider.Glider2.GetComponent<glider2>().trig.GetComponent<pu_glide>().hideAgain();
        GameManager.spider.Trampoline2.GetComponent<trampo2>().trig.GetComponent<pu_trampo>().hideAgain();


        rand = Random.Range(1, 6);

                if (rand == 1)
                {
                    b1.SetActive(true);
                    b2.SetActive(false);
                    b3.SetActive(false);
                    b4.SetActive(false);
                }
                if (rand == 2)
                {
                    b1.SetActive(false);
                    b2.SetActive(true);
                    b3.SetActive(false);
                    b4.SetActive(false);
                    GameManager.spider.Trampoline2.GetComponent<trampo2>().trig.GetComponent<pu_trampo>().reactivate();
                }
                if (rand == 3)
                {
                    b1.SetActive(false);
                    b2.SetActive(false);
                    b3.SetActive(true);
                    b4.SetActive(false);
                    GameManager.spider.Glider2.GetComponent<glider2>().trig.GetComponent<pu_glide>().reactivate();
                }
                if (rand == 4)
                {
                    b1.SetActive(false);
                    b2.SetActive(false);
                    b3.SetActive(false);
                    b4.SetActive(true);
                }
                if (rand == 5)
                {
                    b1.SetActive(false);
                    b2.SetActive(false);
                    b3.SetActive(false);
                    b4.SetActive(true);
                    GameManager.spider.Glider2.GetComponent<glider2>().trig.GetComponent<pu_glide>().reactivate();
                    GameManager.spider.Trampoline2.GetComponent<trampo2>().trig.GetComponent<pu_trampo>().reactivate();
                }
                if (rand == 6)
                {
                    b1.SetActive(false);
                    b2.SetActive(true);
                    b3.SetActive(false);
                    b4.SetActive(false);
                    GameManager.spider.Trampoline2.GetComponent<trampo2>().trig.GetComponent<pu_trampo>().reactivate();
                }

            
        }
        Invoke("doStuff", Random.Range(StampMinSec, StampMaxSec));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && GameManager.spiderRef.GetComponent<Player>().finalJumping)
        {
            GameManager.showWin();
        }
    }

}
