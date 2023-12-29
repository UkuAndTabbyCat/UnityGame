using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] GameObject m_StatusPanel;
    [SerializeField] GameObject m_StopPanel;
    [SerializeField] GameObject m_GameOverPanel;
    [SerializeField] UI_Manager m_UI_Manager;

    private AudioSource m_AudioSource;

    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        if (other.gameObject.CompareTag("Player"))
        {
            m_UI_Manager.UpdateGameOverScore();
            m_UI_Manager.HurtLife(5);
            m_StatusPanel.SetActive(false);
            m_StopPanel.SetActive(false);
            m_GameOverPanel.SetActive(true);
            m_AudioSource.Play();
        }
    }
}
