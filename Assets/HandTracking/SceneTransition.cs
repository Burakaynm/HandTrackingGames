using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition Instance;
    [SerializeField] private TransitionSettings transition;

    private void Awake()
    {
        // Ensure there is only one instance
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Additional safety check
        if (transition == null)
        {
            Debug.LogError("TransitionSettings nesnesi SceneTransition script'inde atanmadý.");
        }
    }

    public void LoadScene(string sceneName)
    {
        if (transition != null)
        {
            TransitionManager.Instance().Transition(sceneName, transition, 0);
        }
        else
        {
            Debug.LogError("TransitionSettings atanmadý.");
        }
    }
}
