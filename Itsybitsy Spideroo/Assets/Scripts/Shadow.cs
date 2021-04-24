using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    public SpriteRenderer shadowRef;
    // Start is called before the first frame update
    void Start()
    {
        shadowRef.material.color = new Color(1f, 1f, 1f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit1 = Physics2D.Raycast(new Vector2(transform.position.x + 0.07f, transform.position.y), -Vector2.up, 1f);
        RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(transform.position.x - 0.07f, transform.position.y), -Vector2.up, 1f);
        if (hit1 && hit2)
        {
            float opacity = 1 - hit1.distance;
            shadowRef.material.color = new Color(1f, 1f, 1f, opacity * 0.7f);
            shadowRef.transform.position = new Vector2(hit1.point.x, hit1.point.y -0.1f);
        }
        else
        {
            shadowRef.material.color = new Color(1f, 1f, 1f, 0.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
    private void OnTriggerExit2D(Collider2D collision)
    {

    }
}
