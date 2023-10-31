using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jump;
    private Rigidbody playerRb;
    private float zBound = 10;
    private bool isStand = true;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // ·½Ïò²Ù¿Ø
        //transform.Translate(Input.GetAxis("Horizontal") * Vector3.right * Time.deltaTime * speed);
        //transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * Time.deltaTime * speed);

        // ÌøÔ¾Ê½
        //if (Input.GetKey(KeyCode.W))
        //{
        //    playerRb.AddForce(Vector3.forward * speed);
        //}
        //else if (Input.GetKey(KeyCode.S))
        //{
        //    playerRb.AddForce(Vector3.back * speed);
        //}
        //else if (Input.GetKey(KeyCode.A))
        //{
        //    playerRb.AddForce(Vector3.left * speed);
        //}
        //else if (Input.GetKey(KeyCode.D))
        //{
        //    playerRb.AddForce(Vector3.right * speed);
        //}

        MovePlayer();
        JumpPlayer();

    }

    private void MovePlayer()
    {
        playerRb.AddForce(Vector3.forward * Input.GetAxis("Vertical") * speed);
        playerRb.AddForce(Vector3.right * Input.GetAxis("Horizontal") * speed);

        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }
        else if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
    }

    private void JumpPlayer()
    {
        if (isStand && Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * jump);
            isStand = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isStand = true;
        }
    }

}
