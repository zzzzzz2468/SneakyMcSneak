using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button playBtn;
    public Button setBtn;
    public Button backBtn;

    public GameObject manageScenes;

    public static ButtonManager manageButtons;

    private Button thePlayBtn;
    private Button theSetBtn;
    private Button theBackBtn;

    private void Awake()
    {
        theBackBtn = backBtn;
        theSetBtn = setBtn;
        thePlayBtn = playBtn;


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

    private void Start()
    {
        manageScenes.GetComponent<ManagerScenes>().AssignButtons(thePlayBtn, theSetBtn, theBackBtn);
    }
}
