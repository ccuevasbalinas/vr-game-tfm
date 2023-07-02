using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchInteraction : MonoBehaviour
{
    
    public bool isUp = true;
    public Animator switchAnim;
    private AudioSource audioSource;

    [Header("Lights")]
    public Light[] lights;


    [Header("Materials")]
    public GameObject[] materials;


    [Header("Light up")]
    public AudioClip[] audioClipArrayUp;

    [Header("Light down")]
    public AudioClip[] audioClipArrayDown;


    private void Start() {
        audioSource = GetComponent<AudioSource>();
        if(isUp){
            switchAnim.Play("TurnUp", 0, 0.0f);
        }
        else{
            switchAnim.Play("TurnDown", 0, 0.0f);
        }
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].enabled = isUp;
            if(materials[i]){
                if(isUp)
                    materials[i].GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                else
                    materials[i].GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
            }
        }
    }

    
    public void SwitchLights(){
        Debug.Log("Apagateee");

        if(isUp){
            switchAnim.Play("TurnDown", 0, 0.0f);
            isUp = false;
        }
        else{
            switchAnim.Play("TurnUp", 0, 0.0f);
            isUp = true;
        }
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].enabled = isUp;
            if(materials[i]){
                if(isUp)
                    materials[i].GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                else
                    materials[i].GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
            }
        }
        playSound();
    }

    public void turnOffLights(){
        isUp = true;
        SwitchLights();
    }

    public void turnOnLights(){
        isUp = false;
        SwitchLights();
    }

    void playSound(){
        if(isUp)
            audioSource.PlayOneShot(RandomClip(audioClipArrayUp));
        else
            audioSource.PlayOneShot(RandomClip(audioClipArrayDown));
    }

    AudioClip RandomClip(AudioClip[] audioClipArray){
        return audioClipArray[Random.Range(0, audioClipArray.Length)];
    }

}
