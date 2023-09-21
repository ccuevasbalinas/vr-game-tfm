using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuCanvas;

    public void ActivatePauseCanvas()
    {
        pauseMenuCanvas.SetActive(true);
    }

    public void DeactivatePauseCanvas() 
    {
        pauseMenuCanvas.SetActive(false);
    }
}
