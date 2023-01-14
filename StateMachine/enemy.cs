using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemy : MonoBehaviour
{
    public Transform lockOnTransform;
    public Rigidbody rb;
    public NavMeshAgent agent;
    public Transform targetPlayer;
    public float chasingRange = 8;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
    }


    public float getDistance()
    {
        float distance = Vector3.Distance(targetPlayer.position, transform.position);

        return distance;
    }

    public void chasePlayer()
    {
        agent.SetDestination(targetPlayer.position);
    }
}
