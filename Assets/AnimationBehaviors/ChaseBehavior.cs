using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBehavior : StateMachineBehaviour {

    float speed;
    float attackRange;
    public float distanceBetween;
    Transform playerPos;
    float sightRange;
    LayerMask pLayer;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        sightRange = animator.GetComponent<Enemy>().sightRange;
        speed = animator.GetComponent<Enemy>().movementSpeed;
        attackRange = animator.GetComponent<Enemy>().attackRange;
        pLayer = animator.GetComponent<Enemy>().pLayer;
    }

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        Collider2D atkCol = Physics2D.OverlapCircle(animator.transform.position, attackRange, pLayer);
        if (atkCol != null)
        {
            animator.SetBool("isAttacking", true);
        }

        Collider2D chaseCol = Physics2D.OverlapCircle(animator.transform.position, sightRange, pLayer);
        if (chaseCol == null)
        {
            animator.SetBool("isFollowing", false);
        }
        else if (chaseCol != null)
        {
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, playerPos.position, speed * Time.deltaTime);
        }
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
