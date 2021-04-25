using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameObject spiderRef;
    // Start is called before the first frame update
    void Start()
    {
        spiderRef = GameObject.Find("spiderTest");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static GameObject getSpiderRef()
    {
        return spiderRef;
    }

}
