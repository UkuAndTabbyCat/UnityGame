using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] List<AudioClip> m_JumpSound;

    [SerializeField] private float jumpVelocity;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpMultiplier;
    [SerializeField] private float fallMultiplier;
    private float inputHorizontal;
    private float xBound = 4.5f;

    private Rigidbody playerRb;
    private Animator playerAnimator;
    private AudioSource playerAudioSource;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = transform.GetComponentInChildren<Animator>();
        playerAudioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        moveLimit();
        if (playerRb.velocity.y > 0)
        {
            transform.GetComponent<BoxCollider>().isTrigger = true;
            playerRb.velocity += Vector3.up * Physics.gravity.y * jumpMultiplier * Time.deltaTime;
        }
        else
        {
            transform.GetComponent<BoxCollider>().isTrigger = false;
            playerRb.velocity += Vector3.up * Physics.gravity.y * fallMultiplier * Time.deltaTime;
        }

        if (playerRb.velocity.y < 0)
        {
            playerAnimator.SetBool("Jump_b", false);
        }
    }

    private void Move()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        if (inputHorizontal < 0)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        else
            transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.Translate(Vector3.right * Mathf.Abs(inputHorizontal) * moveSpeed * Time.deltaTime);
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
        playerRb.velocity += Vector3.up * jumpVelocity;
        playerAnimator.SetBool("Jump_b", true);
        int num = Random.Range(0, m_JumpSound.Count);
        playerAudioSource.PlayOneShot(m_JumpSound[num]);

    }
}
