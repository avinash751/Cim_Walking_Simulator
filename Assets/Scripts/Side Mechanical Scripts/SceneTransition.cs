using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public int sceneIndex;
    

    void TransitionToChosenScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    void TransitionToSceneBasedOnIndex(int _sceneIndex)
    {
        SceneManager.LoadScene(_sceneIndex);
    }

    void TransitionToChosenSceneAfterDelay(int _delay)
    {
      Invoke("TransitionToChosenScene", _delay);
    }
}
