using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    //declares all of the variables
    public Button playBtn;

    public GameObject manageScenes;

    public static ButtonManager manageButtons;

    private Button thePlayBtn;

    private void Awake()
    {
        thePlayBtn = playBtn;

        //Gets the buttons from manage button script
        if (manageButtons == null)
        {
            manageButtons = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
