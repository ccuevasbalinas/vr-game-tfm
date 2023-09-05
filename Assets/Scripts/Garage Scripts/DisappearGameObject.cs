using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearGameObject : MonoBehaviour
{
    public List<GameObject> objectsToDisable;
    public float timeToDisappear = 2.0f;
    public ScriptableEvent OnDisappearEvent;

    public void objectsToDisableFunction()
    {
        StartCoroutine(Disable());
    }

    public IEnumerator Disable()
    {
        float timer = 0;
        while (timer <= timeToDisappear)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        // Destroy each game object from the list once the 'timeToDisappear' seconds has been reached.
        OnDisappearEvent.Raise();
        foreach (GameObject gameObject in objectsToDisable) Destroy(gameObject);
    
      
    }
}
