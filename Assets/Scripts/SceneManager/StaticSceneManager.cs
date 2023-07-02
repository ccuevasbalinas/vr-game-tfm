using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StaticSceneManager : MonoBehaviour
{
    public SceneName nuevaEscena;
    public bool isLogo = false;
    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nuevaEscena.ToString());

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void loadNextScene(){
        StartCoroutine(LoadYourAsyncScene());
    }


    private void OnEnable() {
        if(isLogo)
            loadNextScene();
    }    

}
