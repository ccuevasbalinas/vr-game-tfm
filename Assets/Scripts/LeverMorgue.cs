using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverMorgue : MonoBehaviour
{
    [Header("Lever Morgue")]
    [SerializeField] private List<GameObject> _doors;
    [SerializeField] private List<MorgueDoor> _doorsMorgue;
    [SerializeField] private ScriptableEvent _OnActivateLever;

    public void ChangeDoorsState()
    {
        //foreach (GameObject door in _doors)
        foreach (var door in _doorsMorgue)
        {
            door.HandleDoorState();
        }
        _OnActivateLever.Raise();
    }
}
