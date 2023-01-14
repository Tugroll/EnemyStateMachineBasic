using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PatrolState : EnemyBaseState
{
    float timer;
    List<Transform> wayPoints = new List<Transform>();
  
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        timer = 0;
        getEnemyScript(animator).agent.speed = 3f;
        GameObject[] gO = GameObject.FindGameObjectsWithTag("waypoints");
        foreach (GameObject t in gO)
            wayPoints.Add(t.transform);

        getEnemyScript(animator).agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (getEnemyScript(animator).agent.remainingDistance <= getEnemyScript(animator).agent.stoppingDistance)
            getEnemyScript(animator).agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);

        timer += Time.deltaTime;
        if (timer > 10)
            animator.SetBool("isPatrol", false);


        if (getEnemyScript(animator).getDistance() < getEnemyScript(animator).chasingRange)
            animator.Play("Chase");
                //animator.SetBool("isChasing", true);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        getEnemyScript(animator).agent.SetDestination(getEnemyScript(animator).agent.transform.position);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
