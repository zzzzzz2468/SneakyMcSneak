using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCanvas : MonoBehaviour
{
    //declaring the different variables needed
    public GameObject enemy;
    private Vector3 offset;

    //sets the position of the camera
    void Start()
    {
        offset = transform.position - enemy.transform.position;
    }

    //moves the camera with the enemy
    void LateUpdate()
    {
        transform.position = enemy.transform.position + offset;
    }
}
