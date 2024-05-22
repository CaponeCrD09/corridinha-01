using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    Rigidbody2D rig;
    public float jumpForce;
    public bool isJump;
    public bool doubleJump;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
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
}
