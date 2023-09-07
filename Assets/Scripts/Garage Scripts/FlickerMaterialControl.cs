using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerMaterialControl : MonoBehaviour
{
    #region Variables
    /// <summary>
    /// Boolean that flickers the lights making it on/off.
    /// </summary>
    public bool isFlickering = false;

    /// <summary>
    /// Time the lights must be on/off.
    /// </summary>
    public float timeDelay;
    #endregion

    #region Functions
    /// <summary>
    /// Function that calls a coroutine in case the light is off to make it visible.
    /// </summary>
    void Update()
    {
        if (isFlickering == false) StartCoroutine(FlickerLight());
    }


    /// <summary>
    /// Coroutine that switch the lighs between on/off after a period of random time between (0.01f, 0.2f) seconds.
    /// </summary>
    IEnumerator FlickerLight()
    {
        isFlickering = true;
        this.gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        timeDelay = Random.Range(0.01f, 0.2f);
        yield return new WaitForSeconds(timeDelay);

        this.gameObject.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        timeDelay = Random.Range(0.01f, 0.2f);
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;
    }
    #endregion
}
