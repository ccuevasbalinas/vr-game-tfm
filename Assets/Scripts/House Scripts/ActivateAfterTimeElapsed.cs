using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAfterTimeElapsed : MonoBehaviour
{
    public GameObject gameObjectToActivate;
    public float time;

    public void ActivateAfterTime()
    {
        StartCoroutine(ActivateAfterTimeCoroutine(gameObjectToActivate, time));
    }

    private IEnumerator ActivateAfterTimeCoroutine(GameObject gameObject, float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("hola");
        gameObject.SetActive(true);
    }
}
