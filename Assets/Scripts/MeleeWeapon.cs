using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour {

    public float startTimeBtwAttack;
    public Transform attackPos;
    public string attackPositionName;
    public float attackRangeX, attackRangeY;
    public LayerMask whatIsEnemy;
    public int damage;

    float timeBtwAttack;
    Animator handAnimator;
    CamShake shake;

    // Use this for initialization
    void Awake () {
        handAnimator = GameObject.Find("PlayerHand").GetComponent<Animator>();
        attackPos = GameObject.Find(attackPositionName).gameObject.transform;
        shake = FindObjectOfType<CamShake>();
	}
	
	// Update is called once per frame
	void Update () {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                handAnimator.SetTrigger("mediumSwordSwing");
                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), whatIsEnemy);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    if (enemiesToDamage[i] != null)
                    {
                        enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                        shake.CameraShake();
                        Debug.Log("Hitting an enemy!");
                    }
                    else
                    {
                        Debug.Log("No enemy to hit!");
                    }
                   
                }

                timeBtwAttack = startTimeBtwAttack;
            }            
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1f));
    }
}
