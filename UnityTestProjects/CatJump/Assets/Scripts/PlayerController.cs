using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float moveSpeed;
    private float inputHorizontal;
    private float xBound = 4.5f;

    private Rigidbody playerRb;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * inputHorizontal * moveSpeed * Time.deltaTime);
        moveLimit();
        if (playerRb.velocity.y > 0)
        {
            transform.GetComponent<CapsuleCollider>().isTrigger = true;
        }
        else
        {
            transform.GetComponent<CapsuleCollider>().isTrigger = false;
        }
    }

    private void moveLimit()
    {
        // limit x position
        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
