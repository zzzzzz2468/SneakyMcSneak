using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //declaring variables
    public float hitPoints;
    public float timeToSearch = 3.0f;
    public GameObject detectionEye;

    private bool hearPlayer;
    private bool seePlayer;

    public enum enemyStates
    {
        Idle,
        Search,
        Attack
    }
    public enemyStates state;

    void Update()
    {
        //prints state
        print(state);

        //detects if canhear and cansee
        if(hearPlayer == false && seePlayer == false)
        {
            state = enemyStates.Idle;
            EnemyStateMachine();
        }
        if(hearPlayer == true || seePlayer == true)
        {
            Vector3 somethingIliteralydontgiveasingleshitbro = GameManager.gamemanager.player.transform.position - transform.position;
            float angle = Mathf.Atan2(somethingIliteralydontgiveasingleshitbro.y, somethingIliteralydontgiveasingleshitbro.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    //State Machine
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
        }
    }

    //State actions
    void Idle()
    {
        
    }

    void Search()
    {

    }

    void Attack()
    {

    }

    //If enemy cansee
    public bool canSee(bool see)
    {
        if (see)
        {
            state = enemyStates.Attack;
            EnemyStateMachine();
            detectionEye.SetActive(true);
            seePlayer = true;
        }
        else if (!see)
        {
            state = enemyStates.Search;
            EnemyStateMachine();
            detectionEye.SetActive(false);
            seePlayer = false;
        }
        return see;
    }

    //if enemy canhear
    public bool canHear(bool hear)
    {
        if (hear)
        {
            state = enemyStates.Search;
            EnemyStateMachine();
            detectionEye.SetActive(true);
            hearPlayer = true;
        }
        else if (!hear)
        {
            state = enemyStates.Idle;
            EnemyStateMachine();
            detectionEye.SetActive(false);
            hearPlayer = false;
        }
        return hear;
    }

    //Detects if player is in range
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            canHear(true);
        }
    }
}