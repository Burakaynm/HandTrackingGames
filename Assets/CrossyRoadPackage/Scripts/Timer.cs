using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public GameObject counterText;
    [SerializeField] private Text goText;
    float timeCounter = 0f;
    void Start()
    {
        timeCounter = 3f;
        counterText.SetActive(true);
    }

    void Update()
    {
        //goText.gameObject.SetActive(false);
        timeCounter -= 1 * Time.deltaTime;
        goText.text = timeCounter.ToString("0.0");
        if (timeCounter < 0)
        {
            counterText.SetActive(false);
            //goText.gameObject.SetActive(true);
        }

    }

}
