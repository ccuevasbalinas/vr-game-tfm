using Microsoft.MixedReality.Toolkit.Experimental.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRKeyboard : MonoBehaviour
{
    [Header("Positioning VR Keyboard")]
    public float distance = 0.5f;
    public float verticalOffset = -0.5f;
    public Transform sourcePosition;
    public NonNativeKeyboard keyboard;

    public void OpenKeyboard()
    {
        Vector3 direction = sourcePosition.forward;
        direction.y = 0;
        direction.Normalize();  

        Vector3 targetPosition = sourcePosition.position + direction * distance + Vector3.up * verticalOffset;

        keyboard.RepositionKeyboard(targetPosition);
    }
}
