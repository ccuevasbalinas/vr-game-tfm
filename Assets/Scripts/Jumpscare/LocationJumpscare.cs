using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Events;


public class LocationJumpscare : MonoBehaviour
{

    [Header("Audio")]
    public AudioClip[] audioClips;
    public AudioSource[] audioSources;

    [Header("Player")]
    public string playerTag = "Player";


    [Header("Animation")]
    private Animator anim;
    public string animationClipName;
    private Animation animationClip;

    [Header("Events")]
    [SerializeField] private UnityEvent jumpscareEvent;


    [Header("Director")]
    public PlayableDirector director;

    public bool destroyAfterExecute = true;
    public GameObject collision;

    private void Start() {
        director = gameObject.GetComponent<PlayableDirector>();
    }


    public void executeJumpscare(){
        if(director != null)
            director.Play();
        //playAnimation();
        jumpscareEvent.Invoke();
        playSound();
        if(destroyAfterExecute && collision!=null)
            collision.SetActive(false);
    }

    void playAnimation(){
        if(anim != null){
            anim.Play(animationClipName, 0, 0.0f);
        }
    }

    void playSound(){
        for (int i = 0; i < audioSources.Length; i++)
        {
            if(audioSources[i] != null && audioClips[i]){
                audioSources[i].PlayOneShot(audioClips[i]);
            }
        }

    }
}
