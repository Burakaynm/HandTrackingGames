using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition Instance;
    [SerializeField] TransitionSettings transition;
    private void Start()
    {
        Instance = this;
    }

    public void LoadLevel(string sceneName)
    {
        TransitionManager.Instance().Transition(sceneName, transition, 0);
    }
}
