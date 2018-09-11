using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script simply transfers values from the Enemy script into the state machine for reference
//To avoid having to dive into the animator to set values

public class EnemyStatSetupBehavior : StateMachineBehaviour {

    public float movementSpeed;
    public float sightRange;
    public float attackRange;
    public bool isPatroller;
    public Transform[] wayPoints;
    public LayerMask pLayer;

    Enemy enemyStats;

	 override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        enemyStats = animator.GetComponent<Enemy>();

        movementSpeed = enemyStats.movementSpeed;
        sightRange = enemyStats.sightRange;
        attackRange = enemyStats.attackRange;
        isPatroller = enemyStats.isPatroller;
        wayPoints = enemyStats.wayPoints;
        pLayer = enemyStats.pLayer;

        animator.SetBool("isPatroller", isPatroller);
    
	}

	
}
