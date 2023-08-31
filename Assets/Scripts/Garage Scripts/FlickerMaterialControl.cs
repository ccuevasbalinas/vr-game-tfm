using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerMaterialControl : MonoBehaviour
{
    public bool isFlickering = false;
    public float timeDelay;

    // Update is called once per frame
    void Update()
    {
        if (isFlickering == false)
        {
            StartCoroutine(FlickerLight());
        }

    }

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
}
