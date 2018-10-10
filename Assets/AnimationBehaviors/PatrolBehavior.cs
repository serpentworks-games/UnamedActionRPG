using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehavior : StateMachineBehaviour {

    public float startWaitTime;

    int nextWayPoint;
    float waitTime;
    float movementSpeed;
    float sightRange;
    LayerMask pLayer;
    Transform[] wayPoints;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        waitTime = startWaitTime;
        movementSpeed = animator.GetComponent<Enemy>().movementSpeed;
        sightRange = animator.GetComponent<Enemy>().sightRange;
        pLayer = animator.GetComponent<Enemy>().pLayer;
        wayPoints = animator.GetComponent<Enemy>().wayPoints;
	}

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        animator.transform.position = Vector2.MoveTowards(animator.transform.position, wayPoints[nextWayPoint].position, movementSpeed * Time.deltaTime);

        Collider2D chaseCol = Physics2D.OverlapCircle(animator.transform.position, sightRange, pLayer);
        if (chaseCol != null)
        {
            animator.SetBool("isFollowing", true);
        }
        else
        {
            if (Vector2.Distance(animator.transform.position, wayPoints[nextWayPoint].position) < 0.2f)
            {
                if (waitTime <= 0)
                {
                    nextWayPoint = (nextWayPoint + 1) % wayPoints.Length;
                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                    animator.SetTrigger("waitAtPoint");
                    animator.gameObject.GetComponentInChildren<Animator>().SetBool("isMoving", false);
                }
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
