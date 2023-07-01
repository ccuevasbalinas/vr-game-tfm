using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Door_Interaction : MonoBehaviour
{
    [SerializeField] private int rayLength = 2;
    [SerializeField] private LayerMask doorLayer;
    [SerializeField] private LayerMask excludeLayer;

    private string doorTagName = "InteractibleObject";
    private string lightsTagName = "LightSwitch";
    private string phoneTagName = "Phone";
    private string keysTagName = "CarKeys";
    private string inspectableTagName = "InspectableObject";


    //private DoorInteraction raycastedObj;

    [SerializeField] private KeyCode doorKey = KeyCode.E;


    [Header("Object Inspection")]
    public int indexObject;


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
            if(hit.collider.CompareTag(doorTagName)){
                DoorInteraction raycastedObj = hit.collider.gameObject.GetComponentInParent<DoorInteraction>();
                raycastedObj.PlayAnimation();
            }
            else if(hit.collider.CompareTag(lightsTagName)){
                LightSwitchInteraction raycastedObj = hit.collider.gameObject.GetComponent<LightSwitchInteraction>();
                raycastedObj.SwitchLights();
            }
            else if(hit.collider.CompareTag(phoneTagName)){
                TelephoneInteraction raycastedObj = hit.collider.gameObject.GetComponent<TelephoneInteraction>();
                raycastedObj.playVoiceMails();
            }
            else if(hit.collider.CompareTag(keysTagName)){                
                HoverObj raycastedObj = hit.collider.gameObject.GetComponent<HoverObj>();
                raycastedObj.inspectObject();
                KeysInteraction raycastedObjInteraction = hit.collider.gameObject.GetComponent<KeysInteraction>();
                raycastedObjInteraction.collectKeys();
            }
            else if(hit.collider.CompareTag(inspectableTagName)){
                HoverObj raycastedObj = hit.collider.gameObject.GetComponent<HoverObj>();
                raycastedObj.inspectObject();
            }
        }
    }
}
