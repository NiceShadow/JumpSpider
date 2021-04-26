using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject warning;
    public float speed = 5f;
    bool updateWarning = true;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        if (updateWarning)
        {
            warning.transform.position = new Vector3(transform.position.x, Camera.main.transform.position.y + 11f, 0);
            if (transform.position.y < warning.transform.position.y)
            {
                Destroy(warning);
                updateWarning = false;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!GameManager.spider.finalJumping)
            {
                GameManager.spider.die(true);
                GameManager.showGameOver();
            }

        }
    }



}
