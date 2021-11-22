using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    #region Variables

    [HideInInspector] public bool isGameStarted;

    float timer;

    #endregion


    #region Other Methods

    public void StartGame()
    {
        isGameStarted = true;
        timer = 1;
    }

    public void GameOver()
    {
        isGameStarted = false;
    }

    #endregion
}
