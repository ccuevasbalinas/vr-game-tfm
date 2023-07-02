using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectionObj : MonoBehaviour
{
  public GameObject[] inspectionObjects;
  public FPSController playerController;
  private int currIndex;
  

  public void TurnOnInspection(int index)
  {
   currIndex = index;
   inspectionObjects[index].SetActive(true);   
  }

  public void TurnOffInspection()
  {
   inspectionObjects[currIndex].SetActive(false);   
  }

  public void startTime(){
        playerController.enabled = true;
        Debug.Log(Time.timeScale);
        //Time.timeScale = 1;
  }
}
