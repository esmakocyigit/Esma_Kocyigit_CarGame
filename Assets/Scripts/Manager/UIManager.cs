using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    #region Variables

    [SerializeField] private GameObject winPanel;
    #endregion

    #region Monobehaviour Callbacks
    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex != PlayerPrefs.GetInt("Level"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
        }
    }
    #endregion

    #region Other Methods

    private void WinGameUI()
    {
        winPanel.transform.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        InputManager.isWin += WinGameUI;
        InputManager.isWin += nextLevel;
    }
    private void OnDisable()
    {
        InputManager
            .isWin -= WinGameUI;
        InputManager.isWin += nextLevel;
    }


    public void NextSceneButton()
    {
        nextLevel();
    }

    public void nextLevel()
    {
        if (PlayerPrefs.GetInt("Level") < SceneManager.sceneCountInBuildSettings - 1)
        {
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        }
        else
        {
            PlayerPrefs.SetInt("Level", 0);
        }
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
    }
    #endregion
}
