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
    public float clampTopHeight = 1f;

    public Vector2 cp1_StoneSpawnFrame = new Vector2(5, 12);
    public Vector2 cp2_StoneSpawnFrame = new Vector2(5, 12);
    public Vector2 cp3_StoneSpawnFrame = new Vector2(5, 12);
    public Vector2 cp4_StoneSpawnFrame = new Vector2(5, 12);

    // Start is called before the first frame update
    void Start()
    {
        spiderRef = GameObject.Find("spiderJana");
        StartStones();

    }

    // Update is called once per frame
    void Update()
    {
        if (spiderRef.transform.position.y > transform.position.y +2f && transform.position.y < clampTopHeight)
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
        if (GameManager.cpIndex == 0)
        {
            Invoke("throwAStone", 1f);
        }
        if (GameManager.cpIndex == 1)
        {
            Instantiate(stonePrefab, new Vector3(Random.Range(-6f, 6f), transform.position.y + Random.Range(20f, 25f), 0), Quaternion.identity);
            Invoke("throwAStone", Random.Range(cp1_StoneSpawnFrame.x, cp1_StoneSpawnFrame.y));
        }
        if (GameManager.cpIndex == 2)
        {
            Instantiate(stonePrefab, new Vector3(Random.Range(-6f, 6f), transform.position.y + Random.Range(20f, 25f), 0), Quaternion.identity);
            Invoke("throwAStone", Random.Range(cp2_StoneSpawnFrame.x, cp2_StoneSpawnFrame.y));
        }
        if (GameManager.cpIndex == 3)
        {
            Instantiate(stonePrefab, new Vector3(Random.Range(-6f, 6f), transform.position.y + Random.Range(20f, 25f), 0), Quaternion.identity);
            Invoke("throwAStone", Random.Range(cp3_StoneSpawnFrame.x, cp3_StoneSpawnFrame.y));
        }
        if (GameManager.cpIndex == 4)
        {
            Instantiate(stonePrefab, new Vector3(Random.Range(-6f, 6f), transform.position.y + Random.Range(20f, 25f), 0), Quaternion.identity);
            Invoke("throwAStone", Random.Range(cp4_StoneSpawnFrame.x, cp4_StoneSpawnFrame.y));
        }
    }
}
