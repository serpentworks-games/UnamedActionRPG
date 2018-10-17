using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    [SerializeField]
    protected Stat manaBar;
    [SerializeField]
    protected float maxManaValue;

    [Header("Melee Attack Stats")]
    [SerializeField]
    protected float timeBtwAttack;
    [SerializeField]
    protected Transform attackPos;
    [SerializeField]
    protected string attackPositionName;
    [SerializeField]
    protected float attackRangeX, attackRangeY;
    [SerializeField]
    protected LayerMask whatIsEnemy;
    [SerializeField]
    protected int damage;
    [SerializeField]
    protected GameObject meleeWeaponSlot;

    [Header("Magic Attack Stats")]
    [SerializeField]
    protected GameObject magicWeaponSlot;
    [SerializeField]
    protected Transform shotPoint;
    [SerializeField]
    protected float offset;
    [SerializeField]
    private GameObject[] spellPrefab;

    Rigidbody2D pRB;
    Vector2 moveInput;
    Vector2 moveVelocity;
    float h;
    float v;
    [HideInInspector]
    public bool spellAbilityActive;

    Animator anim;
    Animator handAnim;
    DialogueUI diagUI;
    CamShake shake;
    Inventory inv;

    private void Awake()
    {
        pRB = GetComponent<Rigidbody2D>();
        handAnim = GameObject.Find("PlayerHand").GetComponent<Animator>();
        anim = GetComponent<Animator>();
        diagUI = FindObjectOfType<DialogueUI>();
        shake = FindObjectOfType<CamShake>();
        inv = GetComponent<Inventory>();
    }

    protected override void Start()
    {
        
        manaBar.InitializeStats(maxManaValue, maxManaValue);
        base.Start();
    }

    // Update is called once per frame
    protected override void Update () {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - magicWeaponSlot.transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        magicWeaponSlot.transform.rotation = Quaternion.Euler(difference.x, difference.y, rotZ + offset);

        if (!diagUI.isActive || !inv.isActive)
        {
                if (spellAbilityActive)
                {
                    meleeWeaponSlot.SetActive(false);
                    if (Input.GetMouseButtonDown(0))
                    {
                        StartCoroutine(SpellAttack());
                    }
                }
                else
                {
                    meleeWeaponSlot.SetActive(true);
                    if (Input.GetMouseButtonDown(0))
                    {
                        StartCoroutine(MeleeAttack());
                    }
                }
            }
        base.Update();
    }

    protected override void Move()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        moveInput = new Vector2(h, v);
        moveVelocity = moveInput.normalized * moveSpeed;

        anim.SetFloat("speed", moveInput.magnitude);
    }

    private void FixedUpdate()
    {
        if (!diagUI.isActive)
        {
            pRB.MovePosition(pRB.position + moveVelocity * Time.fixedDeltaTime);
            if (facingRight == false && h > 0)
            {
                FlipSprite();

            }
            else if (facingRight == true && h < 0)
            {
                FlipSprite();
            }
        }
       
    }

    protected override void FlipSprite()
    {
        base.FlipSprite();
    }


    private IEnumerator MeleeAttack()
    {
        handAnim.SetTrigger("mediumSwordSwing");
        Collider2D[] colliders = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), whatIsEnemy);
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
        yield return new WaitForSeconds(timeBtwAttack);
    }

    private IEnumerator SpellAttack(int spellIndex)
    {
        CastSpell(spellIndex);
        yield return new WaitForSeconds(1);
    }

    public void CastSpell(int spellIndex)
    {
        Instantiate(spellPrefab[spellIndex], shotPoint.position, magicWeaponSlot.transform.rotation);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1f));
    }
}
