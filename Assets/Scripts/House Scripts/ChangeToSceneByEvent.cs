using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToSceneByEvent : MonoBehaviour
{
    public void ChangeToOtherScene()
    {
        SceneTransitionManager.singleton.GoToSceneAsync(2);
    }
}
