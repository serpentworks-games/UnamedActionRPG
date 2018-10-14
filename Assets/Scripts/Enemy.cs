using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health;
    public float movementSpeed;
    public float sightRange;
    public float attackRange;
    public LayerMask pLayer;
    [Tooltip("Does this enemy patrol?")]
    public bool isPatroller;
    public GameObject enemySprite;
    public Transform[] wayPoints;
    public GameObject damageParticle;
    public GameObject deathParticle;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(health < 0)
        {
            Debug.Log("Enemy is dead!");
            health = 0;
            DestroyEnemy();
        }
	}

    public void TakeDamage(int damage)
    {
        health -= damage;
        Instantiate(damageParticle, transform.position, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, sightRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    void DestroyEnemy()
    {
        Instantiate(deathParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
