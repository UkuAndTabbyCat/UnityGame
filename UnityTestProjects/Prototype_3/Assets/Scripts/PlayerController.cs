using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float forceKey = 20;
    public float gravityKey = 5;

    public bool isOnGround = true;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = transform.GetComponent<Rigidbody>();
        Physics.gravity *= gravityKey;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnGround && Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * forceKey, ForceMode.Impulse);
            isOnGround = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }

}
