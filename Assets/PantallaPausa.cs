using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PantallaPausa : MonoBehaviour
{
    public GameObject pantallaPausa;
    public FPSController playerController;

    void Start (){
        pantallaPausa.gameObject.SetActive (false);
    }
     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pantallaPausa.activeSelf == false){
                pantallaPausa.SetActive(true);
                playerController.enabled = false;
                Time.timeScale = 0;                
            }else{
                pantallaPausa.SetActive(false);
                playerController.enabled = true;                
                Time.timeScale = 1;
            }           
        }
    }

    public void EsceneMainMenu(){
        //Debug.Log("Eyyy");
        playerController.enabled = true;                
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void EsceneWorkInprogress(){
        //Debug.Log("Eyyy");
        playerController.enabled = true;                
        Time.timeScale = 1;
        SceneManager.LoadScene("Workinprogress");
    }

}
