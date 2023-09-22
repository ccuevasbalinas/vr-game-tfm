using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    public GameObject prefab;

    public void InstantiatePrefab()
    {
        Instantiate(prefab);
    }
}
