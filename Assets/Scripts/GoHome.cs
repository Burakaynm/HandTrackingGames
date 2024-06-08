using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHome : MonoBehaviour
{

    public void GoToHome()
    {
        SceneTransition.Instance.LoadScene("Menu");
    }
}
