using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLooper : MonoBehaviour
{

    public AudioSource[] audioSourceArray;
    public AudioClip[] audioClipArray;

    int nextClip = 0;
    double duration = 0.0f;
    int toggle = 0;

    double nextStartTime = AudioSettings.dspTime+2.0f;
    void Update () {

    if(AudioSettings.dspTime > nextStartTime - 1) {

        AudioClip clipToPlay = audioClipArray[nextClip];

        // Loads the next Clip to play and schedules when it will start
        audioSourceArray[toggle].clip = clipToPlay;
        audioSourceArray[toggle].PlayScheduled(nextStartTime);

        // Checks how long the Clip will last and updates the Next Start Time with a new value
        double duration = (double)clipToPlay.samples / clipToPlay.frequency;
        nextStartTime = nextStartTime + duration;

        // Switches the toggle to use the other Audio Source next
        toggle = 1 - toggle;

        // Increase the clip index number, reset if it runs out of clips
        nextClip = nextClip < audioClipArray.Length - 1 ? nextClip + 1 : 0;
        }
    }


    public void finalize(){
        
    }

}
