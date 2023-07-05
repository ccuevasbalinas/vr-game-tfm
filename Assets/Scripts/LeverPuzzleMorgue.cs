using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPuzzleMorgue : MonoBehaviour
{
    [Header("Lever Morgue Puzzle")]
    [SerializeField] private List<GameObject> _doors;
    [SerializeField] private ScriptableEvent _OnOpenMorgue;
    private int _morgueDoors;
    private int _morgueClosedDoors;

    public void Awake()
    {
        _morgueDoors = _doors.Count;
        //Debug.Log("Numero de puertas cerradas :" + _morgueClosedDoors.ToString() + "/" + _morgueDoors.ToString());
        UpdateClosedDoorsCount();
    }

    public void UpdateClosedDoorsCount()
    {
        _morgueClosedDoors = 0;
        foreach (var door in _doors)
        {
            if (door.activeSelf == false)
            {
                _morgueClosedDoors = _morgueClosedDoors + 1;
            }
        }
        Debug.Log("Numero de puertas cerradas :" + _morgueClosedDoors.ToString() + "/" + _morgueDoors.ToString());
        CheckClosedDoors();
    }

    public void CheckClosedDoors()
    {
        if (_morgueClosedDoors == _morgueDoors)
        {
            _OnOpenMorgue.Raise();
        }
    }
}
