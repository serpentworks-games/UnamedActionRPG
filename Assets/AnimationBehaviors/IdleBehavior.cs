using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehavior : StateMachineBehaviour {

    GameObject enemySprite;
    float sightRange;
    LayerMask pLayer;
    bool isPatroller;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        sightRange = animator.GetComponent<Enemy>().sightRange;
        pLayer = animator.GetComponent<Enemy>().pLayer;
        enemySprite = animator.GetComponent<Enemy>().enemySprite;
        
    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        isPatroller = animator.GetComponent<Enemy>().isPatroller;

        if (!isPatroller)
        {
            return;
        }

        Collider2D collider = Physics2D.OverlapCircle(animator.transform.position, sightRange, pLayer);
        if(collider != null)
        {
            animator.SetBool("isFollowing", true);
            enemySprite.GetComponent<Animator>().SetBool("isMoving", true);
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
