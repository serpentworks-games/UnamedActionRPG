﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehavior : StateMachineBehaviour {

    Transform playerPos;
    float attackRange;
    public float distanceBetween;
    LayerMask pLayer;
    Collider2D col;
    GameObject enemySprite;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        attackRange = animator.GetComponent<Enemy>().attackRange;
        pLayer = animator.GetComponent<Enemy>().pLayer;
        enemySprite = animator.GetComponent<Enemy>().enemySprite;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        col = Physics2D.OverlapCircle(animator.transform.position, attackRange, pLayer);
        if (col == null)
        {
            animator.SetBool("isAttacking", false);
            return;
        }

        enemySprite.GetComponent<Animator>().SetTrigger("isAttacking");

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
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
