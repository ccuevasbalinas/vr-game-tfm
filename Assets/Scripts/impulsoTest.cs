using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impulsoTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody targetRigidbody = GetComponent<Rigidbody>();
        targetRigidbody.AddForce(transform.forward * 5000.0f, ForceMode.Impulse);
    }

}
