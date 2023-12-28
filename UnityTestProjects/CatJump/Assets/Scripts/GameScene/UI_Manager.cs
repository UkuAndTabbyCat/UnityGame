using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_ScoreText;
    [SerializeField] TextMeshProUGUI m_lifeNum;
    [SerializeField] List<Image> m_lifeImg;
    [SerializeField] List<AudioClip> m_BGM_Lists;
    private int score = 0;
    private int life = 5;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < m_lifeImg.Count; i++)
        {
            m_lifeImg[i].enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }

    void UpdateScore()
    {
        float pos_y = Camera.main.transform.position.y * 100f;
        score = Mathf.RoundToInt(pos_y);
        m_ScoreText.SetText($"Score : {score}");
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Continue()
    {
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("StartScene");
    }

    private IEnumerator LoopGameMusic()
    {
        while (true){

            yield return null;
        }
        
    }
}
