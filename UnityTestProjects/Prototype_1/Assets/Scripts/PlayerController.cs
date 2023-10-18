using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float x;
    private float z;

    private float speed = 20;
    private float turnSpeed = 60;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Player Move
        x = Input.GetAxis("Horizontal");
        //Debug.Log("当前x为" + x);
        z = Input.GetAxis("Vertical");
        //Debug.Log("当前z为" + z);
        //Vector3 move = new Vector3(x, 0, z);
        //transform.Translate(move * Time.deltaTime * speed);
        transform.Rotate(Vector3.up, x * Time.deltaTime * turnSpeed);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * z);

    }
}
