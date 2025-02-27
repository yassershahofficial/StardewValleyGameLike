using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class characterController2D : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim; 
    SpriteRenderer sprite;

    Vector2 motionVector;
    public Vector2 lastMotionVector;
    
    public bool isMoving;

    [SerializeField] float speed = 0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        motionVector = new Vector2(
            horizontal, 
            vertical
        );
        anim.SetFloat("Horizontal",motionVector.x);
        anim.SetFloat("Vertical",motionVector.y);

        if(motionVector.x != 0){
            sprite.flipX = motionVector.x < 0;
        }

        isMoving = horizontal != 0 || vertical != 0;
        anim.SetBool("isMoving",isMoving);
        if(isMoving){
            lastMotionVector = new Vector2(
                horizontal,
                vertical
            ).normalized;

            anim.SetFloat("LastHorizontal",horizontal);
            anim.SetFloat("LastVertical",vertical);
        }

    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move(){
        rb.velocity = motionVector * speed;
    }
}
