using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalHunger : MonoBehaviour
{
    public Slider hungerSlider;
    public int amountToBeFed;
    private int currentFed = 0;

    private CountScore cs;

    // Start is called before the first frame update
    void Start()
    {
        hungerSlider.maxValue = amountToBeFed;
        hungerSlider.value = 0;
        hungerSlider.fillRect.gameObject.SetActive(false);

        cs = GameObject.Find("CountScore").GetComponent<CountScore>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FeedAnimal(int amount)
    {
        currentFed += amount;
        hungerSlider.fillRect.gameObject.SetActive(true);
        hungerSlider.value = currentFed;

        if (currentFed >= amountToBeFed)
        {
            cs.AddScore(amountToBeFed);
            Destroy(gameObject, 0.1f);
        }
    }
}
