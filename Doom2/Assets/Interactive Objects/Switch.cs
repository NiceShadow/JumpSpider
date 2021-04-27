using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public class Switch : MonoBehaviour
{
    bool switchState;
    public Material mActive, mInactive;

    MeshRenderer meshRenderer;

    public UnityEvent onActivationEvents, onDeactivationEvents;

    void Start()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    private void OnMouseDown()
    {
        if ((transform.position - Camera.main.transform.position).magnitude > 6.66f) return;

        //If return got called, the rest won't be executed
        if (switchState == true)
        {
            switchState = false;
            meshRenderer.material = mInactive;
            onDeactivationEvents.Invoke();
        }
        else
        {
            switchState = true;
            meshRenderer.material = mActive;
            onActivationEvents.Invoke();
        }

        /*
        switchState = !switchState;
        meshRenderer.material = switchState ? mActive : mInactive;
        */
    }
}
