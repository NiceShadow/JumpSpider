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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 1f);
        if (hit)
        {
            float opacity = 1 - hit.distance;
            shadowRef.material.color = new Color(1f, 1f, 1f, opacity * 0.7f);
            shadowRef.transform.position = new Vector2(hit.point.x, hit.point.y -0.1f);
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
