using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBox : MonoBehaviour
{
    public bool isTop;
    public GameObject platformCollider;
    BoxCollider2D colliderRef;
    public bool isTrampo;
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
            if (isTrampo)
            {
                if(GameManager.p_trampoline)
                    colliderRef.enabled = true;
                else
                    colliderRef.enabled = false;
            }
            else
                colliderRef.enabled = true;
        }
        else
        {
            colliderRef.enabled = false;
        }
    }
}
