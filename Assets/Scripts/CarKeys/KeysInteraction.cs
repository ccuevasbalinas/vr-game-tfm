using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeysInteraction : MonoBehaviour
{

    [Header("Events")]
    [SerializeField] private UnityEvent keysEvent;
    public bool canInteract = false;

    public void collectKeys(){
        if(canInteract)
            keysEvent.Invoke();
    }

    public void setInteractivity(bool value){
        canInteract = value;
    }



}
