using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountActions : MonoBehaviour
{
    [Header("Event to be raised after complete actions")]
    [SerializeField] private ScriptableEvent _OnActivateEvent;
    [Header("Number of actions to be completed")]
    [SerializeField] private int _totalActions = 4;
    private int _currentActivatedActions = 0;

    public void IncrementActions()
    {
        _currentActivatedActions++;
        Debug.Log("Events activated: " + _currentActivatedActions.ToString());
        if (_currentActivatedActions == _totalActions)
        {
            Debug.Log("All events activated");
            _OnActivateEvent.Raise();
        }
    }
}
