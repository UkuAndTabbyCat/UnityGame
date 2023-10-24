using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountScore : MonoBehaviour
{
    private int score = 0;
    private int life = 3;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore(int v)
    {
        score += v;
        Debug.Log("Score = " + score);
    }

    public void CountLife(int v)
    {
        life += v;
        if (life <= 0)
        {
            life = 0;
            Debug.Log("Game Over!!!!!");
        }
        Debug.Log("Life = " + life);
    }

}
