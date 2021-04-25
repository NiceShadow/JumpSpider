using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    GameObject spiderRef;
    public GameObject stonePrefab;
    public float CameraSpeedUp = 0.5f;
    public float CameraSpeedDown = 3f;
    public float clampBottomHeight = 0f;
    // Start is called before the first frame update
    void Start()
    {
        spiderRef = GameObject.Find("spiderTest");
        StartStones();

    }

    // Update is called once per frame
    void Update()
    {
        if (spiderRef.transform.position.y > transform.position.y +2f)
        {
            transform.position = new Vector3(0, Mathf.Lerp(transform.position.y, spiderRef.transform.position.y - 2f, CameraSpeedUp * Time.deltaTime), -10f);
        }

        if (spiderRef.transform.position.y < transform.position.y - 2f && transform.position.y > clampBottomHeight)
        {
            transform.position = new Vector3(0, Mathf.Lerp(transform.position.y, spiderRef.transform.position.y + 2f, CameraSpeedDown * Time.deltaTime), -10f);
        }

    }
    void StartStones()
    {
        Invoke("throwAStone", 1f);
    }

    void throwAStone()
    {
        Instantiate(stonePrefab, new Vector3(Random.Range(-6f, 6f), transform.position.y + 22f, 0), Quaternion.identity);
        Invoke("throwAStone", Random.Range(2f, 8f));
    }
}
