using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundActivation : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip soundClip; 
    public float activationTime = 2.0f;
    



    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(ActivateSoundAfterDelay());
    }

    private IEnumerator ActivateSoundAfterDelay()
    {
        // Espera durante el tiempo especificado
        yield return new WaitForSeconds(activationTime);

        // Activa el sonido
        PlaySound();
    }

    private void PlaySound()
    {
        // Asigna el AudioClip y reproduce el sonido
        audioSource.clip = soundClip;
        audioSource.Play();
    }
}
