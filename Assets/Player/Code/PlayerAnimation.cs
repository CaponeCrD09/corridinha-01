using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<PlayerMove>().horizontal != 0 && GetComponent<PlayerJump>().isJump == false && GetComponent<PlayerJump>().doubleJump == false)
        {
            anim.SetInteger("transition", 1);
        }
        else if (GetComponent<PlayerJump>().isJump == true && transform.GetComponent<PlayerWall>().canSlideRigth != true && transform.GetComponent<PlayerWall>().canSlideLeft != true)
        {
            anim.SetInteger("transition", 2);
        }
        else if (GetComponent<PlayerWall>().canSlideRigth && GetComponent<PlayerJump>().isJump)
        {
            anim.SetInteger("transition", 3);
        }
        else if(GetComponent<PlayerWall>().canSlideLeft && GetComponent<PlayerJump>().isJump)
        {
            anim.SetInteger("transition", 4);
        }
        else
        {
            anim.SetInteger("transition", 0);
        }
    }
}
