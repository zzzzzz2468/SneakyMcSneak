using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float hitPoints;
    public float timeToSearch = 3.0f;

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
        //StartCoroutine("SearchToWander", timeToSearch);
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

    IEnumerator SearchToWander(float timeSearch)
    {
        while (true)
        {
            yield return new WaitForSeconds(timeSearch);
            state = enemyStates.Wander;
            EnemyStateMachine();
        }
    }

    public bool canSee(bool see)
    {
        if (see)
        {
            state = enemyStates.Attack;
            EnemyStateMachine();
        }
        else if (!see)
        {
            state = enemyStates.Search;
            EnemyStateMachine();
        }
        return see;
    }

    public bool canHear(GameObject target)
    {
        state = enemyStates.Search;
        EnemyStateMachine();
        return false;
    }
}