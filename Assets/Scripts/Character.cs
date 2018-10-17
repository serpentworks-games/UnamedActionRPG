using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

    [Header("Base Stats")]
    public float moveSpeed;
    [SerializeField]
    protected GameObject damageParticle;
    [SerializeField]
    protected GameObject deathParticle;
    [SerializeField]
    protected Stat healthBar;
    [SerializeField]
    protected float maxHPValue;
    protected bool facingRight = true;

    // Use this for initialization
    protected virtual void Start () {
        healthBar.InitializeStats(maxHPValue, maxHPValue);
    }
	
	// Update is called once per frame
	protected virtual void Update () {
        Move();

        if (healthBar.CurrentValue == 0)
        { 
            DestroyCharacter();
        }
    }

    protected virtual void Move()
    {
        
    }

   protected virtual void FlipSprite()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    public virtual void TakeDamage(int damage)
    {
        healthBar.CurrentValue -= damage;
        Instantiate(damageParticle, transform.position, Quaternion.identity);
    }

    protected virtual void DestroyCharacter()
    {
        Instantiate(deathParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
