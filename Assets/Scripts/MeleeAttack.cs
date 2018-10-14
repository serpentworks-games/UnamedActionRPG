using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack: MonoBehaviour {

    public float startTimeBtwAttack;
    public Transform attackPos;
    public string attackPositionName;
    public float attackRangeX, attackRangeY;
    public LayerMask whatIsEnemy;
    public int damage;
    public GameObject weaponSlot;

    float timeBtwAttack;
    Animator handAnimator;
    CamShake shake;
    Collider2D[] colliders;
    Inventory inv;
    DialogueUI diagUI;
    MagicAttack magicAtk;

    // Use this for initialization
    void Awake () {
        handAnimator = GameObject.Find("PlayerHand").GetComponent<Animator>();
        attackPos = GameObject.Find(attackPositionName).gameObject.transform;
        shake = FindObjectOfType<CamShake>();
        inv = FindObjectOfType<Inventory>();
        diagUI = FindObjectOfType<DialogueUI>();
        magicAtk = GetComponentInChildren<MagicAttack>();
	}
	
	// Update is called once per frame
	void Update () {
        if (magicAtk.abilityActive)
        {
            weaponSlot.SetActive(false);
            return;
        }
        else
        {
            weaponSlot.SetActive(true);

            if (timeBtwAttack <= 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (!inv.isActive && !diagUI.isActive)
                    {

                        handAnimator.SetTrigger("mediumSwordSwing");
                        colliders = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), whatIsEnemy);
                        for (int i = 0; i < colliders.Length; i++)
                        {
                            if (colliders[i].CompareTag("Enemy"))
                            {
                                colliders[i].GetComponent<Enemy>().TakeDamage(damage);
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
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1f));
    }
}
