using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pu_trampo : MonoBehaviour
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
        GameManager.AcitvateTrampo();
        GameObject.Destroy(gameObject);
    }
}
