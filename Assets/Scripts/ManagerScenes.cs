using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerScenes : MonoBehaviour
{
    public enum gameState
    {
        Menu,
        Game,
        Victory,
        GameOver,
        Settings
    }

    [Header("Finite State Machine")]
    public gameState state;

    [Header("Buttons")]
    public Button playBtn;
    public Button setBtn;

    void Start()
    {
        Button gameBtn = playBtn.GetComponent<Button>();
        gameBtn.onClick.AddListener(GameOnClick);

        Button settingsBtn = setBtn.GetComponent<Button>();
        settingsBtn.onClick.AddListener(SetOnClick);
    }

    void GameOnClick()
    {
        state = gameState.Game;
        GameStateMachine();
    }

    void SetOnClick()
    {
        state = gameState.Settings;
        GameStateMachine();
    }

    void GameStateMachine()
    {
        switch (state)
        {
            case gameState.Menu:
                Menu();
                break;
            case gameState.Game:
                Game();
                break;
            case gameState.Settings:
                Settings();
                break;
            case gameState.Victory:
                Victory();
                break;
            case gameState.GameOver:
                GameOver();
                break;
        }
    }

    void Menu()
    {
        SceneManager.LoadScene(0);
    }

    void Game()
    {
        SceneManager.LoadScene(1);
    }

    void Settings()
    {
        SceneManager.LoadScene(2);
    }

    void Victory()
    {
        SceneManager.LoadScene(3);
    }

    void GameOver()
    {
        SceneManager.LoadScene(4);
    }
}
