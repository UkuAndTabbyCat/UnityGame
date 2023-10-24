using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{

    private CountScore cs;

    // Start is called before the first frame update
    void Start()
    {
        cs = GameObject.Find("CountScore").GetComponent<CountScore>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            Destroy(other.gameObject);
            //Destroy(other.gameObject);
            //cs.AddScore(1);

            gameObject.GetComponent<AnimalHunger>().FeedAnimal(1);

        }
        else if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            cs.CountLife(-1);
        }

    }
}
