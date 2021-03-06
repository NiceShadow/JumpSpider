using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public BoxCollider2D col;
    public SpriteRenderer webRef;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        webRef.enabled = GameManager.p_trampoline;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (col.enabled && GameManager.p_trampoline)
            GameManager.getSpiderRef().GetComponent<Player>().JumpOnTrampoline();
    }
}
