using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigWeb : MonoBehaviour
{
    public SpriteRenderer web;
    public GameObject webRef;
    public SpriteRenderer brokenWeb;
    public GameObject webParent;
    BoxCollider2D colliderRef;
    public GameObject platformCollider;
    // Start is called before the first frame update
    void Start()
    {
        colliderRef = platformCollider.GetComponent<BoxCollider2D>();
        brokenWeb.material.color = new Color(1f, 1f, 1f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.velocitySize() < -webParent.GetComponent<BigWeb2>().speedToDestroy*12)
        {
            breakWeb();
        }

    }

    void breakWeb()
    {
        colliderRef.enabled = false;
        webRef.GetComponent<Animator>().SetTrigger("destroy");
        brokenWeb.material.color = new Color(1f, 1f, 1f, 1f);
    }
}
