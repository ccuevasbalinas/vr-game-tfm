using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitcher : MonoBehaviour
{
    #region Variables
    /// <summary>
    /// Array that holds your two light sources.
    /// </summary>
    public Light[] lights;

    /// <summary>
    /// Integer that allocates the actual light index.
    /// </summary>
    private int _currentLightIndex = 0;

    /// <summary>
    /// Maximum time current light lasts.
    /// </summary>
    private float _switchInterval = 1.0f;

    /// <summary>
    /// Actual timer used for controlling who's the current light.
    /// </summary>
    private float _timer = 0.0f;
    #endregion variables

    #region Functions
    /// <summary>
    /// Initialize the first light at the beginning.
    /// </summary>
    void Start() => lights[_currentLightIndex].enabled = true;

    /// <summary>
    /// Function that calls a coroutine that makes the light switch change.
    /// </summary>
    public void EnableLightSwitch() => StartCoroutine(LightSwitch());


    /// <summary>
    /// Coroutine that makes the lights swich change.
    /// </summary>
    public IEnumerator LightSwitch()
    {
        // Update the timer.
        _timer += Time.deltaTime;

        // Check if it's time to switch lights.
        if (_timer >= _switchInterval)
        {
            // Disable the current light.
            lights[_currentLightIndex].enabled = false;

            // Switch to the other light.
            _currentLightIndex = (_currentLightIndex + 1) % lights.Length;

            // Enable the new light.
            lights[_currentLightIndex].enabled = true;

            // Reset the timer
            _timer = 0.0f;
        }
        yield return null;
    }
    #endregion
}
