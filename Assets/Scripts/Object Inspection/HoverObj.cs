using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverObj : MonoBehaviour
{
    public GameObject Inspection;
    public InspectionObj inspectionObj;
    public int index;
    public FPSController playerController;
    // Update is called once per frame

    
    /*
    void Update()
    {
        if(Inspection.active)
        {
            return;
        }
        Ray ray = Camera.main.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //Color color = GetComponent<MeshRenderer>().material.color;
        if(GetComponent<Collider>().Raycast(ray, out hit, 100f))
        {
            //color.a = 0.6f; 
            if(Input.GetMouseButtonDown(0))
            {
                Inspection.SetActive(true);
                inspectionObj.TurnOnInspection(index);
                Time.timeScale = 0;
            }  
        } 
        else
        {
            //color.a = 1.0f;
        }
        //GetComponent<MeshRenderer>().material.color = color;
    }
    */

    
    public void inspectObject(){
        playerController.enabled = false;
        Inspection.SetActive(true);
        inspectionObj.TurnOnInspection(index);
    }
    

}
