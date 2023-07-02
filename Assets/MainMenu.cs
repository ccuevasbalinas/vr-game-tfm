using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    public void EscenaJuegio(){

        SceneManager.LoadScene("House");
    }

    public void Salir(){

        Application.Quit();
    }

    

/*Para ir a un nivel concreto
    public void CargarNivel(string nombreNivel){
        ceneManager.LoadScene(nombreNivel);
    }
*/

    
}
