using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAfterTimeElapsed : MonoBehaviour
{
    #region Variables
    /// <summary>
    /// Game object to be activated after a specific period of time.
    /// </summary>
    public GameObject gameObjectToActivate;

    /// <summary>
    /// Specific period of time to be used for activating a game object.
    /// </summary>
    public float time;
    #endregion

    #region Functions
    /// <summary>
    /// Function that calls a coroutine that handles the activation of a game object after a specific period of time.
    /// </summary>
    public void ActivateAfterTime() => StartCoroutine(ActivateAfterTimeCoroutine(gameObjectToActivate, time));

    /// <summary>
    /// Coroutine that handles the activation of a game object after a specific period of time.
    /// </summary>
    private IEnumerator ActivateAfterTimeCoroutine(GameObject gameObject, float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(true);
    }
    #endregion
}
