using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneName{
    MainMenu,
    House,
    CasaCreepy,
    House2,
    Tunnels,
    House3,
    Hospital,
    House4,
    Carretera,
    House5,
    Morgue,
    House6
}

public class DynamicSceneManager : MonoBehaviour
{
    public SceneName originScene;
    public SceneName destinyScene;

    public bool originLoaded = true;
    public bool destinyLoaded = false;
    // Start is called before the first frame update


    
    public void loadScene(){
        if(!destinyLoaded){
            SceneManager.LoadSceneAsync(destinyScene.ToString(), LoadSceneMode.Additive);
            //SceneManager.LoadSceneAsync("Morgue", LoadSceneMode.Additive);
            destinyLoaded = true;
        }
    }

    public void unloadScene(){
        if(originLoaded){
            SceneManager.UnloadSceneAsync(originScene.ToString());
            Debug.Log("hasta luego");
        }
    }

}
