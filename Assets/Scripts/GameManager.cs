using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gamemanager;

    private bool detected = false;

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

    private void Update()
    {
        if(detected == true)
        {
            
        }
    }
}