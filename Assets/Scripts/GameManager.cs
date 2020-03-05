using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Declares variables
    public static GameManager gamemanager;

    private bool detected = false;

    public GameObject player;

    //Keeps the gamemanager there
    private void Awake()
    {

        if (gamemanager == null)
        {
            gamemanager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}