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

    public Button playBtn;
    public Button setBtn;
    public Button backBtn;

    public static ManagerScenes managescenes;

    private void Awake()
    {
        if (managescenes == null)
        {
            managescenes = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AssignButtons(Button play, Button set, Button back)
    {
        playBtn = play;
        setBtn = set;
        backBtn = back;
    }

    void Start()
    {
        if (playBtn != null)
        {
            Button playBtnComp = playBtn.GetComponent<Button>();
            playBtnComp.onClick.AddListener(GameOnClick);
        }
        else
            print("There is no game button");

        if (setBtn != null)
        {
            Button setBtnComp = setBtn.GetComponent<Button>();
            setBtnComp.onClick.AddListener(SetOnClick);
        }
        else
            print("There is no setting button");

        if (backBtn != null)
        {
            Button backBtnComp = backBtn.GetComponent<Button>();
            backBtnComp.onClick.AddListener(BackOnClick);
        }
        else
            print("There is no setting button");
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

    void BackOnClick()
    {
        state = gameState.Menu;
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
