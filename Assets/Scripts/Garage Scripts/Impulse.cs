using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Impulse : MonoBehaviour
{
    #region Variables
    /// <summary>
    /// List that contains the game objects that are going to be afected by the impulse of the earthquake.
    /// </summary>
    public GameObject[] objects;

    /// <summary>
    /// Type of Force is going to be applied for each game object due to the earthquake.
    /// </summary>
    [SerializeField] private ForceMode _forceMode = ForceMode.Impulse;

    /// <summary>
    /// Magnitude of the applied Force.
    /// </summary>
    [SerializeField] private float _magnitude = 5.0f;
    #endregion

    #region Functions
    /// <summary>
    /// Function called by an scriptable event that applies a force and a torque.
    /// </summary>
    public void ImpulseFunction()
    {
        for (int i = 0; i < objects.Length; i++) 
        {
            Rigidbody targetRigidbody = objects[i].GetComponent<Rigidbody>();
            targetRigidbody.AddForce(objects[i].transform.forward * Random.Range(1f, _magnitude), _forceMode);
            targetRigidbody.AddTorque(objects[i].transform.forward * Random.Range(1f, _magnitude), _forceMode);
        }
    }
    #endregion
}
