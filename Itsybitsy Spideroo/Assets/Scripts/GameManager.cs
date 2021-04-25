using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameObject spiderRef;
    public static bool p_trampoline = false;
    public static bool p_glide = false;
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

    public static void AcitvateTrampo()
    {
        p_trampoline = true;
        p_glide = false;
        spiderRef.GetComponent<Player>().setGlideEffect(p_glide);
    }
    public static void AcitvateGlide()
    {
        p_trampoline = false;
        p_glide = true;
        spiderRef.GetComponent<Player>().setGlideEffect(p_glide);
    }

    public static float velocitySize()
    {

        return spiderRef.GetComponent<Player>().myRigidbody.velocity.y;
    }

}
