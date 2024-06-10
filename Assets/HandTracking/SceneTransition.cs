using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition Instance;
    [SerializeField] private TransitionSettings transition;

    private void Awake()
    {
            Instance = this;

    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        //if (transition != null)
        //{
        //    TransitionManager.Instance().Transition(sceneName, transition, 0);
        //}
        //else
        //{
        //    Debug.LogError("TransitionSettings atanmadý.");
        //}
    }
}
