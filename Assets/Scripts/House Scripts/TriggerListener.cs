using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerListener : MonoBehaviour
{
    public string objectTag;
    public ScriptableEvent OnTrigger;

    // Upon collision with another GameObject, this GameObject will reverse direction.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == objectTag) 
        {
            OnTrigger.Raise();
        }
    }
}
