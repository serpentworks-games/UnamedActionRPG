using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehavior : StateMachineBehaviour {

    public float startWaitTime;

    int nextWayPoint;
    float waitTime;
    float movementSpeed;
    Transform[] wayPoints;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        waitTime = startWaitTime;
        movementSpeed = animator.GetBehaviour<EnemyStatSetupBehavior>().movementSpeed;
        wayPoints = animator.GetBehaviour<EnemyStatSetupBehavior>().wayPoints;
	}

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        animator.transform.position = Vector2.MoveTowards(animator.transform.position, wayPoints[nextWayPoint].position, movementSpeed * Time.deltaTime);

        if (Vector2.Distance(animator.transform.position, wayPoints[nextWayPoint].position) < 0.2f)
        {
            if(waitTime <= 0)
            {
                nextWayPoint = (nextWayPoint + 1) % wayPoints.Length;
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }    
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
