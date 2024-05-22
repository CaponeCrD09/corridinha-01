using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunning : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.GetComponent<PlayerMove>().speed = 8;
        }
        else
        {
            transform.GetComponent<PlayerMove>().speed = 5;
        }
    }
}
