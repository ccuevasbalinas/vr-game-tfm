using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Impulse : MonoBehaviour
{
    public GameObject[] objects;
    //[SerializeField] private Vector3 _impulseVector = new Vector3(100f, 0f, 0f);
    [SerializeField] private ForceMode _forceMode = ForceMode.Impulse;
    [SerializeField] private float _magnitude = 5.0f;

    // Function called by an scriptable event that applies a force and a torque.
    public void ImpulseFunction()
    {
        for (int i = 0; i < objects.Length; i++) 
        {
            Rigidbody targetRigidbody = objects[i].GetComponent<Rigidbody>();
            targetRigidbody.AddForce(objects[i].transform.forward * Random.Range(1f, _magnitude), _forceMode);
            targetRigidbody.AddTorque(objects[i].transform.forward * Random.Range(1f, _magnitude), _forceMode);
        }
    

    }
    
}
