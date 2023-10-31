using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAni;
    private AudioSource playerAudioSource;
    public ParticleSystem particleSys;
    public ParticleSystem dirtParticleSys;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    private MoveLeft backGroundML;
    private MoveLeft obstacleML;

    public float forceKey = 20;
    public float gravityKey = 5;

    public bool isOnGround = true;
    private int doubleJump = 2;
    public bool isHit = false;

    private float score = 0;
    private float kScore;

    // Add Coming Animator
    private float xBound = -8;
    public bool isStart;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAni = GetComponent<Animator>();
        playerAudioSource = GetComponent<AudioSource>();
        Physics.gravity *= gravityKey;

        backGroundML = GameObject.FindWithTag("Background").GetComponent<MoveLeft>();

        kScore = 1;
        PrintScore(score);

        isStart = false;

        playerAni.SetFloat("Speed_f", 0.3f);
        transform.position = Vector3.right * xBound;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 3);
        }
        else
        {
            isStart = true;
            playerAni.SetFloat("Speed_f", 1.5f);
        }

        if (isHit == false && doubleJump > 0 && Input.GetKeyDown(KeyCode.Space))
        {

            isOnGround = false;

            PlayerJump();
            doubleJump--;
        }
        if (!isHit)
        {
            score += Time.deltaTime * 100 * kScore;
            PrintScore(score);
        }

        ControlSpeed();

    }

    void PlayerJump()
    {
        playerRb.AddForce(Vector3.up * forceKey, ForceMode.Impulse);
        playerAni.SetTrigger("Jump_trig");
        dirtParticleSys.Stop();
        playerAudioSource.PlayOneShot(jumpSound, 1.0f);
    }

    void ControlSpeed()
    {
        if (GameObject.FindWithTag("Obstacle"))
        {
            obstacleML = GameObject.FindWithTag("Obstacle").GetComponent<MoveLeft>();
        }

        if (Input.GetKey(KeyCode.D))
        {
            kScore = 2;
            backGroundML.speed = 60;
            if (GameObject.FindWithTag("Obstacle"))
            {
                obstacleML.speed = 60;
            }

        }
        else
        {
            kScore = 1;
            backGroundML.speed = 30;
            if (GameObject.FindWithTag("Obstacle"))
            {
                obstacleML.speed = 30;
            }
        }
    }

    void PrintScore(float score)
    {
        Debug.Log("当前分数为：" + score);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            doubleJump = 2;
            dirtParticleSys.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over !!!");
            isHit = true;
            playerAni.SetInteger("DeathType_int", 1);
            playerAni.SetBool("Death_b", true);
            particleSys.Play();
            dirtParticleSys.Stop();
            playerAudioSource.PlayOneShot(crashSound, 1.0f);
        }
    }

}
