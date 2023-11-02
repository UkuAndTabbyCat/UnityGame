using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private float rotateSpeed;
    private float horizontalInput;
    // Start is called before the first frame update
    void Start()
    {
        rotateSpeed = 80;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * Time.deltaTime * rotateSpeed);
    }
}
