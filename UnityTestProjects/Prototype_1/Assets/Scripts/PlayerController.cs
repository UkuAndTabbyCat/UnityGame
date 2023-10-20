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
    public GameObject camera1;
    public GameObject camera2;

    // Start is called before the first frame update
    void Start()
    {
        camera2.SetActive(false);
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


        // 按键切换相机
        if (Input.GetKeyUp(KeyCode.Y))
        {
            if (camera1.activeSelf)
            {
                camera2.SetActive(true);
                camera1.SetActive(false);
            }
            else
            {
                camera1.SetActive(true);
                camera2.SetActive(false);
            }
        }

    }
}
