using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurnOnOffLights : MonoBehaviour
{
    [SerializeField] private UnityEvent action;


    public void turnOffOnLights(){
        action.Invoke();
    }


}
