using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBox : MonoBehaviour
{
    public bool isTop;
    public GameObject platformCollider;
    BoxCollider2D colliderRef;
    // Start is called before the first frame update
    void Start()
    {
        colliderRef = platformCollider.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isTop)
        {
            colliderRef.enabled = true;
        }
        else
        {
            colliderRef.enabled = false;
        }
    }
}
