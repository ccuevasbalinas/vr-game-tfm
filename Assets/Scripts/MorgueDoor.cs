using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorgueDoor : MonoBehaviour
{
    [SerializeField] private bool isOpen = false;
    
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public bool IsOpen()
    {
        return isOpen;
    }

    public void OpenDoor()
    {
        animator.Play("anim_open_door");
        Debug.Log("abre");
        isOpen = true;
    }

    public void CloseDoor()
    {
        animator.Play("anim_close_door");
        isOpen = false;
    }

    public void HandleDoorState()
    {
        if(isOpen)
        {
            CloseDoor();
        }
        else
        {
            OpenDoor();
        }
    }
}
