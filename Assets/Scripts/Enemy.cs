using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {


    public float sightRange;
    public float attackRange;
    public LayerMask pLayer;
    public bool isPatroller;
    public GameObject enemySprite;
    public Transform[] wayPoints;

    // Use this for initialization
    protected override void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	protected override void Update () {
        base.Update();
	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, sightRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }


}
