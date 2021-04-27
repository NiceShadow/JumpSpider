using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPlat : MonoBehaviour
{
    public GameObject targetRef;
    public GameObject par;
    public SpriteRenderer targetRef2;

    bool used;
    public static int platformNumber;
    // Start is called before the first frame update
    void Start()
    {
        targetRef2.material.color = new Color(1f, 1f, 1f, 0.3f);
        targetSprite = targetRef.GetComponent<SpriteRenderer>();
        targetSprite.enabled = false;
        platformNumber = par.GetComponent<fplatform2>().numberStartingAt1;
        Debug.Log(par.GetComponent<fplatform2>().numberStartingAt1);
    }

    SpriteRenderer targetSprite;
    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !used)
        {
            GameManager.onFinalPlatfrom = true;
            GameManager.Target = targetRef.transform.position;
            GameManager.currentlyOnPlatNumber = platformNumber;
            GameManager.currentFinalPlat = gameObject;
            targetRef2.material.color = new Color(1f, 1f, 1f, 1f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.onFinalPlatfrom = false;
            targetRef2.material.color = new Color(1f, 1f, 1f, 0.3f);
        }
    }

    public void SetUsed()
    {
        targetRef2.enabled = false;
        used = true;
    }

    public void SetUnUsed()
    {
        targetRef2.enabled = true;
        used = false;
        targetRef2.material.color = new Color(1f, 1f, 1f, 0.3f);
    }
}
