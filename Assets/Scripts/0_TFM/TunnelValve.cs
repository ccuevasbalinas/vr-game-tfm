using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class TunnelValve : MonoBehaviour
{
    [Header("Valve Tunnel")]
    [SerializeField] private ScriptableEvent _OnActivateValve;
    private XRKnob _xrKnob;
    private bool _check = true;

    private void Awake()
    {
        _xrKnob = GetComponent<XRKnob>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_check)
        {
            if(_xrKnob.value >= 3) 
            {
                DeactivateKnob();
                _OnActivateValve.Raise();
                Debug.Log("Hola valvula");
            }
        }
    }

    private void DeactivateKnob()
    {
        _xrKnob.enabled = false;
        _check = false;
    }

}
