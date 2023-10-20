using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondCameraFollow : MonoBehaviour
{
    // Camera Offset
    private Vector3 camOffSet = new Vector3(0, 4.5f, -0.1f);
    private float horizontalInput;
    private float turnSpeed = 60;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void LateUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.position = player.transform.position + camOffSet;
        transform.Rotate(Vector3.up, horizontalInput * Time.deltaTime * turnSpeed);

    }
}
