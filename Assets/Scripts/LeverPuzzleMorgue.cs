using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPuzzleMorgue : MonoBehaviour
{
    [Header("Lever Morgue Puzzle")]
    [SerializeField] private List<MorgueDoor> _doors;
    [SerializeField] private ScriptableEvent _OnOpenMorgue;
    private int _morgueDoors;
    private int _morgueClosedDoors;

    public void Awake()
    {
        _morgueDoors = _doors.Count;
        UpdateClosedDoorsCount();
    }

    public void UpdateClosedDoorsCount()
    {
        _morgueClosedDoors = 0;
        foreach (var door in _doors)
        {
            if (!door.IsOpen())
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
            Debug.Log("ABRE LA MORGUE");
            _OnOpenMorgue.Raise();
        }
    }

}
