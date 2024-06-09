using Michsky.MUIP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSelector : MonoBehaviour
{
    string selectedGame = "Crossy Road";
    HorizontalSelector horizontalSelector;
    private void Awake()
    {
        horizontalSelector = GetComponent<HorizontalSelector>();
    }
    public void SetSelectedGame()
    {
        Debug.Log(selectedGame);
        selectedGame = horizontalSelector.items[horizontalSelector.index].itemTitle;
    }
    public void GoToGameScene()
    {
        SceneTransition.Instance.LoadScene(selectedGame);
    }
}
