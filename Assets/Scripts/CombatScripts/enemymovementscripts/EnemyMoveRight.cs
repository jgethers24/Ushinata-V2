using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveRight : StateMachineBehaviour
{
    Rigidbody rb;
    Transform targetPoint;

    EnemyStats enemy;
    Transform placeToGo;
    public float speed = 1f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        rb = animator.GetComponent<Rigidbody>();
        targetPoint = GameObject.FindGameObjectWithTag("EnemyMovePoint").transform;
        enemy = animator.GetComponent<EnemyStats>();

        targetPoint.transform.Translate(1, 0, 0);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        Debug.Log("should be moving left");
        Vector3 target = new Vector3(targetPoint.position.x, targetPoint.position.y, targetPoint.position.z);
        Vector3 newPos = Vector3.MoveTowards(rb.position, target, speed * Time.deltaTime);
        rb.MovePosition(newPos);
        float distance = Vector3.Distance(target, rb.position);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        animator.ResetTrigger("NextMove");
    }
}