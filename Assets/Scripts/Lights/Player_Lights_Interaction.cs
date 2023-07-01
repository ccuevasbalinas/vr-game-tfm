using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Lights_Interaction : MonoBehaviour
{
    [SerializeField] private int rayLength = 2;
    [SerializeField] private LayerMask doorLayer;
    [SerializeField] private LayerMask excludeLayer;

    private string doorTagName = "InteractibleObject";


    private DoorInteraction raycastedObj;

    [SerializeField] private KeyCode doorKey = KeyCode.E;


    /*[SerializeField] private Image crosshair = null;    
    private bool isCrosshairActive;
    private bool doOnce;*/
    public Camera fpsCamera;
    // Start is called before the first frame update
    private void Start() {
        fpsCamera = GetComponentInChildren<Camera>();        
    }

    // Update is called once per frame
    void Update()
    {        
        if(Input.GetKeyDown(doorKey)){
            interactDoor();
        }
    }


    void interactDoor(){
        RaycastHit hit;
        if(Physics.Raycast(fpsCamera.transform.position,fpsCamera.transform.forward, out hit, rayLength, 1 << excludeLayer.value | doorLayer.value)){   
//            Debug.Log(hit.collider.gameObject.name);                     
            if(hit.collider.CompareTag(doorTagName)){
                raycastedObj = hit.collider.gameObject.GetComponentInParent<DoorInteraction>();
                raycastedObj.PlayAnimation();
            }
        }
    }
}
