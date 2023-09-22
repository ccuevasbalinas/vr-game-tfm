using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private InputActionReference _actionReference;
    [SerializeField] private GameObject pauseMenu;

    public UnityEvent _onActionPerformed;

    private void OnEnable()
    {
        _actionReference.action.performed += HandleOnActionPerformed;
    }

    private void OnDisable()
    {
        _actionReference.action.performed -= HandleOnActionPerformed;
    }

    private void HandleOnActionPerformed(InputAction.CallbackContext obj)
    {
        _onActionPerformed.Invoke();
    }

    public void CheckPauseMenuState()
    {
        if(pauseMenu.activeSelf)
            pauseMenu.SetActive(false);
        else 
            pauseMenu.SetActive(true);
    }
}
