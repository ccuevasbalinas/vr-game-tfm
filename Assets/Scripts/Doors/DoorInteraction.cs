using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public bool doorOpened = false;
    private Animator doorAnim;
    public GameObject player;
    private Vector3 doorForward;
    private Vector3 doorOrigin;
    private Vector3 playerPos;

    private bool canInteract = true;
    public float animTime;
    public bool isOpenedBack = false;       //  Debera cambiarse si la puerta se encuentra inicialmente abierta
    public bool isLocked = false;
    private bool soundOn = false;
    

    public AudioSource audioSource;

    [Header("Open door")]
    public AudioClip[] audioClipArrayOpen;

    [Header("Close door")]
    public AudioClip[] audioClipArrayClose;

    [Header("Locked door")]
    public AudioClip audioClipLocked;



    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Vector3 doorChildren = gameObject.GetComponentInChildren<Transform>().position;
        doorAnim = gameObject.GetComponent<Animator>();
        if(!doorOpened)
            //doorForward = transform.TransformDirection(Vector3.forward);
            doorForward = transform.right;
        else
            doorForward = transform.forward;
        doorOrigin = transform.position + new Vector3(transform.forward.x * doorChildren.z/2,transform.forward.y * doorChildren.z/2,transform.forward.z * doorChildren.z/2);
    }

    public void PlayAnimation(){
        
        if(!soundOn){

            if(!isLocked){
                playerPos = player.transform.position;
                playerPos = new Vector3(playerPos.x, doorOrigin.y ,playerPos.z);
                Vector3 playerToDoor = doorOrigin - playerPos;


                if(Vector3.Dot(doorForward,playerToDoor) > 0){
                    if(doorOpened){
                        closeDoor();
                    }
                    else{                    
                        doorAnim.Play("doorOpenAlt", 0, 0.0f);
                        doorOpened = true;
                        isOpenedBack = false;
                        playSoundDoor(false); 
                        StartCoroutine(blockedInteraction());
                    }      
                }
                else{
                    if(doorOpened){
                        closeDoor();
                    }
                    else{
                        doorAnim.Play("doorOpen", 0, 0.0f);
                        doorOpened = true;
                        isOpenedBack = true;
                        playSoundDoor(false); 
                        StartCoroutine(blockedInteraction());
                    }
                }   
            }
            else{
                audioSource.PlayOneShot(audioClipLocked);
                StartCoroutine(blockedInteraction());
            }
        }
        
    }

    public void closeDoor(){
        if(isOpenedBack)
            doorAnim.Play("doorClose", 0, 0.0f);
        else
            doorAnim.Play("doorCloseAlt", 0, 0.0f); 
        doorOpened = false;  
        playSoundDoor(true);

        //      Solo bloquea la interaccion cuando el personaje cierra la puerta
        if(!isLocked)
            StartCoroutine(blockedInteraction());
    }


    public void openDoor(){
        isLocked = false;
        PlayAnimation();
    }



    public void setLocked(bool locked){
        isLocked = locked;
    }


    public void closeLocked(){
        isLocked = true;
        StartCoroutine(waitClose());
    }

    void playSoundDoor(bool close){
        if(close)
            audioSource.PlayOneShot(RandomClip(audioClipArrayClose));
        else
            audioSource.PlayOneShot(RandomClip(audioClipArrayOpen));
    }

    AudioClip RandomClip(AudioClip[] audioClipArray){
        return audioClipArray[Random.Range(0, audioClipArray.Length)];
    }

    IEnumerator blockedInteraction(){
        soundOn = true;

        //AnimatorClipInfo[] animationClipInfo = doorAnim.GetCurrentAnimatorClipInfo(0);
        //yield return new WaitForSeconds(animationClipInfo[0].clip.length);
        yield return new WaitWhile (()=> audioSource.isPlaying);
        //yield return new WaitForSeconds(blockedSeconds);
        soundOn = false;
    }


    IEnumerator waitClose(){
        yield return new WaitWhile (()=> audioSource.isPlaying);
        if(doorOpened)
            closeDoor();
    }


}
