using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearGameObject : MonoBehaviour
{
    #region Variables
    /// <summary>
    /// List of game objects must be disable after a period of time.
    /// </summary>
    public List<GameObject> objectsToDisable;

    /// <summary>
    /// Maximum time of visibility of those game objects that want to be disabled.
    /// </summary>
    public float timeToDisappear = 2.0f;

    /// <summary>
    /// Scriptable event asociatedto the fact of disability the game objects.
    /// </summary>
    public ScriptableEvent OnDisappearEvent;
    #endregion

    #region Functions
    /// <summary>
    /// Function that calls a coroutine that disable the game objects after a period of time.
    /// </summary>
    public void objectsToDisableFunction() => StartCoroutine(Disable());

    /// <summary>
    /// Coroutine that handles the disability of the game objects after a period of time.
    /// </summary>
    public IEnumerator Disable()
    {
        float timer = 0.0f;
        while (timer <= timeToDisappear)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        // Destroy each game object from the list once the 'timeToDisappear' seconds has been reached.
        OnDisappearEvent.Raise();
        foreach (GameObject gameObject in objectsToDisable) Destroy(gameObject);
    }
    #endregion
}
