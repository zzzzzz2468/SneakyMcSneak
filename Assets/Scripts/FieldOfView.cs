﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    //sets the radius of how far it can see and the angle that he can see at
    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;

    //layers his targets and obstacles are on
    public LayerMask targetMask;
    public LayerMask obstacleMask;

    //the targets the enemy can see
    public List<Transform> visibleTargets = new List<Transform>();

    //bool for if the player is being seen
    private bool canSeePlayer = false;

    //starts the search process
    private void Start()
    {
        StartCoroutine("FindTargetsWithDelay", 0.2f);
    }

    private void Update()
    {
        //changes the enemy to be unable to see the player
        if(visibleTargets.Count == 0 && canSeePlayer)
        {
            this.GetComponent<EnemyController>().canSee(false);
        }
    }

    //finds targets
    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    //Finds targets that are in the area that the enemy can see
    void FindVisibleTargets()
    {
        visibleTargets.Clear();

        Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), viewRadius, targetMask);
        for(int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if(Vector3.Angle(transform.right, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);
                if (!Physics2D.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    visibleTargets.Add(target);
                    this.GetComponent<EnemyController>().canSee(true);
                    canSeePlayer = true;
                }
            }
        }
    }

    //detects where the player is inside of the circle
    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.z;
        }
        return new Vector3(-Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
