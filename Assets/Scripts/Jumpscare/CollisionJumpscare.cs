using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionJumpscare : MonoBehaviour
{
    public LocationJumpscare jumpscareManager;
    // Start is called before the first frame update
    void Start()
    {
        jumpscareManager = GetComponentInParent<LocationJumpscare>();
    }


    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag(jumpscareManager.playerTag)){
            jumpscareManager.executeJumpscare();
        }
    }

}
