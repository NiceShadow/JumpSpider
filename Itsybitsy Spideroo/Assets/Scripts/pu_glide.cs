using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pu_glide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.play_a10();
            GameManager.AcitvateGlide();
            gameObject.SetActive(false);
        }
    }

    public void reactivate()
    {
        gameObject.SetActive(true);
    }
}
