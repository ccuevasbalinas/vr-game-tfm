using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightVR : MonoBehaviour
{
    [SerializeField] private Light _light;
    [SerializeField] private float lifetime = 100.0f;
    [SerializeField] private bool isOn = false;
    [SerializeField] private bool isInfinite = false;

    public void TurnOnLight()
    {
        _light.enabled = true;
        isOn = true;
    }

    public void TurnOffLight()
    {
        _light.enabled = false;
        isOn = false;
    }

    private void Update()
    {
        if (!isInfinite)
        {
            if (isOn)
            {
                lifetime = lifetime - 1 * Time.deltaTime;
            }

            if (lifetime <= 0)
            {
                lifetime = 0;
                TurnOffLight();
            }
        }
    }

    public void ReloadFlashlight(FlashlightBattery batt)
    {
        lifetime = lifetime + batt.GetBattery();
        if(lifetime >= 100.0f)
        {
            lifetime = 100.0f;
        }
    }
}
