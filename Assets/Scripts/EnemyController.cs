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
        print(state);
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

    public bool canSee(bool see)
    {
        if (see)
            state = enemyStates.Attack;
        else if (!see)
            state = enemyStates.Search;
        return see;
    }

    public bool canHear(GameObject target)
    {
        state = enemyStates.Search;
        return false;
    }
}