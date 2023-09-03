using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class StoryTeller : MonoBehaviour
{
    [SerializeField] private List<AudioClip> storyAudios;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private ActionBasedControllerManager rightHandController;
    [SerializeField] private ActionBasedControllerManager leftHandController;
    [SerializeField] private SceneTransitionManager sceneTransitionManager;

    private int currentAudioIndex = 0;
    private float timeToWait = 0.0f;
    private float lastAudioTime = 0.0f;
    private int count = 0;

    private void Awake()
    {
        audioSource.clip = storyAudios[0];
        timeToWait = storyAudios[0].length;
        lastAudioTime = storyAudios[storyAudios.Count - 1].length;
    }

    public void StoryMoment()
    {
        if(currentAudioIndex <= storyAudios.Count - 1)
        {
            Debug.Log("Audio " + (currentAudioIndex + 1).ToString());
            audioSource.clip = storyAudios[currentAudioIndex];
            timeToWait = storyAudios[currentAudioIndex].length;
            audioSource.Play();
            currentAudioIndex = currentAudioIndex + 1;
            StartCoroutine(XRControllerHandler(timeToWait + 1.0f));
        }
    }

    private IEnumerator XRControllerHandler(float time)
    {
        rightHandController.enabled = false;
        leftHandController.enabled = false;
        yield return new WaitForSeconds(time);
        rightHandController.enabled = true;
        leftHandController.enabled = true;
    }

    public void LastStoryMoment()
    {
        if(count == 0)
            StartCoroutine(EndScene(lastAudioTime + 2.0f));
        count = count + 1;   
    }

    private IEnumerator EndScene(float time)
    {
        yield return new WaitForSeconds(time);
        sceneTransitionManager.GoToScene(0);
    }
}
