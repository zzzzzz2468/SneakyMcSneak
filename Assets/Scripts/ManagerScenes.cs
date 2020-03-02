using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerScenes : MonoBehaviour
{
    //Declaring the state machine
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

    //the buttons to be used
    public Button playBtn;
    public Button setBtn;
    public Button backBtn;

    //refrence itself
    public static ManagerScenes managescenes;

    //delete one of the scripts if two or more exist
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

    //assigning the buttons from buttonManager
    public void AssignButtons(Button play, Button set, Button back)
    {
        playBtn = play;
        setBtn = set;
        backBtn = back;
    }

    void Start()
    {
        //gets the playbutton and sets it up
        if (playBtn != null)
        {
            Button playBtnComp = playBtn.GetComponent<Button>();
            playBtnComp.onClick.AddListener(GameOnClick);
        }
        else
            print("There is no game button");

        //sets up the settings button
        if (setBtn != null)
        {
            Button setBtnComp = setBtn.GetComponent<Button>();
            setBtnComp.onClick.AddListener(SetOnClick);
        }
        else
            print("There is no setting button");

        //sets up the back button
        if (backBtn != null)
        {
            Button backBtnComp = backBtn.GetComponent<Button>();
            backBtnComp.onClick.AddListener(BackOnClick);
        }
        else
            print("There is no setting button");
    }

    //click play
    void GameOnClick()
    {
        state = gameState.Game;
        GameStateMachine();
    }

    //click settings
    void SetOnClick()
    {
        state = gameState.Settings;
        GameStateMachine();
    }

    //click back
    void BackOnClick()
    {
        state = gameState.Menu;
        GameStateMachine();
    }

    //switiching the states
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

    //goes to menu state
    void Menu()
    {
        SceneManager.LoadScene(0);
    }

    //goes to game state
    void Game()
    {
        SceneManager.LoadScene(1);
    }

    //goes to settings state
    void Settings()
    {
        SceneManager.LoadScene(2);
    }

    //goes to victory state
    void Victory()
    {
        SceneManager.LoadScene(3);
    }

    //goes to gameover state
    void GameOver()
    {
        SceneManager.LoadScene(4);
    }
}