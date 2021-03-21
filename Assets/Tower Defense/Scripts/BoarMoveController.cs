using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BoarMoveController : MonoBehaviour
{
    public Animator enemyAnimator;

    // Update is called once per frame
    void Update()
    {
        if (enemyAnimator)
        {
            var agent = GetComponent<NavMeshAgent>();
            var maxSpeed = agent.speed;
            var currentSpeed = agent.velocity.magnitude;
            enemyAnimator.SetFloat("Speed", currentSpeed / maxSpeed);
        }
    }
}
