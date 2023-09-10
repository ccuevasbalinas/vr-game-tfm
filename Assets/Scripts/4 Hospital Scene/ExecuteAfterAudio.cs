using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExecuteAfterAudio : MonoBehaviour
{

    [SerializeField] private UnityEvent action;
    //public AudioSource audioSource;

    public void executeAfterAudio(AudioClip clip){
        Debug.Log("wait");
        float duration = (float)clip.samples / clip.frequency;
        StartCoroutine(waitAudio(duration));
    }

    IEnumerator waitAudio(float duration){
        //yield return new WaitWhile (()=> audioSource.isPlaying);
        yield return new WaitForSeconds(duration + 1);
        action.Invoke();
        Debug.Log("Daleee");
    }
}
