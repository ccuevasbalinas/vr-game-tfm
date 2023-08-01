using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightBattery : MonoBehaviour
{
    [SerializeField] private float battery = 100.0f;

    public float GetBattery()
    {
        return battery;
    }
}
