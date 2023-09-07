using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundActivation : MonoBehaviour
{
    #region Variables
    /// <summary>
    /// Audio source to be sound after a specific period of time.
    /// </summary>
    public AudioSource audioSource;

    /// <summary>
    /// Audio clib to be played after a specific period of time.
    /// </summary>
    public AudioClip soundClip;

    /// <summary>
    /// Specific period of time to be used for playing a sound.
    /// </summary>
    public float activationTime = 2.0f;
    #endregion

    #region Functions
    /// <summary>
    /// Function that activated a coroutine that is going to handle the aplication of a sound after a specific period of time.
    /// </summary>
    void Start() => StartCoroutine(ActivateSoundAfterDelay());

    /// <summary>
    /// Coroutine that after a specific period of time, plays a sound.
    /// </summary>
    private IEnumerator ActivateSoundAfterDelay()
    {
        yield return new WaitForSeconds(activationTime);
        PlaySound();
    }

    /// <summary>
    /// Function that assign the sound to the audio source and plays it.
    /// </summary>
    private void PlaySound()
    {
        audioSource.clip = soundClip;
        audioSource.Play();
    }
    #endregion
}
