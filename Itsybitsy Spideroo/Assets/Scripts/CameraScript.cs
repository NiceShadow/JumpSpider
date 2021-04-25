using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    GameObject spiderRef;
    public float clampBottomHeight = 0f;
    // Start is called before the first frame update
    void Start()
    {
        spiderRef = GameObject.Find("spiderTest");
    }

    // Update is called once per frame
    void Update()
    {
        if (spiderRef.transform.position.y > transform.position.y +2f)
        {
            transform.position = new Vector3(0, Mathf.Lerp(transform.position.y, spiderRef.transform.position.y - 2f, 0.5f * Time.deltaTime), -10f);
        }

        if (spiderRef.transform.position.y < transform.position.y - 2f && transform.position.y > clampBottomHeight)
        {
            transform.position = new Vector3(0, Mathf.Lerp(transform.position.y, spiderRef.transform.position.y + 2f, 3f * Time.deltaTime), -10f);
        }

    }
}
