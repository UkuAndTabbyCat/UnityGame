using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI textGUI;
    public TextMeshProUGUI gameOverGUI;
    private float sleepTime = 1;
    private int score = 0;
    public bool isGameALive = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTargets());
        UpdateScore(score);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnTargets()
    {
        while (isGameALive)
        {
            yield return new WaitForSeconds(sleepTime);
            int targetIndex = Random.Range(0, targets.Count);
            Instantiate(targets[targetIndex]);
        }
    }

    public void UpdateScore(int addScore)
    {
        score += addScore;
        textGUI.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverGUI.gameObject.SetActive(true);
    }
}
