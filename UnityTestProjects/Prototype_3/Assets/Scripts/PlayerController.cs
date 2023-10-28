using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAni;
    public float forceKey = 20;
    public float gravityKey = 5;

    public bool isOnGround = true;
    public bool isHit = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityKey;

        playerAni = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isHit == false && isOnGround && Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * forceKey, ForceMode.Impulse);
            isOnGround = false;
            playerAni.SetTrigger("Jump_trig");
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over !!!");
            isHit = true;
            playerAni.SetInteger("DeathType_int", 1);
            playerAni.SetBool("Death_b", true);
        }
    }

}
