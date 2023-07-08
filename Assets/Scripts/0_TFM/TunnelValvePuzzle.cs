using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelValvePuzzle : MonoBehaviour
{
    [Header("Valve Tunnels Puzzle")]
    [SerializeField] private ScriptableEvent _OnActivateTunnelsLight;
    [SerializeField] private int _totalValves = 4;
    private int _currentActivatedValves = 0;
    
    public void ActivateValve()
    {
        _currentActivatedValves++;
        Debug.Log("Number of valve activated: " +  _currentActivatedValves.ToString());
        if(_currentActivatedValves == _totalValves)
        {
            Debug.Log("All valves activated");
            _OnActivateTunnelsLight.Raise();
        }
    }


}
