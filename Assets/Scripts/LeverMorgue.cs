using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverMorgue : MonoBehaviour
{
    [Header("Lever Morgue")]
    [SerializeField] private List<GameObject> _doors;
    [SerializeField] private ScriptableEvent _OnActivateLever;

    public void ChangeDoorsState()
    {
        foreach (GameObject door in _doors)
        {
            if(door.activeSelf == true)
            {
                door.SetActive(false);
            }
            else
            {
                door.SetActive(true);
            }
        }
        _OnActivateLever.Raise();
    }
}
