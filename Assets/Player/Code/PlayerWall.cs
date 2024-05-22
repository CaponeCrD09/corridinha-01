using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using FishNet.Object;
using FishNet.Connection;

public class PlayerWall : NetworkBehaviour
{
    public LayerMask wall;
    public float distanceRight;
    public float distanceLeft;
    public bool canSlideRigth;
    public bool canSlideLeft;
    public float raio;

    public bool canWallSlide;
    public float wallSpeed;
    public RaycastHit2D hitRigth;
    public RaycastHit2D hitLeft;

    Rigidbody2D rig;
    public float xForce;
    public float yForce;
    public float speedDown = 0.01f;

    // Update is called once per frame
    public override void OnStartClient()
    {
        if(base.IsOwner == false)
        {
            return;
        }
        rig = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(base.IsOwner == false)
        {
            return;
        }
        DetectRigth();
        DetectLeft();
        CanWallSlide();
    }
    public void DetectRigth()
    {
        hitRigth = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), distanceRight, wall);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right) * distanceRight, Color.red);
        if (hitRigth && GetComponent<PlayerMove>().isJump)
        {
            canSlideRigth = true;
        }
        else
        {
            canSlideRigth = false;
        }
    }
    public void DetectLeft()
    {
        hitLeft = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), distanceLeft, wall);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.left) * distanceLeft, Color.red);
        if(hitLeft && GetComponent<PlayerMove>().isJump)
        {
            canSlideLeft = true;
        }
        else
        {
            canSlideLeft = false;
        }
    }
    public void CanWallSlide()
    {
        if(canSlideRigth)
        {
                rig.velocity = new Vector2(rig.velocity.x, -speedDown);

                if (Input.GetKeyDown(KeyCode.Space) && GetComponent<PlayerMove>().horizontal != 0)
                {
                    GetComponent<PlayerMove>().enabled = false;
                    rig.velocity = new Vector2(rig.velocity.x, rig.velocity.y);
                    distanceRight = 0f;
                    rig.AddForce(new Vector2(-xForce, yForce), ForceMode2D.Impulse);
                    StartCoroutine(DesabilitPM());
                }
        }
        if (canSlideLeft)
        {
                rig.velocity = new Vector2(rig.velocity.x, -speedDown);

                if (Input.GetKeyDown(KeyCode.Space) && GetComponent<PlayerMove>().horizontal != 0)
                {
                    GetComponent<PlayerMove>().enabled = false;
                    rig.velocity = new Vector2(rig.velocity.x, rig.velocity.y);
                    distanceLeft = 0f;
                    rig.AddForce(new Vector2(xForce, yForce), ForceMode2D.Impulse);
                    StartCoroutine(DesabilitPM());
                }
        }
    }
    IEnumerator DesabilitPM()
    {       
        yield return new WaitForSeconds(0.2f);
        speedDown = -0.01f;
        distanceRight = 0.6f;
        distanceLeft = 0.6f;
        GetComponent<PlayerMove>().enabled = true;
    }
        
}
