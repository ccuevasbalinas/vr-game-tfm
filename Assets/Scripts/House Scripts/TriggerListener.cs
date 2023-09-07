using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerListener : MonoBehaviour
{
    #region Variables
    /// <summary>
    /// Tag associated to an specific object that is going to be triggered.
    /// </summary>
    public string objectTag;

    /// <summary>
    /// Scripatble event associated to the trigger once has collided with the game object whose tag is the 'objectTag'.
    /// </summary>
    public ScriptableEvent OnTrigger;

    /// <summary>
    /// Boolean created for make the Scripatble Event appear and then make the trigger dissappear..
    /// </summary>
    public bool isOneTimeTrigger = false;
    #endregion

    #region Functions
    /// <summary>
    /// Upon collision with another GameObject, this GameObject will reverse direction.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == objectTag) 
        {
            OnTrigger.Raise();
            if (isOneTimeTrigger) this.gameObject.SetActive(false);
        }
    }
    #endregion
}
