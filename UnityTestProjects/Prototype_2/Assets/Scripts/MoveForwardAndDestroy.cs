using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class MoveForwardAndDestroy : MonoBehaviour
{

    public float speed = 40.0f;
    // 上下销毁参数
    private float upBound = 30.0f;
    //private float downBound = -6.0f;
    // 左右销毁参数
    private float leftBound = -27;
    private float rightBound = 27;

    private CountScore cs;

    // Start is called before the first frame update
    void Start()
    {
        cs =GameObject.Find("CountScore").GetComponent<CountScore>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (transform.position.x > rightBound)
        {
            Destroy(gameObject);
            cs.CountLife(-1);
        }
        else if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
            cs.CountLife(-1);
        }
        if (transform.position.z > upBound)
        {
            Destroy(gameObject);
        }


    }
}
