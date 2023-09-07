using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class OscillatingMovement : MonoBehaviour
{
    #region Variables
    /// <summary>
    /// Duration of the earthquake.
    /// </summary>
    [SerializeField] private float duration = 5.15f;

    /// <summary>
    /// Magnitude of the earthqueake.
    /// </summary>
    [SerializeField] private float magnitude = .4f;
    #endregion

    #region Functions
    /// <summary>
    /// Function made by scriptable event that listen if the camera must be shaked, simulating the quake effect.
    /// </summary>
    public void Quake()
    {
        StartCoroutine(OscilatingMovementFunction(duration, magnitude));
    }


    /// <summary>
    /// Coroutine that handles the quake effect that is applied to the camera.
    /// </summary>
    IEnumerator OscilatingMovementFunction(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        // While the shake's duration has not finished, transfrom the local position of the camara in order to make the shake effect.
        float elpased = 0.0f;
        while (elpased < duration)
        {
            transform.localPosition = new Vector3(Random.Range(-1f, 1f) * magnitude, Random.Range(-1f, 1f) * magnitude, Random.Range(-1f, 1f) * magnitude);
            elpased += Time.deltaTime;
            yield return null;
        }

        // By the end of the shake, return to the original position.
        transform.localPosition = originalPos;
    }
    #endregion
}
