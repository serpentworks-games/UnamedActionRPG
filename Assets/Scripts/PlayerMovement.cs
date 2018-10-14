using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed;
    Rigidbody2D pRB;
    Vector2 moveInput;
    Vector2 moveVelocity;
    float h;
    float v;
    bool facingRight = true;
    Animator anim;
    DialogueUI diagUI;

    private void Awake()
    {
        pRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        diagUI = FindObjectOfType<DialogueUI>();
    }
	
	// Update is called once per frame
	void Update () {
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

    void FlipSprite()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
