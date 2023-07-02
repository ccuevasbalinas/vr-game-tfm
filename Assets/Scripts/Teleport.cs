using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject objetoATeleport;
    public Transform puntoATeleport;
    // Start is called before the first frame update
   
   public void teleportFunction()
   {
        Debug.Log("Me he teletransportado");
        objetoATeleport.transform.position = puntoATeleport.transform.position;
     
   }
}
