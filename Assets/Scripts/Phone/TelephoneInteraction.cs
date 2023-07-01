using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TelephoneInteraction : MonoBehaviour
{
    [Header("Audio telefono")]
    public AudioClip audioClipVoicemail;

    [Header("Audio nuevo mensaje")]
    public AudioClip audioClipNewVoicemail;
    private AudioSource audioSource;


    public bool isPlayed = false;

    public bool canChange = true;


    [Header("Button")]
    public GameObject button;
    public float blinkDuration = 0.5f;
    private Material buttonMaterial;

    [SerializeField] private UnityEvent afterVoicemailEnd;
    [SerializeField] private UnityEvent beforeVoicemail;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        buttonMaterial = button.GetComponent<Renderer>().material;
    }


    private void Update() {
        if(!isPlayed){
            if(canChange){
                StartCoroutine(voicemailBlink());
            }            
        }
    }



    public void playVoiceMails(){
        if(!isPlayed){
            beforeVoicemail.Invoke();
            audioSource.PlayOneShot(audioClipVoicemail);
            isPlayed = true;
            StartCoroutine(waitAudioFinish());
            buttonMaterial.DisableKeyword("_EMISSION");
        }
    }


    private IEnumerator voicemailBlink(){
        canChange = false;
        buttonMaterial.EnableKeyword("_EMISSION");
        yield return new WaitForSeconds(blinkDuration);
        buttonMaterial.DisableKeyword("_EMISSION");
        yield return new WaitForSeconds(blinkDuration);
        canChange = true;
    }

    private IEnumerator waitAudioFinish(){
        yield return new WaitWhile (()=> audioSource.isPlaying);
        Debug.Log("Termino");
        afterVoicemailEnd.Invoke();
    }

    public void newMessage(){
        audioSource.PlayOneShot(audioClipNewVoicemail);
    }

}
