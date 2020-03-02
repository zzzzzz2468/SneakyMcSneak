using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public enum enemyStates
    {
        Idle,
        Search,
        Attack,
        Wander
    }
    public enemyStates state;

    void Start()
    {
        
    }

    void Update()
    {

    }

    void EnemyStateMachine()
    {
        switch (state)
        {
            case enemyStates.Idle:
                Idle();
                break;
            case enemyStates.Search:
                Search();
                break;
            case enemyStates.Attack:
                Attack();
                break;
            case enemyStates.Wander:
                Wander();
                break;
        }
    }

    void Idle()
    {

    }

    void Search()
    {

    }

    void Attack()
    {

    }

    void Wander()
    {

    }
}