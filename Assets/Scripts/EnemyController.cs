using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float hitPoints;

    public enum enemyStates
    {
        Idle,
        Search,
        Attack,
        Wander,
        Rest
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
            case enemyStates.Rest:
                Rest();
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

    void Rest()
    {

    }

    public bool canSee(GameObject target)
    {
        return false;
    }

    public bool canHear(GameObject target)
    {
        return false;
    }
}