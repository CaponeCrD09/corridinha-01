using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using FishNet.Object;
using FishNet.Connection;

public class PlayerMove : NetworkBehaviour
{
    Rigidbody2D rig;
    public float speed;
    public float horizontal;
    public Vector3 move;

    //jump

    public float jumpForce;
    public bool isJump;
    public bool doubleJump;

    Animator anim;

    // Start is called before the first frame update
    public override void OnStartClient()
    {
        if(base.IsOwner == false)
        {
            return;
        }
        base.OnStartClient();
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(base.IsOwner == false)
        {
            return;
        }
        Move();
        Jump();
        Anim();
    }
    
    public void Move()
    {
        horizontal = Input.GetAxis("Horizontal");
        move = new Vector3(horizontal * speed, rig.velocity.y);
        rig.velocity = move;
        if(horizontal > 0 )
        {
            transform.localScale = new Vector3(11,11,11);
        }
        else if(horizontal < 0)
        {
            transform.localScale = new Vector3(-11, 11, 11);
        }
    }
    public void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if(!isJump)
            {
                rig.AddForce(new Vector2(0f,jumpForce),ForceMode2D.Impulse);
                isJump = true;
                doubleJump = false;
            }
            else 
            {
                if(!doubleJump)
                {
                    rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                    doubleJump = true;
                }
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJump = false;
            doubleJump = false;
        }
    }
    public void Anim()
    {
        if (horizontal != 0 && isJump == false && doubleJump == false)
        {
            anim.SetInteger("transition", 1);
        }
        else if (isJump == true )
        {
            anim.SetInteger("transition", 2);
        }
        else
        {
            anim.SetInteger("transition", 0);
        }
    }
}
